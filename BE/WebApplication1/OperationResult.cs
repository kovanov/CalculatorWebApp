namespace WebApplication1
{
    public class OperationResult
    {
        public decimal Result { get; }
        public ResultOptions Options { get; private set; }

        public OperationResult(decimal value)
        {
            Result = value;
        }

        public static implicit operator OperationResult(decimal value) => new OperationResult(value);
    }
}
