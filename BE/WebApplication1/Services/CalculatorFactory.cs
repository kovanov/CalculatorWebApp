using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Controllers;

namespace WebApplication1.Services
{
    public class CalculatorFactory
    {
        public ICalculationService Create(CalculatorOptions options)
        {
            ICalculationService calculator = new CalculationService();

            if (options.UseColors)
            {
                calculator = new CalculationServiceColorfulDecorator(calculator);
            }

            return calculator;
        }
    }

    public class CalculatorOptions
    {
        public bool UseColors { get; set; }
    }
}
