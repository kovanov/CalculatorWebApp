namespace WebApplication1.Controllers.Operations
{
    public class DivideOperation : BinaryOperation
    {
        public DivideOperation(decimal a, decimal b) : base(a, b) { }

        public override void Validate()
        {
            base.Validate();

            if(_b == 0)
            {
                throw new OperandException(1, "Can not divide by 0");
            }
        }

        public override decimal Execute() => _a / _b;
    }
}