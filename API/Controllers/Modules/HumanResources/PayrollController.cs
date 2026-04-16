using Application.Modules.HumanResources.Commands.Payroll;
using Application.Modules.HumanResources.Queries.Payroll;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Modules.HumanResources
{
    [Route("api/hr/payroll")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PayrollController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePayrollCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("bonus")]
        public async Task<IActionResult> AddBonus(AddBonusCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("deduction")]
        public async Task<IActionResult> AddDeduction(AddDeductionCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("employee")]
        public async Task<IActionResult> GetEmployeePayrolls([FromQuery] GetEmployeePayrollsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
