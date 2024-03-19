using Tipoul.Framework.Services.OpenBanking.Shahin.Requests;
namespace Tipoul.Framework.Services.OpenBanking.Shahin.StorageModels
{
    public class RequestInnerException
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public RequestException RequestException { get; set; }
    }
}
