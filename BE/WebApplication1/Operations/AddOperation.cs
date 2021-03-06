﻿namespace WebApplication1.Controllers.Operations
{
    public class AddOperation : BinaryOperation
    {
        public AddOperation(decimal a, decimal b) : base(a, b) { }

        public override decimal Execute() => _a + _b;
    }
}