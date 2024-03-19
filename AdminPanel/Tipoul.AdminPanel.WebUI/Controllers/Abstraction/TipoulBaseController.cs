using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Configuration;

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Tipoul.AdminPanel.WebUI.Infrastructure.Builder;
using Tipoul.AdminPanel.WebUI.Infrastructure.Builder.Abstraction;
using Tipoul.Athentication.Agent.Services;
using Tipoul.Framework.DataAccessLayer;

namespace Tipoul.AdminPanel.WebUI.Controllers.Abstraction
{
    public abstract class TipoulBaseController<TModel, TListViewModel, TFormViewModel> : Controller
    where TModel : class
    where TListViewModel : ListViewModel
    where TFormViewModel : FormViewModel
    {
        protected readonly TipoulFrameworkDbContext dbContext;

        protected readonly AthenticationProvider athenticationProvider;

        protected TipoulBaseController(TipoulFrameworkDbContext dbContext, AthenticationProvider athenticationProvider)
        {
            this.dbContext = dbContext;
            this.athenticationProvider = athenticationProvider;
        }

        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            return View(await GetListAsync(pageNumber));
        }

        public async Task<IActionResult> Form(int? id)
        {
            return View(await GetItemAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Form([FromServices] IConfiguration configuration, [FromForm] TFormViewModel model)
        {
            try
            {
                await SaveItemAsync(configuration, model);

                HttpContext.Session.SetString("message", "ذخیره با موفقیت انجام شد");
                HttpContext.Session.SetString("message-class", "alert-success");

                return RedirectToAction("index");
            }
            catch
            {
                HttpContext.Session.SetString("message", "ذخیره با مشکل مواجه شد");
                HttpContext.Session.SetString("message-class", "alert-danger");

                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                DoDelete(await dbContext.FindAsync<TModel>(id));

                await dbContext.SaveChangesAsync();

                HttpContext.Session.SetString("message", "حذف با موفقیت انجام شد");
                HttpContext.Session.SetString("message-class", "alert-success");
            }
            catch
            {
                HttpContext.Session.SetString("message", "حذف با مشکل مواجه شد");
                HttpContext.Session.SetString("message-class", "alert-danger");
            }

            return RedirectToAction("index");
        }

        protected async Task<string> TrySaveUploadedFileIfExists([FromServices] IConfiguration configuration, string directory, string propertyName)
        {
            try
            {
                var file = Request.Form.Files["file-" + propertyName];

                var path = $"/{directory}/{DateTime.Now.ToFileTime()}/{file.FileName.Replace(" ", "-")}";

                var fileManagerPath = configuration["FileManagerPath"];

                CreateDirectory(new FileInfo(fileManagerPath + path).Directory);

                using (var stream = new FileStream(fileManagerPath + path, FileMode.Create))
                    await file.CopyToAsync(stream);

                return path;

                void CreateDirectory(DirectoryInfo directoryInfo)
                {
                    if (!directoryInfo.Exists)
                    {
                        if (directoryInfo.Parent != null)
                            CreateDirectory(directoryInfo.Parent);

                        directoryInfo.Create();
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        protected bool TrySaveUploadedFileIfExists([FromServices] IConfiguration configuration, string directory, string propertyName, out string path)
        {
            try
            {
                var file = Request.Form.Files["file-" + propertyName];

                path = $"/{directory}/{DateTime.Now.ToFileTime()}/{file.FileName.Replace(" ", "-")}";

                var fileManagerPath = configuration["FileManagerPath"];

                CreateDirectory(new FileInfo(fileManagerPath + path).Directory);

                using (var stream = new FileStream(fileManagerPath + path, FileMode.Create))
                    file.CopyToAsync(stream).GetAwaiter().GetResult();

                return true;

                void CreateDirectory(DirectoryInfo directoryInfo)
                {
                    if (!directoryInfo.Exists)
                    {
                        if (directoryInfo.Parent != null)
                            CreateDirectory(directoryInfo.Parent);

                        directoryInfo.Create();
                    }
                }
            }
            catch
            {
                path = null;
                return false;
            }
        }

        protected virtual void DoDelete(TModel item)
        {
            dbContext.Remove(item);
        }

        protected IQueryable<TModel> SkipTake(IQueryable<TModel> query, int pageNumber)
        {
            var pageSize = typeof(TListViewModel).GetCustomAttribute<PageSizeAttribute>().PageSize;

            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        protected IActionResult Success(object data = null)
        {
            return Json(new { Success = true, data });
        }

        protected abstract Task<TListViewModel> GetListAsync(int pageNumber);

        protected abstract Task<TFormViewModel> GetItemAsync(int? id);

        protected abstract Task SaveItemAsync([FromServices] IConfiguration configuration, TFormViewModel model);
    }

}