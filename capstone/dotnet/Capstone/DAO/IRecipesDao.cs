using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IRecipesDAO
    {
        Recipe GetRecipe(int recipeId);

        List<Recipe> GetRecipesList(int userId);

        Recipe AddRecipe(Recipe recipe);
    }
}
