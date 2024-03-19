
using System;

namespace Tipoul.Services.Shared.Models.Common
{
    public class ApiResult<T>
    {
        public ApiResult()
        {
        }

        public ApiResult(Exception exception, int code)
        {
            Code = code;
            Message = exception.Message;
        }

        public ApiResult(T result)
        {
            Success = true;
            Result = result;
        }

        public int Code { get; set; }

        public string? Message { get; set; }

        public bool Success { get; set; }

        public T? Result { get; set; }
    }
}