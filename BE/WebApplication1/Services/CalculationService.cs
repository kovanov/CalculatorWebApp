using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Controllers;

namespace WebApplication1
{
    public class CalculationService : ICalculationService
    {
        public OperationResult Add(decimal a, decimal b) => a + b;

        public OperationResult Divide(decimal a, decimal b) => a / b;

        public OperationResult Multiply(decimal a, decimal b) => a * b;

        public OperationResult Subtract(decimal a, decimal b) => a - b;
    }

    public class CalculationServiceColorfulDecorator : ICalculationService
    {
        private ICalculationService _inner;
        private const string Red = "#f00";
        private const string Green = "#0f0";

        public CalculationServiceColorfulDecorator(ICalculationService service)
        {
            _inner = service;
        }


        public OperationResult Add(decimal a, decimal b) => PaintResult(_inner.Add(a, b));

        public OperationResult Divide(decimal a, decimal b) => PaintResult(_inner.Divide(a, b));

        public OperationResult Multiply(decimal a, decimal b) => PaintResult(_inner.Multiply(a, b));

        public OperationResult Subtract(decimal a, decimal b) => PaintResult(_inner.Subtract(a, b));

        private OperationResult PaintResult(OperationResult result)
        {
            var color = result.Result % 2 == 0 ? Green : Red;
            result.SetColor(color);
            return result;
        }
    }
}
