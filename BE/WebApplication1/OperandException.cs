using System;

namespace WebApplication1.Controllers
{
    public class OperandException : Exception
    {
        public int ErrorCode { get; }

        public OperandException(int code, string message) : this(code, message, null) { }

        public OperandException(int code, string message, Exception innerException) : base(message, innerException)
        {
            ErrorCode = code;
        }
    }
}