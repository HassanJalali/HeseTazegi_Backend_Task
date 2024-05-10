using HeseTazegi.Application.Contracts.Ingredients;
using HeseTazegi.Facade.Contracts.Ingredients;
using HeseTazegi.Read.Queries.Contracts.Ingredients;
using HeseTazegi.Read.Queries.Contracts.Ingredients.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HeseTazegi.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientCommandFacade _commandFacade;
        private readonly IIngredientQueryFacade _queryFacade;

        public IngredientController(IIngredientCommandFacade commandFacade,
            IIngredientQueryFacade queryFacade)
        {
            _commandFacade = commandFacade;
            _queryFacade = queryFacade;
        }

        [HttpGet("all")]
        public async Task<List<IngredientDto>> GetIngredients()
        {
            return await _queryFacade.GetIngredients();
        }

        [HttpGet("id")]
        public async Task<IngredientDto> GetIngredientById(Guid id)
        {
            return await _queryFacade.GetIngredientById(id);
        }

        [HttpGet("name")]
        public async Task<IngredientDto> GetIngredientByName(string name)
        {
            return await _queryFacade.GetIngredientByName(name);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIngredient([FromBody] CreateIngredientCommand command)
        {
            var result = _commandFacade.CreateIngredient(command);
            return Ok(result);
        }
    }
}