using WebApplication1.Controllers;
using WebApplication1.Controllers.Operations;

namespace WebApplication1
{
    public interface IMathOperationFactory
    {
        IMathOperation Create(MathOperation operationId, decimal[] operands);
    }

    public class MathOperationFactory : IMathOperationFactory
    {
        public IMathOperation Create(MathOperation operationId, decimal[] operands) => operationId switch
        {
            MathOperation.Add => new AddOperation(operands[0], operands[1]),
            MathOperation.Subtract => new SubtractOperation(operands[0], operands[1]),
            MathOperation.Multiply => new MultiplyOperation(operands[0], operands[1]),
            MathOperation.Divide => new DivideOperation(operands[0], operands[1]),
        };
    }
}