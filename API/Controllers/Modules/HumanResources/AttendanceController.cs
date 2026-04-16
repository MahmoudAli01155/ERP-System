using Application.Modules.HumanResources.Commands.Attendanc;
using Application.Modules.HumanResources.Queries.Attendanc;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Modules.HumanResources
{
    [Route("api/hr/attendance")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AttendanceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("check-in")]
        public async Task<IActionResult> CheckIn(CreateAttendanceCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("check-out")]
        public async Task<IActionResult> CheckOut(CheckOutCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("employee")]
        public async Task<IActionResult> GetEmployeeAttendance([FromQuery] GetEmployeeAttendanceQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
