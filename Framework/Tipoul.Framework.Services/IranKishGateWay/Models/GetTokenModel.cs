using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Tipoul.Framework.Services.IranKishGateWay.Models
{
    public class GetTokenModel
    {
        public string AcceptorId { get; set; }

        public long Amount { get; set; }

        public string PaymentId { get; set; }

        public string RequestId { get; set; }

        public long RequestTimestamp { get { return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds; } }

        public string RevertUri { get; set; }

        public string TerminalId { get; set; }

        public string TransactionType { get { return "Purchase"; } }
        public string RsaPublicKey { get; set; }
        public string PassPhrase { get; set; }
    }

    internal class RequestModel
    {
        public RequestModel(GetTokenModel model)
        {
            Request = model;

            string baseString = Request.TerminalId + model.PassPhrase + Request.Amount.ToString().PadLeft(12, '0') + "00";

            using (Aes myAes = Aes.Create())
            {
                myAes.KeySize = 128;
                myAes.GenerateKey();
                myAes.GenerateIV();
                byte[] keyAes = myAes.Key;
                byte[] ivAes = myAes.IV;

                byte[] resultCoding = new byte[48];
                byte[] baseStringbyte = Enumerable.Range(0, baseString.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(value: baseString.Substring(startIndex: x, length: 2), fromBase: 16)).ToArray();

                byte[] encrypted = null;

                using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
                {
                    aesAlg.KeySize = 128;
                    aesAlg.Key = myAes.Key;
                    aesAlg.IV = myAes.IV;
                    aesAlg.Mode = CipherMode.CBC;
                    aesAlg.Padding = PaddingMode.PKCS7;

                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                    encrypted = encryptor.TransformFinalBlock(baseStringbyte, 0, baseStringbyte.Length);
                }

                byte[] hsahash = new SHA256CryptoServiceProvider().ComputeHash(encrypted);

                resultCoding = CombinArray(keyAes, hsahash);
                AuthenticationEnvelope = new AuthenticationEnvelopeModel
                {
                    Data = RSAData(resultCoding, model.RsaPublicKey).Select(t => t.ToString(format: "X2")).Aggregate((a, b) => $"{a}{b}"),
                    Iv = ivAes.Select(t => t.ToString(format: "X2")).Aggregate((a, b) => $"{a}{b}")
                };

            }
        }

        public AuthenticationEnvelopeModel AuthenticationEnvelope { get; set; }

        public GetTokenModel Request { get; set; }

        public class AuthenticationEnvelopeModel
        {
            public string Data { get; set; }

            public string Iv { get; set; }
        }

        private static byte[] RSAData(byte[] aesCodingResult, string publicKey)
        {
            var csp = new RSACryptoServiceProvider();
            var rsa = RSA.Create();
            rsa.ImportFromPem(publicKey.ToCharArray());
            publicKey = rsa.ToXmlString(false);
            csp.FromXmlString(publicKey);   
            return csp.Encrypt(aesCodingResult, false);
        }

        private static byte[] CombinArray(byte[] first, byte[] second)
        {
            byte[] bytes = new byte[first.Length + second.Length];
            Array.Copy(first, 0, bytes, 0, first.Length);
            Array.Copy(second, 0, bytes, first.Length, second.Length);
            return bytes;
        }
    }
}
