using Application.Modules.HumanResources.Commands.Employee;
using Application.Modules.HumanResources.DTOs.Employee;
using Application.Modules.HumanResources.Queries.Employee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Modules.HumanResources
{
    [Route("api/hr/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateEmployeeDto dto)
        {
            var result = await _mediator.Send(new UpdateEmployeeCommand(id, dto));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteEmployeeCommand(id));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetEmployeeByIdQuery(id));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetEmployeesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
