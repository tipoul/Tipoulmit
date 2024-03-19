using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipoul.Framework.Services.OpenBanking.Shahin.Requests
{
    public class RequestLogUtility<TRequestLogModel>
    {
        private Func<TRequestLogModel, Task>? finallyFunc;

        private Func<TRequestLogModel, Exception, Task>? catchFunc;

        public async Task<T> Process<T>(TRequestLogModel requestLogModel, Func<Task<T>> func)
        {
            try
            {
                return await func.Invoke();
            }
            catch (Exception ex)
            {
                await catchFunc!.Invoke(requestLogModel, ex);

                throw;
            }
            finally
            {
                await finallyFunc!.Invoke(requestLogModel);
            }
        }

        public RequestLogUtility<TRequestLogModel> Catch(Func<TRequestLogModel, Exception, Task> catchFunc)
        {
            this.catchFunc = catchFunc;
            return this;
        }

        public RequestLogUtility<TRequestLogModel> Finally(Func<TRequestLogModel, Task> finallyFunc)
        {
            this.finallyFunc = finallyFunc;
            return this;
        }
    }
}
