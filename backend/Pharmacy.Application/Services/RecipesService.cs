using PharmacyStore.Core.Models;
using PharmacyStore.DataAccess.Repositories;


namespace Pharmacy.Application.Services
{
    public class RecipesService(IRecipesRepository recipesRepository) : IRecipesService
    {
        private readonly IRecipesRepository _recipesRepository = recipesRepository;

        public async Task<Guid> CreateRecipe(Recipe recipe)
        {
            return await _recipesRepository.Create(recipe);
        }

        public async Task<Guid> DeleteRecipe(Guid id)
        {
            return await _recipesRepository.Delete(id);
        }

        public async Task<List<Recipe>> GetAllRecipes()
        {
            return await _recipesRepository.GetRecipes();
        }

        public async Task<Recipe> GetRecipeById(Guid id)
        {
            return await _recipesRepository.GetRecipeById(id);
        }

        public async Task<Guid> UpdateRecipe(Guid Id, Guid Customer_id, DateTime Issue_date, string Doctor, string Diagnosis)
        {
            return await _recipesRepository.Update(Id, Customer_id, Issue_date, Doctor, Diagnosis);
        }
    }
}
