using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Services;
using Pharmacy.Contracts;
using PharmacyStore.Core.Models;

namespace Pharmacy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipesService _recipesService;

        public RecipesController(IRecipesService recipesService)
        {
            _recipesService = recipesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RecipesResponse>>> GetRecipes()
        {
            var recipes = await _recipesService.GetAllRecipes();

            var response = recipes.Select(b => new RecipesResponse(b.Recipe_Id, b.Customer_id, b.Name, b.Issue_date, b.Doctor, b.Diagnosis));

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RecipesResponse>> GetRecipeById(Guid id)
        {
            var recipe = await _recipesService.GetRecipeById(id);

            var response = new RecipesResponse(recipe.Recipe_Id, recipe.Customer_id, recipe.Name, recipe.Issue_date, recipe.Doctor, recipe.Diagnosis);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateRecipe([FromBody] RecipesRequest request)
        {
            var recipe = new Recipe(Guid.NewGuid(), request.Customer_Id, request.IssueDate, request.Doctor, request.Diagnosis);

            var recId = await _recipesService.CreateRecipe(recipe);

            return Ok(recId);
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateRecipe(Guid id, [FromBody] RecipesRequest request)
        {
            var recId = await _recipesService.UpdateRecipe(id, request.Customer_Id, request.IssueDate, request.Doctor, request.Diagnosis);

            return Ok(recId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteRecipe(Guid id)
        {
            return Ok( await _recipesService.DeleteRecipe(id));
        }
    }
}
