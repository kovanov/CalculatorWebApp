namespace WebApplication1.Controllers.Operations
{
    public class SubtractOperation : BinaryOperation
    {

        public SubtractOperation(decimal a, decimal b) : base(a, b) { }

        public override decimal Execute() => _a - _b;
    }
}