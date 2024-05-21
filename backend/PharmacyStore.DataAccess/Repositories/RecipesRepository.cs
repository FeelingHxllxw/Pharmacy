using Microsoft.EntityFrameworkCore;
using PharmacyStore.Core.Models;
using PharmacyStore.DataAccess.Entities;

namespace PharmacyStore.DataAccess.Repositories
{
    public class RecipesRepository : IRecipesRepository
    {
        private readonly PharmacyDBContext _context;

        public RecipesRepository(PharmacyDBContext context)
        {
            _context = context;
        }
        public async Task<List<Recipe>> GetRecipes()
        {
            var recipesEntites = await _context.recipes.AsNoTracking().ToListAsync();
            var recipes  = recipesEntites.Select(b => new Recipe(b.Recipe_Id, b.Customer_Id, b.Issue_Date, b.Doctor, b.Diagnosis)).ToList();
            foreach (var recipe in recipes)
            {
                var Name = _context.customers.Where(p => p.Customer_Id == recipe.Customer_id).Select(p => $"{p.First_Name} {p.Last_Name} {p.Middle_Name}").SingleOrDefault();
                recipe.Name = Name;
            }
            return recipes;

        }

        public async Task<Guid> Create(Recipe recipe)
        {
            var recipeEntity = new Recipe_Entity
            {
                Recipe_Id = recipe.Recipe_Id,
                Customer_Id = recipe.Customer_id,
                Issue_Date = recipe.Issue_date,
                Doctor = recipe.Doctor,
                Diagnosis = recipe.Diagnosis
            };

            await _context.recipes.AddAsync(recipeEntity);
            await _context.SaveChangesAsync();
            return recipe.Recipe_Id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.recipes.Where(b => b.Recipe_Id == id).ExecuteDeleteAsync();
            return id;
        }

        public async Task<Recipe> GetRecipeById(Guid id)
        {
            var recipeEntity = await _context.recipes.FindAsync(id);
            var recipe = new Recipe(recipeEntity.Recipe_Id, recipeEntity.Customer_Id, recipeEntity.Issue_Date, recipeEntity.Doctor, recipeEntity.Diagnosis);
            var Name = _context.customers.Where(p => p.Customer_Id == recipe.Customer_id).Select(p => $"{p.First_Name} {p.Last_Name} {p.Middle_Name}").SingleOrDefault();
            recipe.Name = Name;
            return recipe;
        }


        public async Task<Guid> Update(Guid Id, Guid Customer_id, DateTime Issue_date, string Doctor, string Diagnosis)
        {
            await _context.recipes.Where(b => b.Recipe_Id == Id).ExecuteUpdateAsync(b => b
            .SetProperty(b => b.Customer_Id, b => Customer_id)
            .SetProperty(b => b.Issue_Date, b => Issue_date)
            .SetProperty(b => b.Doctor, b => Doctor)
            .SetProperty(b => b.Diagnosis, b => Diagnosis));
            return Id;

        }
    }
}
