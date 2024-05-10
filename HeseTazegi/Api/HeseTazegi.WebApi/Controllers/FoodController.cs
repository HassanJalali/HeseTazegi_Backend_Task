using HeseTazegi.Application.Contracts.Foods;
using HeseTazegi.Facade.Contracts.Foods;
using HeseTazegi.Read.Queries.Contracts.Foods;
using HeseTazegi.Read.Queries.Contracts.Foods.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HeseTazegi.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodCommandFacade _commandFacade;
        private readonly IFoodQueryFacade _queryFacade;

        public FoodController(IFoodCommandFacade commandFacade, IFoodQueryFacade queryFacade)
        {
            _commandFacade = commandFacade;
            _queryFacade = queryFacade;
        }

        [HttpGet("all")]
        public async Task<List<FoodDto>> GetFoods()
        {
            return await _queryFacade.GetFoods();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFood([FromBody] CreateFoodCommand command)
        {
            var result = _commandFacade.CreateFood(command);
            return Ok(result);
        }
    }
}