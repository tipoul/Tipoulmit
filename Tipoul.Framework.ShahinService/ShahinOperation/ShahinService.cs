using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;
using Tipoul.Framework.ShahinService.DataAccessLayer;
using Tipoul.Framework.ShahinService.ShahinOperation.Models;
using Tipoul.Framework.ShahinService.StorageModels.Logs;
using Tipoul.Framework.ShahinService.Utilities;
using Tipoul.Framework.Utilities.Utilities;
using ShahinUtility = Tipoul.Framework.Utilities.Utilities.ShahinUtility;

namespace Tipoul.Framework.ShahinService.ShahinOperation
{
    public class ShahinService
    {
        private const string TokenUrl = "https://94.184.140.112:443/v0.3/obh/oauth/token";
        private const string ApiUrl = "https://94.184.140.112:5443/v0.3/obh";
        private readonly IConfiguration configuration;
        private readonly TipoulShahinDbContext dbContext;
        private readonly RequestLogUtility<ShahinRequest> requestLogUtility;
        private readonly JsonSerializerOptions camelCaseSettings = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
        private string Shahin_UserName = "JdYabK3WTT";
        private string Shahin_Password = "oeT3YCgL10";
        public ShahinService(IConfiguration configuration, TipoulShahinDbContext dbContext)
        {
            this.configuration = configuration;
            this.dbContext = dbContext;

            requestLogUtility = new RequestLogUtility<ShahinRequest>()
                .Catch(CatchLogException)
                .Finally(async requestLog =>
                {
                    requestLog.Duration = DateTime.Now - requestLog.CreateDate;
                    dbContext.ShahinRequests.Add(requestLog);
                    await dbContext.SaveChangesAsync();
                });
        }
        private Task CatchLogException(ShahinRequest requestLog, Exception exception)
        {
            requestLog.Success = false;
            requestLog.ShahinRequestException = new ShahinRequestException
            {
                Message = exception.Message,
                StackTrace = exception.StackTrace,
                InnerMessage = exception.InnerException?.Message,
                InnerStackTrace = exception.InnerException?.StackTrace
            };

            return Task.CompletedTask;
        }

        private static GetTokenResult? tokenResult = null;
        public async Task<GetTokenResult?> GetToken()
        {
            if (tokenResult != null)
            {
                DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(tokenResult.nbf).ToLocalTime();
                if (DateTime.Now > dt.AddSeconds(tokenResult.expires_in))
                    tokenResult = null;
            }
            if (tokenResult == null)
            {
                var requestLog = new ShahinRequest
                {
                    ExtraParameter = "",
                    URL = TokenUrl
                };
                await requestLogUtility.Process(requestLog, () =>
                {
                    using (var httpClientHandler = new HttpClientHandler())
                    {
                        httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                        using (var httpClient = new HttpClient(httpClientHandler))
                        {
                            Uri baseUri = new Uri(TokenUrl);
                            httpClient.BaseAddress = baseUri;
                            httpClient.DefaultRequestHeaders.Clear();
                            httpClient.DefaultRequestHeaders.ConnectionClose = true;
                            //Post body content
                            var values = new List<KeyValuePair<string, string>>();
                            values.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
                            values.Add(new KeyValuePair<string, string>("bank", "BSI"));
                            var content = new FormUrlEncodedContent(values);
                            var authenticationString = Shahin_UserName + ":" + Shahin_Password;
                            var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(authenticationString));
                            var requestMessage = new HttpRequestMessage(HttpMethod.Post, TokenUrl);
                            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);
                            requestMessage.Content = content;

                            var task = httpClient.SendAsync(requestMessage);
                            var response = task.Result;
                            response.EnsureSuccessStatusCode();
                            string responseBody = response.Content.ReadAsStringAsync().Result;
                            var camelCaseSettings = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
                            var valuesString = JsonSerializer.Serialize(values, camelCaseSettings);
                            requestLog.Body = valuesString;
                            requestLog.Response = responseBody;
                            requestLog.Success = true;

                            tokenResult = JsonSerializer.Deserialize<GetTokenResult>(responseBody);
                            return Task.FromResult(tokenResult);
                        }
                    }
                });
                return tokenResult;
            }
            else
            {
                return tokenResult;
            }
        }
        public async Task<TransferResultModel?> Transfer(TransferModel model, string access_token, string? extraParameterForlog)
        {
            var url = ApiUrl + "/api/pisp/transfer";
            var requestLog = new ShahinRequest
            {
                ExtraParameter = extraParameterForlog,
                URL = url
            };
            #region Transfer
            var transfer = new StorageModels.Transfer();
            transfer.Bank = model.bank;
            transfer.NationalCode = model.nationalCode;
            transfer.SourceAccount = model.sourceAccount;
            transfer.DestinationAccountNumber = model.destinationAccountNumber;
            transfer.DestinationBank = model.destinationBank;
            transfer.Amount = model.amount;
            transfer.TransferType = model.transferType.ToString();
            transfer.Babat = model.babat.ToString();
            transfer.PaymentID = model.paymentID;
            transfer.DocumentID = model.documentID;
            transfer.TransferID = model.transferID;
            transfer.DepositDescription = model.depositDescription;
            transfer.WithdrawDescription = model.withdrawDescription;
            transfer.SmsPass = model.smsPass;
            transfer.AccessToken = access_token;
            dbContext.Transfers.Add(transfer);
            dbContext.SaveChanges();
            #endregion
            return await requestLogUtility.Process(requestLog, async () =>
            {
                var modelString = JsonSerializer.Serialize(model, camelCaseSettings);
                long X_Obh_timestamp = ShahinUtility.MillisecondsTimestamp();
                string X_Obh_uuid = Guid.NewGuid().ToString();
                var response = await CallShahinApiAsync(url, modelString, access_token, X_Obh_timestamp, X_Obh_uuid);
                var responseString = await response.Content.ReadAsStringAsync();
                requestLog.Body = modelString;
                requestLog.Response = responseString;
                requestLog.Success = true;
                TransferResultModel resultModel= JsonSerializer.Deserialize<TransferResultModel>(responseString);
                #region TransferResponce
                var transferResponce = new StorageModels.TransferResponce();
                transferResponce.TransactionState = resultModel.transactionState;
                transferResponce.TransactionTime = resultModel.transactionTime;
                transferResponce.UUID = resultModel.uuid;
                transferResponce.SourceAccountNumber = resultModel.respObject.sourceAccountNumber;
                transferResponce.DestinationAccountNumber = resultModel.respObject.destinationAccountNumber;
                transferResponce.Amount = resultModel.respObject.amount;
                transferResponce.SourceBank = resultModel.respObject.sourceBank;
                transferResponce.DestinationBank = resultModel.respObject.destinationBank;
                transferResponce.TransferType = resultModel.respObject.transferType;
                transferResponce.TraceNumber = resultModel.respObject.traceNumber;
                transferResponce.Message = resultModel.respObject.message;
                transferResponce.ErrorCode = resultModel.respObject.errorCode;
                transferResponce.TransferId = transfer.Id;
                dbContext.TransferResponces.Add(transferResponce);
                dbContext.SaveChanges();
                #endregion
                return resultModel;
            });
        }
        public async Task<TransactionInquiryResultModel?> TransactionInquiry(TransactionInquiryModel model, string access_token, string? extraParameterForlog)
        {
            var url = ApiUrl + "/api/pisp/transaction-inquiry";
            var requestLog = new ShahinRequest
            {
                ExtraParameter = extraParameterForlog,
                URL = url
            };
            return await requestLogUtility.Process(requestLog, async () =>
            {
                var modelString = JsonSerializer.Serialize(model, camelCaseSettings);
                long X_Obh_timestamp = ShahinUtility.MillisecondsTimestamp();
                string X_Obh_uuid = Guid.NewGuid().ToString();
                var response = await CallShahinApiAsync(url, modelString, access_token, X_Obh_timestamp, X_Obh_uuid);
                var responseString = await response.Content.ReadAsStringAsync();
                requestLog.Body = modelString;
                requestLog.Response = responseString;
                requestLog.Success = true;
                return JsonSerializer.Deserialize<TransactionInquiryResultModel>(responseString);
            });
        }
        public async Task<AccountBalanceResultModel?> GetAccountBalance(AccountBalanceModel model, string access_token, string? extraParameterForlog)
        {
            var url = ApiUrl + "/api/aisp/get-account-balance";
            var requestLog = new ShahinRequest
            {
                ExtraParameter = extraParameterForlog,
                URL = url
            };
            #region AccountBalance
            var accountBalance = new StorageModels.AccountBalance
            {
                Bank = model.bank,
                NationalCode = model.nationalCode,
                SourceAccount = model.sourceAccount,
                AccessToken = access_token,
            };
            dbContext.AccountBalances.Add(accountBalance);
            dbContext.SaveChanges();
            #endregion
            return await requestLogUtility.Process(requestLog, async () =>
            {
                var modelString = JsonSerializer.Serialize(model, camelCaseSettings);
                long X_Obh_timestamp = ShahinUtility.MillisecondsTimestamp();
                string X_Obh_uuid = Guid.NewGuid().ToString();
                var response = await CallShahinApiAsync(url, modelString, access_token, X_Obh_timestamp, X_Obh_uuid);
                var responseString = await response.Content.ReadAsStringAsync();
                //response.IsSuccessStatusCode;
                requestLog.Body = modelString;
                requestLog.Response = responseString;
                requestLog.Success = true;
                AccountBalanceResultModel resultModel = JsonSerializer.Deserialize<AccountBalanceResultModel>(responseString);
                #region AccountBalanceResponce
                var accountBalanceResponce = new StorageModels.AccountBalanceResponce
                {
                    TransactionState = resultModel.transactionState,
                    TransactionTime = resultModel.transactionTime,
                    UUID = resultModel.uuid,
                    AvailableBalance = resultModel.respObject.availableBalance,
                    EffectiveBalance = resultModel.respObject.effectiveBalance,
                    AccountType = resultModel.respObject.accountType,
                    Message = resultModel.respObject.message,
                    ErrorCode = resultModel.respObject.errorCode,
                    AccountBalanceId = accountBalance.Id,
                };
                dbContext.AccountBalanceResponces.Add(accountBalanceResponce);
                dbContext.SaveChanges();
                #endregion
                return resultModel;
            });
        }
        public async Task<AccountStatementResultModel?> GetAccountStatement(AccountStatementModel model, string access_token, string? extraParameterForlog)
        {
            var url = ApiUrl + "/api/aisp/get-account-statement";
            var requestLog = new ShahinRequest
            {
                ExtraParameter = extraParameterForlog,
                URL = url
            };

            #region dbContext.AccountStatements.Add
            var accountStatement = new StorageModels.AccountStatement
            {
                Bank = model.bank,
                NationalCode = model.nationalCode,
                SourceAccount = model.sourceAccount,
                FromDate = model.fromDate,
                FromTime = model.fromTime,
                ToDate = model.toDate,
                ToTime = model.toTime,
                AccessToken = access_token,
            };
            dbContext.AccountStatements.Add(accountStatement);
            dbContext.SaveChanges();
            #endregion

            return await requestLogUtility.Process(requestLog, async () =>
            {
                var modelString = JsonSerializer.Serialize(model, camelCaseSettings);
                long X_Obh_timestamp = ShahinUtility.MillisecondsTimestamp();
                string X_Obh_uuid = Guid.NewGuid().ToString();
                var response = await CallShahinApiAsync(url, modelString, access_token, X_Obh_timestamp, X_Obh_uuid);
                var responseString = await response.Content.ReadAsStringAsync();
                requestLog.Body = modelString;
                requestLog.Response = responseString;
                requestLog.Success = response.IsSuccessStatusCode;
                AccountStatementResultModel resultModel = JsonSerializer.Deserialize<AccountStatementResultModel>(responseString);

                #region dbContext.AccountStatementResponces
                var accountStatementResponce = new StorageModels.AccountStatementResponce
                {
                    TransactionState = resultModel.transactionState,
                    TransactionTime = resultModel.transactionTime,
                    UUID = resultModel.uuid,
                    Message = resultModel.respObject.message,
                    ErrorCode = resultModel.respObject.errorCode,
                    AccountStatementId = accountStatement.Id,
                };
                if (resultModel.respObject != null && resultModel.respObject.accountStatementList != null)
                {
                    accountStatementResponce.AccountStatementLists = new List<StorageModels.AccountStatementList>();
                    foreach (var item in resultModel.respObject.accountStatementList)
                    {
                        var accountStatementlist = new StorageModels.AccountStatementList
                        {
                            TransactionDate = item.transactionDate,
                            TransactionTime = item.transactionTime,
                            Debit = item.debit,
                            Credit = item.credit,
                            Description = item.description,
                            Balance = item.balance,
                            TransactionTrace = item.transactionTrace,
                            BranchCode = item.branchCode,
                            TransactionIdentity = item.transactionIdentity,
                            StatementStatus = item.statementStatus,
                            SourceAccount = item.sourceAccount,
                            DestinationAccount = item.destinationAccount,
                            AccountStatementResponceId = accountStatementResponce.Id,
                        };
                        accountStatementResponce.AccountStatementLists.Add(accountStatementlist);
                    }
                }
                dbContext.AccountStatementResponces.Add(accountStatementResponce);
                dbContext.SaveChanges();
                #endregion

                return resultModel;
            });
        }
        public async Task<IbanResultModel?> GetIban(IbanModel model, string access_token, string? extraParameterForlog)
        {
            var url = ApiUrl + "/api/aisp/get-iban";
            var requestLog = new ShahinRequest
            {
                ExtraParameter = extraParameterForlog,
                URL = url
            };
            return await requestLogUtility.Process(requestLog, async () =>
            {
                var modelString = JsonSerializer.Serialize(model, camelCaseSettings);
                long X_Obh_timestamp = ShahinUtility.MillisecondsTimestamp();
                string X_Obh_uuid = Guid.NewGuid().ToString();
                var response = await CallShahinApiAsync(url, modelString, access_token, X_Obh_timestamp, X_Obh_uuid);
                var responseString = await response.Content.ReadAsStringAsync();
                requestLog.Body = modelString;
                requestLog.Response = responseString;
                requestLog.Success = response.IsSuccessStatusCode;
                return JsonSerializer.Deserialize<IbanResultModel>(responseString);
            });
        }
        public async Task<IbanInfoResultModel?> GetIbanInfo(IbanInfoModel model, string access_token, string? extraParameterForlog)
        {
            var url = ApiUrl + "/api/aisp/get-iban-info";
            var requestLog = new ShahinRequest
            {
                ExtraParameter = extraParameterForlog,
                URL = url
            };
            #region IbanInfo
            var IbanInfo = new StorageModels.IbanInfo
            {
                Bank = model.bank,
                NationalCode = model.nationalCode,
                SourceAccount = model.sourceAccount,
                AccessToken = access_token,
            };
            dbContext.IbanInfos.Add(IbanInfo);
            dbContext.SaveChanges();
            #endregion
            return await requestLogUtility.Process(requestLog, async () =>
            {
                var modelString = JsonSerializer.Serialize(model, camelCaseSettings);
                long X_Obh_timestamp = ShahinUtility.MillisecondsTimestamp();
                string X_Obh_uuid = Guid.NewGuid().ToString();
                var response = await CallShahinApiAsync(url, modelString, access_token, X_Obh_timestamp, X_Obh_uuid);
                var responseString = await response.Content.ReadAsStringAsync();
                requestLog.Body = modelString;
                requestLog.Response = responseString;
                requestLog.Success = response.IsSuccessStatusCode;
                IbanInfoResultModel resultModel = JsonSerializer.Deserialize<IbanInfoResultModel>(responseString);
                #region IbanInfoResponce
                var IbanInfoResponce = new StorageModels.IbanInfoResponce
                {
                    TransactionState = resultModel.transactionState,
                    TransactionTime = resultModel.transactionTime,
                    Uuid = resultModel.uuid,
                    Bank = resultModel.respObject.bank,
                    AccountNumber = resultModel.respObject.accountNumber,
                    IbanNumber = resultModel.respObject.ibanNumber,
                    FirstName = resultModel.respObject.firstName,
                    LastName = resultModel.respObject.lastName,
                    AccountStatus = resultModel.respObject.accountStatus,
                    NationalCode = resultModel.respObject.nationalCode,
                    Message = resultModel.respObject.message,
                    ErrorCode = resultModel.respObject.errorCode,
                    IbanInfoId = IbanInfo.Id,
                };
                dbContext.IbanInfoResponces.Add(IbanInfoResponce);
                dbContext.SaveChanges();
                #endregion
                return resultModel;
            });
        }
        public async Task<CardInfoResultModel?> GetCardInfo(CardInfoModel model, string access_token, string? extraParameterForlog)
        {
            var url = ApiUrl + "/api/card/get-card-info";
            var requestLog = new ShahinRequest
            {
                ExtraParameter = extraParameterForlog,
                URL = url
            };
            #region CardInfo
            var cardInfo = new StorageModels.CardInfo
            {
                Bank = model.bank,
                NationalCode = model.nationalCode,
                SourceAccount = model.sourceAccount,
                CardNumber = model.cardNumber,
                AccessToken = access_token,
            };
            dbContext.CardInfos.Add(cardInfo);
            dbContext.SaveChanges();
            #endregion
            return await requestLogUtility.Process(requestLog, async () =>
            {
                var modelString = JsonSerializer.Serialize(model, camelCaseSettings);
                long X_Obh_timestamp = ShahinUtility.MillisecondsTimestamp();
                string X_Obh_uuid = Guid.NewGuid().ToString();
                var response = await CallShahinApiAsync(url, modelString, access_token, X_Obh_timestamp, X_Obh_uuid);
                var responseString = await response.Content.ReadAsStringAsync();
                requestLog.Body = modelString;
                requestLog.Response = responseString;
                requestLog.Success = response.IsSuccessStatusCode;
                CardInfoResultModel resultModel= JsonSerializer.Deserialize<CardInfoResultModel>(responseString);
                #region CardInfoResponce
                var cardInfoResponce = new StorageModels.CardInfoResponce
                {
                    TransactionState = resultModel.transactionState,
                    TransactionTime = resultModel.transactionTime,
                    UUID = resultModel.uuid,
                    OwnerName = resultModel.respObject.ownerName,
                    AccountNumber = resultModel.respObject.accountNumber,
                    Bank = resultModel.respObject.bank,
                    Iban = resultModel.respObject.iban,
                    Message = resultModel.respObject.message,
                    ErrorCode = resultModel.respObject.errorCode,
                    CardInfoId = cardInfo.Id,
                };
                dbContext.CardInfoResponces.Add(cardInfoResponce);
                dbContext.SaveChanges();
                #endregion
                return resultModel;
            });
        }
        private async Task<HttpResponseMessage> CallShahinApiAsync(string ApiUrl, string modelString, string access_token, long X_Obh_timestamp, string X_Obh_uuid)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                string certFile = @"C:\Program Files\OpenSSL-Win64\bin\orgCertBundle.pfx";
                httpClientHandler.ClientCertificates.Add(new X509Certificate2(certFile, "5024", X509KeyStorageFlags.MachineKeySet));
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = (s, ce, ca, p) => true;
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    httpClient.DefaultRequestHeaders.Add("X-Obh-timestamp", X_Obh_timestamp.ToString());
                    httpClient.DefaultRequestHeaders.Add("X-Obh-uuid", X_Obh_uuid);
                    string X_Obh_signature = ShahinUtility.CalcOBHSignature("POST", ApiUrl, httpClient.DefaultRequestHeaders, modelString, Shahin_UserName, Shahin_Password);
                    httpClient.DefaultRequestHeaders.Add("X-Obh-signature", X_Obh_signature);
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
                    var stringContent = new StringContent(modelString, null, "application/json");
                    return await httpClient.PostAsync(ApiUrl, stringContent);
                }
            }
        }
    }
}
