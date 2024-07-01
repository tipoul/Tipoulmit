public class OperationResult<TData>
{
    public const string SuccessMessage = "عملیات با موفقیت انجام شد";
    public const string ErrorMessage = "عملیات با شکست مواجه شد";

    public string Message { get; set; }
    public string Title { get; set; } = null;
    public OperationResultStatus Status { get; set; }
    public TData Data { get; set; }
    public static OperationResult<TData> Success(TData data)
    {
        return new OperationResult<TData>()
        {
            Status = OperationResultStatus.Success,
            Message = SuccessMessage,
            Data = data,
        };
    }
    public static OperationResult<TData> NotFound()
    {
        return new OperationResult<TData>()
        {
            Status = OperationResultStatus.NotFound,
            Title = "NotFound",
            Data = default(TData),
        };
    }
    public static OperationResult<TData> Error(string message = ErrorMessage)
    {
        return new OperationResult<TData>()
        {
            Status = OperationResultStatus.Error,
            Title = "مشکلی در عملیات رخ داده",
            Data = default(TData),
            Message = message
        };
    }
}
public class OperationResult
{
    public const string SuccessMessage = "عملیات با موفقیت انجام شد";
    public const string ErrorMessage = "عملیات با شکست مواجه شد";
    public const string NotFoundMessage = "اطلاعات یافت نشد";
    public const string ChildMessage = "آیتم دارای وابستگی است";
    public const string DuplicateMessage = "شماره همراه تکراری است";
    public string Message { get; set; }
    public string Title { get; set; } = null;
    public int Datas { get; set; }

    public OperationResultStatus Status { get; set; }

    public static OperationResult Error()
    {
        return new OperationResult()
        {
            Status = OperationResultStatus.Error,
            Message = ErrorMessage,
        };
    }

    public static OperationResult NotFound(string message)
    {
        return new OperationResult()
        {
            Status = OperationResultStatus.NotFound,
            Message = message,
        };
    }
    public static OperationResult NotFound()
    {
        return new OperationResult()
        {
            Status = OperationResultStatus.NotFound,
            Message = NotFoundMessage,
        };
    }
    public static OperationResult Error(string message)
    {
        return new OperationResult()
        {
            Status = OperationResultStatus.Error,
            Message = message,
        };
    }
    public static OperationResult Error(string message, OperationResultStatus status)
    {
        return new OperationResult()
        {
            Status = status,
            Message = message,
        };
    }
    public static OperationResult Success()
    {
        return new OperationResult()
        {
            Status = OperationResultStatus.Success,
            Message = SuccessMessage,
        };
    }
    public static OperationResult Success(string message)
    {
        return new OperationResult()
        {
            Status = OperationResultStatus.Success,
            Message = message,
        };
    }

    public static OperationResult Child()
    {
        return new OperationResult()
        {
            Status = OperationResultStatus.Child,
            Message = SuccessMessage,
        };
    }
    public static OperationResult Child(string message)
    {
        return new OperationResult()
        {
            Status = OperationResultStatus.Child,
            Message = message,
        };
    }
    public static OperationResult Duplicate()
    {
        return new OperationResult()
        {
            Status = OperationResultStatus.Duplicate,
            Message = DuplicateMessage,
        };
    }
    public static OperationResult Duplicate(string message)
    {
        return new OperationResult()
        {
            Status = OperationResultStatus.Duplicate,
            Message = message,
        };
    }
}


public enum OperationResultStatus
{
    Error = 10,
    Success = 200,
    NotFound = 404,
    Child = 408,
    Duplicate = 100,
}
