namespace WebApplication1.Controllers.Operations
{
    public interface IMathOperation
    {
        void Validate();
        decimal Execute();
    }
}