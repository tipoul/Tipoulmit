using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows.Markup;

using Tipoul.Athentication.Agent.Services;
using Tipoul.Framework.DataAccessLayer;
using Tipoul.Framework.StorageModels;
using Tipoul.Framework.Utilities.Converters;
using Tipoul.UserPanel.WebUI.Utilities;

namespace Tipoul.UserPanel.WebUI.Controllers
{
    public class AnalysisController : Controller
    {
        private readonly TipoulFrameworkDbContext dbContext;

        private readonly AthenticationProvider athenticationProvider;

        public AnalysisController(TipoulFrameworkDbContext dbContext, AthenticationProvider athenticationProvider)
        {
            this.dbContext = dbContext;
            this.athenticationProvider = athenticationProvider;
        }

        public IActionResult Transactions() => View();

        public async Task<JsonResult> TransactionCount(int? gateWayId, string psp, string bank)
        {
            var chartUtility = new LineChartUtility(" ", " ", new List<string> { "شنبه", "یک شنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه" });

            var gatewayTitle = gateWayId.HasValue ? await dbContext.CommertialGateWays.Where(f => f.Id == gateWayId.Value).Select(f => f.Title).FirstOrDefaultAsync() : string.Empty;

            chartUtility.AddSerie(GetSerieTitle("تعداد تراکنش ها", gatewayTitle, psp, bank));

            var minDate = DateTime.Today;

            while (minDate.DayOfWeek != DayOfWeek.Saturday)
                minDate = minDate.AddDays(-1);

            var user = athenticationProvider.GetUser();

            var query = dbContext.Transactions
                .Where(f => f.CreateDate >= minDate)
                .FilterSuccessTransactions(user.Id)
                .FilterTransactions(gateWayId, psp, bank);

            var data = await query.Select(f => new
            {
                f.CreateDate,
                f.Id
            }).ToListAsync();

            var dataGroup = data.GroupBy(f => f.CreateDate.DayOfWeek).Select(f => new
            {
                f.Key,
                Count = f.Count()
            }).ToList();

            chartUtility.AddDataToLastSerie(
                dataGroup.Where(f => f.Key == DayOfWeek.Saturday).Select(f => f.Count).FirstOrDefault(),
                dataGroup.Where(f => f.Key == DayOfWeek.Sunday).Select(f => f.Count).FirstOrDefault(),
                dataGroup.Where(f => f.Key == DayOfWeek.Monday).Select(f => f.Count).FirstOrDefault(),
                dataGroup.Where(f => f.Key == DayOfWeek.Tuesday).Select(f => f.Count).FirstOrDefault(),
                dataGroup.Where(f => f.Key == DayOfWeek.Wednesday).Select(f => f.Count).FirstOrDefault(),
                dataGroup.Where(f => f.Key == DayOfWeek.Thursday).Select(f => f.Count).FirstOrDefault(),
                dataGroup.Where(f => f.Key == DayOfWeek.Friday).Select(f => f.Count).FirstOrDefault());

            return Json(chartUtility.AsResult());
        }

        public async Task<FileResult> ExportTransactionCountCSV(int? gateWayId, string psp, string bank)
        {
            var gatewayTitle = gateWayId.HasValue ? await dbContext.CommertialGateWays.Where(f => f.Id == gateWayId.Value).Select(f => f.Title).FirstOrDefaultAsync() : string.Empty;

            var minDate = DateTime.Today;

            while (minDate.DayOfWeek != DayOfWeek.Saturday)
                minDate = minDate.AddDays(-1);

            var user = athenticationProvider.GetUser();

            var query = dbContext.Transactions
                .Where(f => f.CreateDate >= minDate)
                .FilterSuccessTransactions(user.Id)
                .FilterTransactions(gateWayId, psp, bank);

            var data = await query.Select(f => new
            {
                f.CreateDate,
                f.Id
            }).ToListAsync();

            var dataGroup = data.GroupBy(f => f.CreateDate.DayOfWeek).Select(f => new
            {
                f.Key,
                Count = f.Count()
            }).ToList();

            var pattern = "{شنبه},{یک شنبه},{دو شنبه},{سه شنبه},{چهار شنبه},{پنج شنبه},{جمعه}";

            var stream = new MemoryStream();

            stream.Write(UTF8Encoding.UTF8.GetBytes(pattern.Replace("{", string.Empty).Replace("}", string.Empty)));

            stream.Write(UTF8Encoding.UTF8.GetBytes("\n" + pattern
                .Replace("{شنبه}", dataGroup.Where(f => f.Key == DayOfWeek.Saturday).Select(f => f.Count).FirstOrDefault().ToString())
                .Replace("{یک شنبه}", dataGroup.Where(f => f.Key == DayOfWeek.Sunday).Select(f => f.Count).FirstOrDefault().ToString())
                .Replace("{دو شنبه}", dataGroup.Where(f => f.Key == DayOfWeek.Monday).Select(f => f.Count).FirstOrDefault().ToString())
                .Replace("{سه شنبه}", dataGroup.Where(f => f.Key == DayOfWeek.Tuesday).Select(f => f.Count).FirstOrDefault().ToString())
                .Replace("{چهار شنبه}", dataGroup.Where(f => f.Key == DayOfWeek.Wednesday).Select(f => f.Count).FirstOrDefault().ToString())
                .Replace("{پنج شنبه}", dataGroup.Where(f => f.Key == DayOfWeek.Thursday).Select(f => f.Count).FirstOrDefault().ToString())
                .Replace("{جمعه}", dataGroup.Where(f => f.Key == DayOfWeek.Friday).Select(f => f.Count).FirstOrDefault().ToString())));

            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "text/csv", GetSerieTitle("تعداد تراکنش ها", gatewayTitle, psp, bank));
        }

        public async Task<JsonResult> TransactionAmount(int? gateWayId, string psp, string bank)
        {
            var chartUtility = new LineChartUtility(" ", "مبلغ به تومان", new List<string> { "شنبه", "یک شنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه" });

            var gatewayTitle = gateWayId.HasValue ? await dbContext.CommertialGateWays.Where(f => f.Id == gateWayId.Value).Select(f => f.Title).FirstOrDefaultAsync() : string.Empty;

            chartUtility.AddSerie(GetSerieTitle("حجم تراکنش ها", gatewayTitle, psp, bank));

            var minDate = DateTime.Today;

            while (minDate.DayOfWeek != DayOfWeek.Saturday)
                minDate = minDate.AddDays(-1);

            var user = athenticationProvider.GetUser();

            var query = dbContext.Transactions
                .Where(f => f.CreateDate >= minDate)
                .FilterSuccessTransactions(user.Id)
                .FilterTransactions(gateWayId, psp, bank);

            var data = await query.Select(f => new
            {
                f.CreateDate,
                f.GetTokenModel.Amount
            }).ToListAsync();

            var dataGroup = data.GroupBy(f => f.CreateDate.DayOfWeek).Select(f => new
            {
                f.Key,
                Amount = f.Sum(x => x.Amount)
            }).ToList();

            chartUtility.AddDataToLastSerie(
                dataGroup.Where(f => f.Key == DayOfWeek.Saturday).Select(f => f.Amount).FirstOrDefault(),
                dataGroup.Where(f => f.Key == DayOfWeek.Sunday).Select(f => f.Amount).FirstOrDefault(),
                dataGroup.Where(f => f.Key == DayOfWeek.Monday).Select(f => f.Amount).FirstOrDefault(),
                dataGroup.Where(f => f.Key == DayOfWeek.Tuesday).Select(f => f.Amount).FirstOrDefault(),
                dataGroup.Where(f => f.Key == DayOfWeek.Wednesday).Select(f => f.Amount).FirstOrDefault(),
                dataGroup.Where(f => f.Key == DayOfWeek.Thursday).Select(f => f.Amount).FirstOrDefault(),
                dataGroup.Where(f => f.Key == DayOfWeek.Friday).Select(f => f.Amount).FirstOrDefault());

            return Json(chartUtility.AsResult());
        }

        public async Task<FileResult> ExportTransactionAmountCSV(int? gateWayId, string psp, string bank)
        {
            var gatewayTitle = gateWayId.HasValue ? await dbContext.CommertialGateWays.Where(f => f.Id == gateWayId.Value).Select(f => f.Title).FirstOrDefaultAsync() : string.Empty;

            var minDate = DateTime.Today;

            while (minDate.DayOfWeek != DayOfWeek.Saturday)
                minDate = minDate.AddDays(-1);

            var user = athenticationProvider.GetUser();

            var query = dbContext.Transactions
                .Where(f => f.CreateDate >= minDate)
                .FilterSuccessTransactions(user.Id)
                .FilterTransactions(gateWayId, psp, bank);

            var data = await query.Select(f => new
            {
                f.CreateDate,
                f.GetTokenModel.Amount
            }).ToListAsync();

            var dataGroup = data.GroupBy(f => f.CreateDate.DayOfWeek).Select(f => new
            {
                f.Key,
                Amount = f.Sum(x => x.Amount)
            }).ToList();

            var pattern = "{شنبه},{یک شنبه},{دو شنبه},{سه شنبه},{چهار شنبه},{پنج شنبه},{جمعه}";

            var stream = new MemoryStream();

            stream.Write(UTF8Encoding.UTF8.GetBytes(pattern.Replace("{", string.Empty).Replace("}", string.Empty)));

            stream.Write(UTF8Encoding.UTF8.GetBytes("\n" + pattern
                .Replace("{شنبه}", dataGroup.Where(f => f.Key == DayOfWeek.Saturday).Select(f => f.Amount).FirstOrDefault().ToString())
                .Replace("{یک شنبه}", dataGroup.Where(f => f.Key == DayOfWeek.Sunday).Select(f => f.Amount).FirstOrDefault().ToString())
                .Replace("{دو شنبه}", dataGroup.Where(f => f.Key == DayOfWeek.Monday).Select(f => f.Amount).FirstOrDefault().ToString())
                .Replace("{سه شنبه}", dataGroup.Where(f => f.Key == DayOfWeek.Tuesday).Select(f => f.Amount).FirstOrDefault().ToString())
                .Replace("{چهار شنبه}", dataGroup.Where(f => f.Key == DayOfWeek.Wednesday).Select(f => f.Amount).FirstOrDefault().ToString())
                .Replace("{پنج شنبه}", dataGroup.Where(f => f.Key == DayOfWeek.Thursday).Select(f => f.Amount).FirstOrDefault().ToString())
                .Replace("{جمعه}", dataGroup.Where(f => f.Key == DayOfWeek.Friday).Select(f => f.Amount).FirstOrDefault().ToString())));

            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "text/csv", GetSerieTitle("حجم تراکنش ها", gatewayTitle, psp, bank));
        }

        public async Task<JsonResult> AvrageTransactionCount(int? gateWayId, string psp, string bank)
        {
            var chartUtility = new LineChartUtility(" ", " ", new List<string> { "شنبه", "یک شنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه" });

            var gatewayTitle = gateWayId.HasValue ? await dbContext.CommertialGateWays.Where(f => f.Id == gateWayId.Value).Select(f => f.Title).FirstOrDefaultAsync() : string.Empty;

            chartUtility.AddSerie(GetSerieTitle("میانگین تعداد", gatewayTitle, psp, bank));

            var user = athenticationProvider.GetUser();

            var query = dbContext.Transactions
                .FilterSuccessTransactions(user.Id)
                .FilterTransactions(gateWayId, psp, bank);

            var data = await query.Select(f => new
            {
                f.CreateDate,
                f.Id
            }).ToListAsync();

            var dataGroup = data.GroupBy(f => f.CreateDate.Date).ToList();

            chartUtility.AddDataToLastSerie(
                (long)dataGroup.Where(f => f.Key.DayOfWeek == DayOfWeek.Saturday).Select(f => f.LongCount()).SafeAverage(),
                (long)dataGroup.Where(f => f.Key.DayOfWeek == DayOfWeek.Sunday).Select(f => f.LongCount()).SafeAverage(),
                (long)dataGroup.Where(f => f.Key.DayOfWeek == DayOfWeek.Monday).Select(f => f.LongCount()).SafeAverage(),
                (long)dataGroup.Where(f => f.Key.DayOfWeek == DayOfWeek.Tuesday).Select(f => f.LongCount()).SafeAverage(),
                (long)dataGroup.Where(f => f.Key.DayOfWeek == DayOfWeek.Wednesday).Select(f => f.LongCount()).SafeAverage(),
                (long)dataGroup.Where(f => f.Key.DayOfWeek == DayOfWeek.Thursday).Select(f => f.LongCount()).SafeAverage(),
                (long)dataGroup.Where(f => f.Key.DayOfWeek == DayOfWeek.Friday).Select(f => f.LongCount()).SafeAverage());

            return Json(chartUtility.AsResult());
        }

        public async Task<FileResult> ExportAvrageTransactionCountCSV(int? gateWayId, string psp, string bank)
        {
            var gatewayTitle = gateWayId.HasValue ? await dbContext.CommertialGateWays.Where(f => f.Id == gateWayId.Value).Select(f => f.Title).FirstOrDefaultAsync() : string.Empty;

            var minDate = DateTime.Today;

            while (minDate.DayOfWeek != DayOfWeek.Saturday)
                minDate = minDate.AddDays(-1);

            var user = athenticationProvider.GetUser();

            var query = dbContext.Transactions
                .FilterSuccessTransactions(user.Id)
                .FilterTransactions(gateWayId, psp, bank);

            var data = await query.Select(f => new
            {
                f.CreateDate,
                f.Id
            }).ToListAsync();

            var dataGroup = data.GroupBy(f => f.CreateDate.Date).ToList();

            var pattern = "{شنبه},{یک شنبه},{دو شنبه},{سه شنبه},{چهار شنبه},{پنج شنبه},{جمعه}";

            var stream = new MemoryStream();

            stream.Write(UTF8Encoding.UTF8.GetBytes(pattern.Replace("{", string.Empty).Replace("}", string.Empty)));

            stream.Write(UTF8Encoding.UTF8.GetBytes("\n" + pattern
                .Replace("{شنبه}", dataGroup.Where(f => f.Key.DayOfWeek == DayOfWeek.Saturday).Select(f => f.LongCount()).SafeAverage().ToString())
                .Replace("{یک شنبه}", dataGroup.Where(f => f.Key.DayOfWeek == DayOfWeek.Sunday).Select(f => f.LongCount()).SafeAverage().ToString())
                .Replace("{دو شنبه}", dataGroup.Where(f => f.Key.DayOfWeek == DayOfWeek.Monday).Select(f => f.LongCount()).SafeAverage().ToString())
                .Replace("{سه شنبه}", dataGroup.Where(f => f.Key.DayOfWeek == DayOfWeek.Tuesday).Select(f => f.LongCount()).SafeAverage().ToString())
                .Replace("{چهار شنبه}", dataGroup.Where(f => f.Key.DayOfWeek == DayOfWeek.Wednesday).Select(f => f.LongCount()).SafeAverage().ToString())
                .Replace("{پنج شنبه}", dataGroup.Where(f => f.Key.DayOfWeek == DayOfWeek.Thursday).Select(f => f.LongCount()).SafeAverage().ToString())
                .Replace("{جمعه}", dataGroup.Where(f => f.Key.DayOfWeek == DayOfWeek.Friday).Select(f => f.LongCount()).SafeAverage().ToString())));

            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "text/csv", GetSerieTitle("میانگین تعداد", gatewayTitle, psp, bank));
        }

        public async Task<JsonResult> AvrageTransactionAmount(int? gateWayId, string psp, string bank)
        {
            var chartUtility = new LineChartUtility(" ", "مبلغ به تومان", new List<string> { "شنبه", "یک شنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه" });

            var gatewayTitle = gateWayId.HasValue ? await dbContext.CommertialGateWays.Where(f => f.Id == gateWayId.Value).Select(f => f.Title).FirstOrDefaultAsync() : string.Empty;

            chartUtility.AddSerie(GetSerieTitle("میانگین حجم هر تراکنش", gatewayTitle, psp, bank));

            var user = athenticationProvider.GetUser();

            var query = dbContext.Transactions
                .FilterSuccessTransactions(user.Id)
                .FilterTransactions(gateWayId, psp, bank);

            var data = await query.Select(f => new
            {
                f.CreateDate,
                f.GetTokenModel.Amount
            }).ToListAsync();

            chartUtility.AddDataToLastSerie(
                (long)data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Saturday).Select(f => f.Amount).SafeAverage(),
                (long)data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Sunday).Select(f => f.Amount).SafeAverage(),
                (long)data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Monday).Select(f => f.Amount).SafeAverage(),
                (long)data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Tuesday).Select(f => f.Amount).SafeAverage(),
                (long)data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Wednesday).Select(f => f.Amount).SafeAverage(),
                (long)data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Thursday).Select(f => f.Amount).SafeAverage(),
                (long)data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Friday).Select(f => f.Amount).SafeAverage());

            return Json(chartUtility.AsResult());
        }

        public async Task<FileResult> ExportAvrageTransactionAmountCSV(int? gateWayId, string psp, string bank)
        {
            var gatewayTitle = gateWayId.HasValue ? await dbContext.CommertialGateWays.Where(f => f.Id == gateWayId.Value).Select(f => f.Title).FirstOrDefaultAsync() : string.Empty;

            var minDate = DateTime.Today;

            while (minDate.DayOfWeek != DayOfWeek.Saturday)
                minDate = minDate.AddDays(-1);

            var user = athenticationProvider.GetUser();

            var query = dbContext.Transactions
                .FilterSuccessTransactions(user.Id)
                .FilterTransactions(gateWayId, psp, bank);

            var data = await query.Select(f => new
            {
                f.CreateDate,
                f.GetTokenModel.Amount
            }).ToListAsync();

            var pattern = "{شنبه},{یک شنبه},{دو شنبه},{سه شنبه},{چهار شنبه},{پنج شنبه},{جمعه}";

            var stream = new MemoryStream();

            stream.Write(UTF8Encoding.UTF8.GetBytes(pattern.Replace("{", string.Empty).Replace("}", string.Empty)));

            stream.Write(UTF8Encoding.UTF8.GetBytes("\n" + pattern
                .Replace("{شنبه}", data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Saturday).Select(f => f.Amount).SafeAverage().ToString())
                .Replace("{یک شنبه}", data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Sunday).Select(f => f.Amount).SafeAverage().ToString())
                .Replace("{دو شنبه}", data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Monday).Select(f => f.Amount).SafeAverage().ToString())
                .Replace("{سه شنبه}", data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Tuesday).Select(f => f.Amount).SafeAverage().ToString())
                .Replace("{چهار شنبه}", data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Wednesday).Select(f => f.Amount).SafeAverage().ToString())
                .Replace("{پنج شنبه}", data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Thursday).Select(f => f.Amount).SafeAverage().ToString())
                .Replace("{جمعه}", data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Friday).Select(f => f.Amount).SafeAverage().ToString())));

            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "text/csv", GetSerieTitle("میانگین حجم هر تراکنش", gatewayTitle, psp, bank));
        }

        public async Task<JsonResult> SumTransactionAmount(int? gateWayId, string psp, string bank)
        {
            var chartUtility = new LineChartUtility(" ", "مبلغ به تومان", new List<string> { "شنبه", "یک شنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه" });

            var gatewayTitle = gateWayId.HasValue ? await dbContext.CommertialGateWays.Where(f => f.Id == gateWayId.Value).Select(f => f.Title).FirstOrDefaultAsync() : string.Empty;

            chartUtility.AddSerie(GetSerieTitle("مجموع حجم تراکنش ها", gatewayTitle, psp, bank));

            var user = athenticationProvider.GetUser();

            var query = dbContext.Transactions
                .FilterSuccessTransactions(user.Id)
                .FilterTransactions(gateWayId, psp, bank);

            var data = await query.Select(f => new
            {
                f.CreateDate,
                f.GetTokenModel.Amount
            }).ToListAsync();

            chartUtility.AddDataToLastSerie(
                (long)data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Saturday).Select(f => f.Amount).SafeSum(),
                (long)data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Sunday).Select(f => f.Amount).SafeSum(),
                (long)data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Monday).Select(f => f.Amount).SafeSum(),
                (long)data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Tuesday).Select(f => f.Amount).SafeSum(),
                (long)data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Wednesday).Select(f => f.Amount).SafeSum(),
                (long)data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Thursday).Select(f => f.Amount).SafeSum(),
                (long)data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Friday).Select(f => f.Amount).SafeSum());

            return Json(chartUtility.AsResult());
        }

        public async Task<FileResult> ExportSumTransactionAmountCSV(int? gateWayId, string psp, string bank)
        {
            var gatewayTitle = gateWayId.HasValue ? await dbContext.CommertialGateWays.Where(f => f.Id == gateWayId.Value).Select(f => f.Title).FirstOrDefaultAsync() : string.Empty;

            var minDate = DateTime.Today;

            while (minDate.DayOfWeek != DayOfWeek.Saturday)
                minDate = minDate.AddDays(-1);

            var user = athenticationProvider.GetUser();

            var query = dbContext.Transactions
                .FilterSuccessTransactions(user.Id)
                .FilterTransactions(gateWayId, psp, bank);

            var data = await query.Select(f => new
            {
                f.CreateDate,
                f.GetTokenModel.Amount
            }).ToListAsync();

            var pattern = "{شنبه},{یک شنبه},{دو شنبه},{سه شنبه},{چهار شنبه},{پنج شنبه},{جمعه}";

            var stream = new MemoryStream();

            stream.Write(UTF8Encoding.UTF8.GetBytes(pattern.Replace("{", string.Empty).Replace("}", string.Empty)));

            stream.Write(UTF8Encoding.UTF8.GetBytes("\n" + pattern
                .Replace("{شنبه}", data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Saturday).Select(f => f.Amount).SafeSum().ToString())
                .Replace("{یک شنبه}", data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Sunday).Select(f => f.Amount).SafeSum().ToString())
                .Replace("{دو شنبه}", data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Monday).Select(f => f.Amount).SafeSum().ToString())
                .Replace("{سه شنبه}", data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Tuesday).Select(f => f.Amount).SafeSum().ToString())
                .Replace("{چهار شنبه}", data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Wednesday).Select(f => f.Amount).SafeSum().ToString())
                .Replace("{پنج شنبه}", data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Thursday).Select(f => f.Amount).SafeSum().ToString())
                .Replace("{جمعه}", data.Where(f => f.CreateDate.DayOfWeek == DayOfWeek.Friday).Select(f => f.Amount).SafeSum().ToString())));

            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "text/csv", GetSerieTitle("مجموع حجم تراکنش ها", gatewayTitle, psp, bank));
        }

        /// <summary>
        /// تفکیک بازه های زمانی بر اساس تعداد تراکنش (ساعات پیک تراکنش) به تفکیک درگاه
        /// </summary>
        public async Task<JsonResult> TransactionCountSplitedByTimeInDay(int? gateWayId, string psp, string bank)
        {
            var categories = new List<string>(25);

            TimeSpan timespan = TimeSpan.Zero, hour = TimeSpan.FromHours(1);

            while (timespan.TotalDays < 1)
            {
                categories.Add(timespan.ToString("hh\\:mm"));
                timespan = timespan.Add(hour);
            }

            var chartUtility = new LineChartUtility(" ", "تعداد", categories);

            var gatewayTitle = gateWayId.HasValue ? await dbContext.CommertialGateWays.Where(f => f.Id == gateWayId.Value).Select(f => f.Title).FirstOrDefaultAsync() : string.Empty;

            chartUtility.AddSerie(GetSerieTitle("تعداد تراکنش", gatewayTitle, psp, bank));

            var user = athenticationProvider.GetUser();

            var query = dbContext.Transactions
                .FilterSuccessTransactions(user.Id)
                .FilterTransactions(gateWayId, psp, bank);

            {
                var data = await query.Select(f => f.CreateDate).ToListAsync();

                timespan = TimeSpan.Zero;

                while (timespan.TotalDays < 1)
                {
                    chartUtility.AddDataToLastSerie(data.Count(f => f.TimeOfDay.Hours == timespan.Hours));

                    timespan = timespan.Add(hour);
                }
            }

            GC.Collect();

            return Json(chartUtility.AsResult());
        }

        public async Task<FileResult> ExportTransactionCountSplitedByTimeInDayCSV(int? gateWayId, string psp, string bank)
        {
            var gatewayTitle = gateWayId.HasValue ? await dbContext.CommertialGateWays.Where(f => f.Id == gateWayId.Value).Select(f => f.Title).FirstOrDefaultAsync() : string.Empty;

            var user = athenticationProvider.GetUser();

            var pattern = "";

            TimeSpan timespan = TimeSpan.Zero, hour = TimeSpan.FromHours(1);

            while (timespan.TotalDays < 1)
            {
                if (!string.IsNullOrEmpty(pattern))
                    pattern += ",";
                pattern += $"{{{timespan.ToString("hh\\:mm")}}}";
                timespan = timespan.Add(hour);
            }

            var stream = new MemoryStream();

            stream.Write(UTF8Encoding.UTF8.GetBytes(pattern.Replace("{", string.Empty).Replace("}", string.Empty)));

            var query = dbContext.Transactions
                .FilterSuccessTransactions(user.Id)
                .FilterTransactions(gateWayId, psp, bank);

            {
                var data = await query.Select(f => f.CreateDate).ToListAsync();

                timespan = TimeSpan.Zero;

                var values = pattern;

                while (timespan.TotalDays < 1)
                {
                    values = values.Replace($"{{{timespan.ToString("hh\\:mm")}}}", data.Count(f => f.TimeOfDay.Hours == timespan.Hours).ToString());

                    timespan = timespan.Add(hour);
                }

                stream.Write(UTF8Encoding.UTF8.GetBytes("\n" + values));
            }

            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "text/csv", GetSerieTitle("تعداد تراکنش به تقکیک بازه زمانی", gatewayTitle, psp, bank));
        }

        public async Task<JsonResult> CustomerCountBasedOnGatwWay(string psp, string bank)
        {
            var user = athenticationProvider.GetUser();

            var gateWays = await dbContext.CommertialGateWays.Where(f => f.Wallet.UserId == user.Id).Select(f => new { f.Id, f.Title }).ToListAsync();

            var chartUtility = new BarChartUtility(" ", "تعداد", new List<string> { " " });

            var query = dbContext.Transactions
                .FilterSuccessTransactions(user.Id)
                .FilterTransactions(null, psp, bank);

            {
                var data = await query.Select(f => new
                {
                    f.GateWayId,
                    f.GetTokenModel.PayerMobile,
                    f.GetTokenModel.PayerName,
                    f.GetTokenModel.PayerUserId
                }).ToListAsync();

                foreach (var gateway in gateWays)
                {
                    var gatewayData = data
                        .Where(f => f.GateWayId == gateway.Id)
                        .GroupBy(f => new { f.PayerMobile, f.PayerName, f.PayerUserId })
                        .ToList();

                    chartUtility
                        .AddSerie(gateway.Title)
                        .AddDataToLastSerie(gatewayData.Count);
                }
            }

            GC.Collect();

            return Json(chartUtility.AsResult());
        }

        public async Task<FileResult> ExportCustomerCountBasedOnGatwWayCSV(string psp, string bank)
        {
            var user = athenticationProvider.GetUser();

            var gateWays = await dbContext.CommertialGateWays.Where(f => f.Wallet.UserId == user.Id).Select(f => new { f.Id, f.Title }).ToListAsync();

            var pattern = "";

            foreach (var gateway in gateWays)
            {
                if (!string.IsNullOrEmpty(pattern))
                    pattern += ",";
                pattern += $"{{{gateway.Title}}}";
            }

            var stream = new MemoryStream();

            stream.Write(UTF8Encoding.UTF8.GetBytes(pattern.Replace("{", string.Empty).Replace("}", string.Empty)));

            var query = dbContext.Transactions
                .FilterSuccessTransactions(user.Id)
                .FilterTransactions(null, psp, bank);

            {
                var data = await query.Select(f => new
                {
                    f.GateWayId,
                    f.GetTokenModel.PayerMobile,
                    f.GetTokenModel.PayerName,
                    f.GetTokenModel.PayerUserId
                }).ToListAsync();

                var values = pattern;

                foreach (var gateway in gateWays)
                {
                    var gatewayData = data
                        .Where(f => f.GateWayId == gateway.Id)
                        .GroupBy(f => new { f.PayerMobile, f.PayerName, f.PayerUserId })
                        .ToList();

                    values = values.Replace($"{{{gateway.Title}}}", gatewayData.Count.ToString());
                }

                stream.Write(UTF8Encoding.UTF8.GetBytes("\n" + values));
            }

            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "text/csv", GetSerieTitle("تعداد مشتریان یکتا یا پرداخت کنندگان به تفکیک درگاه", null, psp, bank));
        }

        public async Task<JsonResult> TransacionCountBasedOnIssuerBank(int? gateWayId, string psp, string bank)
        {
            var chartUtility = new BarChartUtility(" ", "تعداد", new List<string> { " " });

            var user = athenticationProvider.GetUser();

            var gatewayTitle = gateWayId.HasValue ? await dbContext.CommertialGateWays.Where(f => f.Id == gateWayId.Value).Select(f => f.Title).FirstOrDefaultAsync() : string.Empty;

            var query = dbContext.Transactions
                .FilterSuccessTransactions(user.Id)
                .FilterTransactions(gateWayId, psp, bank);

            {
                var data = (await query.Select(f => new
                {
                    f.TransactionResponse.IssuerBank
                }).ToListAsync()).GroupBy(f => f.IssuerBank);

                foreach (var issuerBankGroup in data)
                {
                    chartUtility
                        .AddSerie(issuerBankGroup.Key)
                        .AddDataToLastSerie(issuerBankGroup.Count());
                }
            }

            GC.Collect();

            return Json(chartUtility.AsResult());
        }

        public async Task<FileResult> ExportTransacionCountBasedOnIssuerBankCSV(int? gateWayId, string psp, string bank)
        {
            var user = athenticationProvider.GetUser();

            var gatewayTitle = gateWayId.HasValue ? await dbContext.CommertialGateWays.Where(f => f.Id == gateWayId.Value).Select(f => f.Title).FirstOrDefaultAsync() : string.Empty;

            var stream = new MemoryStream();

            var query = dbContext.Transactions
                .FilterSuccessTransactions(user.Id)
                .FilterTransactions(null, psp, bank);

            {
                var data = (await query.Select(f => new
                {
                    f.TransactionResponse.IssuerBank
                }).ToListAsync()).GroupBy(f => f.IssuerBank);

                var pattern = string.Join(",", data.Select(f => $"{{{f.Key}}}"));

                stream.Write(UTF8Encoding.UTF8.GetBytes(pattern.Replace("{", string.Empty).Replace("}", string.Empty)));

                var values = pattern;

                foreach (var issuerBankGroup in data)
                    values = values.Replace($"{{{issuerBankGroup.Key}}}", issuerBankGroup.Count().ToString());

                stream.Write(UTF8Encoding.UTF8.GetBytes("\n" + values));
            }

            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "text/csv", GetSerieTitle("تعداد مشتریان یکتا یا پرداخت کنندگان به تفکیک درگاه", gatewayTitle, psp, bank));
        }

        public async Task<JsonResult> FailedTransacionCountBasedOnReason(int? gateWayId, string psp, string bank)
        {
            var chartUtility = new PieChartUtility(" ", "تعداد", new List<string> { " " });

            var user = athenticationProvider.GetUser();

            var gatewayTitle = gateWayId.HasValue ? await dbContext.CommertialGateWays.Where(f => f.Id == gateWayId.Value).Select(f => f.Title).FirstOrDefaultAsync() : string.Empty;

            var query = dbContext.Transactions
                .FilterFailedTransactions(user.Id)
                .FilterTransactions(gateWayId, psp, bank);

            {
                var data = await query.Select(f => new
                {
                    f.InvalidCallbackUrl,
                    f.InvalidReferer,
                    f.ISPAccessTokenErrorMessage,
                    f.TransactionResponse.RespMsg
                }).ToListAsync();

                if (data.Count(f => f.InvalidReferer) != 0)
                {
                    chartUtility
                        .AddSerie("آدرس درخواست دهنده معتبر نیست", data.Count(f => f.InvalidReferer));
                    data = data.Where(f => !f.InvalidReferer).ToList();
                }

                if (data.Count(f => f.InvalidCallbackUrl) != 0)
                {
                    chartUtility
                        .AddSerie("آدرس بازگشت معتبر نیست", data.Count(f => f.InvalidCallbackUrl));
                    data = data.Where(f => f.InvalidCallbackUrl).ToList();
                }

                foreach (var errorMessage in data.Where(f => !string.IsNullOrWhiteSpace(f.ISPAccessTokenErrorMessage)).GroupBy(f => f.ISPAccessTokenErrorMessage))
                    chartUtility
                        .AddSerie(errorMessage.Key.Replace(".", string.Empty), errorMessage.Count());

                foreach (var errorMessage in data.Where(f => !string.IsNullOrWhiteSpace(f.RespMsg)).GroupBy(f => f.RespMsg))
                    chartUtility
                        .AddSerie(errorMessage.Key.Replace(".", string.Empty), errorMessage.Count());
            }

            GC.Collect();

            return Json(chartUtility.AsResult());
        }

        public async Task<FileResult> ExportFailedTransacionCountBasedOnReasonCSV(int? gateWayId, string psp, string bank)
        {
            var user = athenticationProvider.GetUser();

            var gatewayTitle = gateWayId.HasValue ? await dbContext.CommertialGateWays.Where(f => f.Id == gateWayId.Value).Select(f => f.Title).FirstOrDefaultAsync() : string.Empty;

            var stream = new MemoryStream();

            var query = dbContext.Transactions
                .FilterFailedTransactions(user.Id)
                .FilterTransactions(gateWayId, psp, bank);

            {
                var data = await query.Select(f => new
                {
                    f.InvalidCallbackUrl,
                    f.InvalidReferer,
                    f.ISPAccessTokenErrorMessage,
                    f.TransactionResponse.RespMsg
                }).ToListAsync();

                var pattern = "";
                var values = "";

                if (data.Count(f => f.InvalidReferer) != 0)
                {
                    pattern += "آدرس درخواست دهنده معتبر نیست";
                    values += data.Count(f => f.InvalidReferer);
                }

                if (data.Count(f => f.InvalidCallbackUrl) != 0)
                {
                    pattern += ",آدرس بازگشت معتبر نیست";
                    values += "," + data.Count(f => f.InvalidCallbackUrl);
                }

                foreach (var errorMessage in data.Where(f => !string.IsNullOrWhiteSpace(f.ISPAccessTokenErrorMessage)).GroupBy(f => f.ISPAccessTokenErrorMessage))
                {
                    if (!string.IsNullOrWhiteSpace(pattern))
                        pattern += ",";
                    pattern += errorMessage.Key.Replace(".", string.Empty);
                    if (!string.IsNullOrWhiteSpace(values))
                        values += ",";
                    values += errorMessage.Count();
                }

                foreach (var errorMessage in data.Where(f => !string.IsNullOrWhiteSpace(f.RespMsg)).GroupBy(f => f.RespMsg))
                {
                    if (!string.IsNullOrWhiteSpace(pattern))
                        pattern += ",";
                    pattern += errorMessage.Key.Replace(".", string.Empty);
                    if (!string.IsNullOrWhiteSpace(values))
                        values += ",";
                    values += errorMessage.Count();
                }

                stream.Write(UTF8Encoding.UTF8.GetBytes(pattern.Replace("{", string.Empty).Replace("}", string.Empty)));

                stream.Write(UTF8Encoding.UTF8.GetBytes("\n" + values));
            }

            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "text/csv", GetSerieTitle("تفکیک دلیل عدم موفقیت تراکنش ها", gatewayTitle, psp, bank));
        }

        public async Task<JsonResult> CustomerGrow(int? gateWayId, string psp, string bank)
        {
            var minDate = DateTime.Today.AddDays(-31);

            var categories = new List<string>(32);

            for (var date = minDate; date <= DateTime.Today; date = date.AddDays(1))
                categories.Add(DateConverter.ToShamsy(date, "MM/dd"));

            var chartUtility = new BarChartUtility(" ", "تعداد", categories);

            var user = athenticationProvider.GetUser();

            var gatewayTitle = gateWayId.HasValue ? await dbContext.CommertialGateWays.Where(f => f.Id == gateWayId.Value).Select(f => f.Title).FirstOrDefaultAsync() : string.Empty;

            var query = dbContext.Transactions
                .FilterSuccessTransactions(user.Id)
                .FilterTransactions(gateWayId, psp, bank);

            {
                var count = await query.Where(f => f.CreateDate < minDate).GroupBy(f => new
                {
                    f.GetTokenModel.PayerMobile,
                    f.GetTokenModel.PayerName,
                    f.GetTokenModel.PayerUserId
                }).CountAsync();

                var data = (await query.Where(f => minDate <= f.CreateDate).Select(f => new
                {
                    f.CreateDate,
                    f.GetTokenModel.PayerMobile,
                    f.GetTokenModel.PayerName,
                    f.GetTokenModel.PayerUserId
                }).ToListAsync());

                chartUtility.AddSerie(GetSerieTitle("تعداد مشتری ها", gatewayTitle, psp, bank));

                for (var date = minDate; date <= DateTime.Today; date = date.AddDays(1))
                {
                    count += data.Where(f => f.CreateDate.Date == date).GroupBy(f => new { f.PayerMobile, f.PayerName, f.PayerUserId }).Count();
                    chartUtility.AddDataToLastSerie(count);
                }
            }

            GC.Collect();

            return Json(chartUtility.AsResult());
        }

        public async Task<FileResult> ExportCustomerGrowCSV(int? gateWayId, string psp, string bank)
        {
            var minDate = DateTime.Today.AddDays(-31);

            var stream = new MemoryStream();

            var user = athenticationProvider.GetUser();

            var gatewayTitle = gateWayId.HasValue ? await dbContext.CommertialGateWays.Where(f => f.Id == gateWayId.Value).Select(f => f.Title).FirstOrDefaultAsync() : string.Empty;

            var query = dbContext.Transactions
                .FilterSuccessTransactions(user.Id)
                .FilterTransactions(gateWayId, psp, bank);

            {
                var count = await query.Where(f => f.CreateDate < minDate).GroupBy(f => new
                {
                    f.GetTokenModel.PayerMobile,
                    f.GetTokenModel.PayerName,
                    f.GetTokenModel.PayerUserId
                }).CountAsync();

                var data = (await query.Where(f => minDate <= f.CreateDate).Select(f => new
                {
                    f.CreateDate,
                    f.GetTokenModel.PayerMobile,
                    f.GetTokenModel.PayerName,
                    f.GetTokenModel.PayerUserId
                }).ToListAsync());

                var pattern = "";
                var values = "";

                for (var date = minDate; date <= DateTime.Today; date = date.AddDays(1))
                {
                    if (pattern.Length != 0)
                        pattern += ",";
                    pattern += DateConverter.ToShamsy(date, "MM/dd");

                    if (values.Length > 0)
                        values += ",";
                    count += data.Where(f => f.CreateDate.Date == date).GroupBy(f => new { f.PayerMobile, f.PayerName, f.PayerUserId }).Count();
                    values += count;
                }

                stream.Write(UTF8Encoding.UTF8.GetBytes(pattern.Replace("{", string.Empty).Replace("}", string.Empty)));

                stream.Write(UTF8Encoding.UTF8.GetBytes("\n" + values));
            }

            GC.Collect();

            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "text/csv", GetSerieTitle("روند رشد تعداد مشتری ها", gatewayTitle, psp, bank));
        }

        private string GetSerieTitle(string title, params string[] values)
        {
            var result = new StringBuilder(title + " ");

            values = values.Where(f => !string.IsNullOrWhiteSpace(f)).ToArray();

            for (int i = 0; i < values.Length; i++)
            {
                if (i != 0 && !string.IsNullOrWhiteSpace(values[i - 1]) && !string.IsNullOrWhiteSpace(values[i]))
                    result.Append(" و ");
                else
                    result.Append("برای ");

                if (!string.IsNullOrWhiteSpace(values[i]))
                    result.Append(values[i]);
            }

            return result.ToString();
        }
    }

    internal static class ExtentionMethods
    {
        public static IQueryable<Transaction> FilterSuccessTransactions(this IQueryable<Transaction> transactions, int userId)
        {
            return transactions
                .Where(f => f.GateWay.Wallet.UserId == userId)
                .Where(f => f.TransactionConfirmResult != null && f.TransactionConfirmResult.Status != TransactionConfirmResult.ConfirmStatus.NOK);
        }

        public static IQueryable<Transaction> FilterFailedTransactions(this IQueryable<Transaction> transactions, int userId)
        {
            return transactions
                .Where(f => f.GateWay.Wallet.UserId == userId)
                .Where(f => f.ISPAccessToken != null)
                .Where(f => f.TransactionResponse == null || f.TransactionResponse.RespCode != 0);
        }

        public static IQueryable<Transaction> FilterTransactions(this IQueryable<Transaction> transactions, int? gateWayId, string psp, string bank)
        {
            if (gateWayId.HasValue)
                transactions = transactions.Where(f => f.GateWayId == gateWayId);

            if (!string.IsNullOrWhiteSpace(psp))
                if (psp.Trim() == "ایران کیش")
                    transactions = transactions.Where(f => f.SelectedPSP == Transaction.PSP.IranKish);

            if (!string.IsNullOrWhiteSpace(bank))
                transactions = transactions.Where(f => f.TransactionResponse.IssuerBank == bank);

            return transactions;
        }

        public static double SafeAverage(this IEnumerable<long> source)
        {
            if (!source.Any())
                return 0;
            else
                return source.Average();
        }

        public static double SafeSum(this IEnumerable<long> source)
        {
            if (!source.Any())
                return 0;
            else
                return source.Sum();
        }
    }
}
