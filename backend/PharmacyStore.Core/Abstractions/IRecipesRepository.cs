using PharmacyStore.Core.Models;
namespace PharmacyStore.DataAccess.Repositories
{
    public interface IRecipesRepository
    {
        Task<Guid> Create(Recipe recipe);
        Task<Guid> Delete(Guid id);
        Task<List<Recipe>> GetRecipes();
        Task<Recipe> GetRecipeById(Guid id);
        Task<Guid> Update(Guid Id, Guid Customer_id, DateTime Issue_date, string Doctor, string Diagnosis);
    }
}
