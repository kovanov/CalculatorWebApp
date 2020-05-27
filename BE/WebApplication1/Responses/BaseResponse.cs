namespace WebApplication1.Responses
{
    public class BaseResponse
    {
        public static BaseResponse<T> Ok<T>(T value)
        {
            return new BaseResponse<T>(value);
        }

        public static BaseResponse<T> Error<T>(int errorCode, string message)
        {
            return new BaseResponse<T>(errorCode, message);
        }
    }

    public class BaseResponse<T> : BaseResponse
    {
        public T Data { get; }
        public string Error { get; }
        public int ErrorCode { get; }

        public BaseResponse(T data)
        {
            Data = data;
        }

        public BaseResponse(int errorCode, string message)
        {
            ErrorCode = errorCode;
            Error = message;
        }
    }
}
