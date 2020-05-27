using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using WebApplication1.Responses;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        private readonly IMathOperationFactory _factory;

        public MathController(IMathOperationFactory factory)
        {
            _factory = factory;
        }

        [HttpPost("Calculate")]
        public BaseResponse<OperationResult> Calculate(MathRequest request)
        {
            var operation = _factory.Create(request.OperationId, request.Operands);

            try
            {
                operation.Validate();
            }
            catch (OperandException e)
            {
                return BaseResponse.Error<OperationResult>(e.ErrorCode, e.Message);
            }

            var result = operation.Execute();

            return BaseResponse.Ok(FormatResult(result, Request.Headers.Where(x => x.Key.Contains("math-"))));
        }

        private OperationResult FormatResult(decimal result, IEnumerable<KeyValuePair<string, StringValues>> enumerable)
        {
            // somehow format result based on headers like math-format, math-usecolors, math-zeroifnegative whatever
            // i think it still need to be some factory or builder that returns an ICanFormatMathResult
            // object constructed like decorators ColorResult(FormattedResult(NonNegativeResult))
            return result;
        }
    }
}
