using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IRecipesDAO
    {
        Recipes GetRecipe(int recipeId);

        List<Recipes> GetRecipesList(int userId);

        Recipes AddRecipe(Recipes recipe);
    }
}
