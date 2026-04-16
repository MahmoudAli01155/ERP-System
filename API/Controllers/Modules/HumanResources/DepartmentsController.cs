using Application.Modules.HumanResources.Commands.Department;
using Application.Modules.HumanResources.DTOs.Department;
using Application.Modules.HumanResources.Queries.Department;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Modules.HumanResources
{
    [Route("api/hr/departments")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDepartmentCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateDepartmentDto dto)
        {
            var result = await _mediator.Send(new UpdateDepartmentCommand(id, dto));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteDepartmentCommand(id));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetDepartmentByIdQuery(id));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetDepartmentsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
