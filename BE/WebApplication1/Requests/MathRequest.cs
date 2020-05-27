namespace WebApplication1.Controllers
{
    public class MathRequest
    {
        public decimal[] Operands { get; set; }
        public MathOperation OperationId { get; set; }
    }

    public enum MathOperation
    {
        Add,
        Subtract,
        Divide,
        Multiply
    }
}