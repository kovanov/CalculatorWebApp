using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public void SetColor(string color)
        {
            Options ??= new ResultOptions();
            Options.Color = color;
        }

        public static implicit operator OperationResult(decimal value) => new OperationResult(value);

    }
}
