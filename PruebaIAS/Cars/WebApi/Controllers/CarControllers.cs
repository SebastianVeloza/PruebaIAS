using Application.Cars.Create;
using Domain.Cars;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarControllers : ControllerBase
    {
        private readonly ISender _mediator;

        public CarControllers(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCarsCommand command)
        {
            var createResult = await _mediator.Send(command);
            return createResult.Match(
                Id => Ok(CarsId),
                errors => Problem(errors));
        }
    }
}

