namespace WebApplication1.Controllers.Operations
{
    public class MultiplyOperation : BinaryOperation
    {

        public MultiplyOperation(decimal a, decimal b) : base(a, b) { }

        public override decimal Execute() => _a * _b;
    }
}