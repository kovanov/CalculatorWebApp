using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers.Operations
{
    public abstract class BinaryOperation : IMathOperation
    {
        protected readonly decimal _a;
        protected readonly decimal _b;

        public BinaryOperation(decimal a, decimal b)
        {
            _a = a;
            _b = b;
        }

        public abstract decimal Execute();

        public virtual void Validate() { }
    }
}
