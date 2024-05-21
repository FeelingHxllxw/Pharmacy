using PharmacyStore.Core.Models;


namespace Pharmacy.Application.Services
{
    public interface IRecipesService
    {
        Task<Guid> CreateRecipe(Recipe recipe);
        Task<Guid> DeleteRecipe(Guid id);
        Task<List<Recipe>> GetAllRecipes();
        Task<Recipe> GetRecipeById(Guid id);
        Task<Guid> UpdateRecipe(Guid Id, Guid Customer_id, DateTime Issue_date, string Doctor, string Diagnosis);
    }
}
