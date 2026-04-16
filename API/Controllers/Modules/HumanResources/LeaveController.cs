using Application.Modules.HumanResources.Commands.Leave;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Modules.HumanResources
{
    [Route("api/hr/leaves")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLeaveCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("approve")]
        public async Task<IActionResult> Approve(ApproveLeaveCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("reject")]
        public async Task<IActionResult> Reject(RejectLeaveCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
