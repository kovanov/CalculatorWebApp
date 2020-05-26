using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Responses;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        private readonly CalculatorFactory _factory;

        public MathController(CalculatorFactory factory)
        {
            _factory = factory;
        }


        [HttpGet]
        public BaseResponse<string> Get()
        {
            return BaseResponse.Ok("hello world");
        }

        [HttpGet("Get1")]
        public BaseResponse<string> Get1()
        {
            return BaseResponse.Ok("hello world1");
        }

        [HttpPost("Add")]
        public BaseResponse<OperationResult> Add([FromBody]MathRequest request)
        {
            var calculator = _factory.Create(new CalculatorOptions { UseColors = request.UseColors });
            return BaseResponse.Ok(calculator.Add(request.Operand1, request.Operand2));
        }

        [HttpPost("Subtract")]
        public BaseResponse<OperationResult> Subtract(MathRequest request)
        {
            var calculator = _factory.Create(new CalculatorOptions { UseColors = request.UseColors });
            return BaseResponse.Ok(calculator.Subtract(request.Operand1, request.Operand2));
        }

        [HttpPost("Multiply")]
        public BaseResponse<OperationResult> Multiply(MathRequest request)
        {
            var calculator = _factory.Create(new CalculatorOptions { UseColors = request.UseColors });
            return BaseResponse.Ok(calculator.Multiply(request.Operand1, request.Operand2));
        }

        [HttpPost("Divide")]
        public BaseResponse<OperationResult> Divide(MathRequest request)
        {
            var calculator = _factory.Create(new CalculatorOptions { UseColors = request.UseColors });
            try
            {
                return BaseResponse.Ok(calculator.Divide(request.Operand1, request.Operand2));
            }
            catch (DivideByZeroException)
            {
                return BaseResponse.Error<OperationResult>(1, "some msg 1");
            }
            catch
            {
                return BaseResponse.Error<OperationResult>(999, "some msg 2");
            }
        }
    }
}
