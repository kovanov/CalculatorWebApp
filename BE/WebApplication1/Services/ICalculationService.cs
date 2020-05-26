namespace WebApplication1.Controllers
{
    public interface ICalculationService
    {
        OperationResult Add(decimal a, decimal b);
        OperationResult Subtract(decimal a, decimal b);
        OperationResult Multiply(decimal a, decimal b);
        OperationResult Divide(decimal a, decimal b);
    }
}