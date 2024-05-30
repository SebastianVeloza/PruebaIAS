using Application.Cars.Create;
using Domain.Cars;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("Cars")]
    public class CarControllers : ApiController
    {
        private readonly ISender _mediator;

        public CarControllers(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> create([FromBody] CreateCarsCommand command)
        {
            var createResult = await _mediator.Send(command);
            return createResult.Match(
                Id=> Ok(CarsId),
                errors => Problem(errors));

        }
        
    }
}
