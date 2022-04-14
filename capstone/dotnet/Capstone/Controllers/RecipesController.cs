using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]

    public class RecipeController : ControllerBase
    {
        private readonly IRecipeDao recipesDao;

        public RecipeController(IRecipeDao recipesDao)
        {
            this.recipesDao = recipesDao;
        }

        [HttpGet("users/{userId}")]
        public ActionResult<List<Recipe>> GetRecipesList(int userId)
        {
            List<Recipe> recipesList = recipesDao.GetRecipeList(userId);

            if (recipesList != null)
            {
                int currentUserId = Int32.Parse(User.FindFirst("sub")?.Value);

                if (currentUserId == userId)
                {
                    return recipesList;
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{recipeId}")]
        public ActionResult<Recipe> GetRecipe(int recipeid)
        {
            Recipe recipe = recipesDao.GetRecipeById(recipeid);

            if (recipe != null)
            {
                return recipe;
            }

            else
            {
                return BadRequest();
            }
        }


        [HttpGet("{charLetter}")]
        public ActionResult<List<Recipe>> GetRecipeListByLetter(char charlLetter)
        {
            List<Recipe> recipe = recipesDao.GetRecipeListByLetter(charlLetter);

            if (recipe != null)
            {
                return recipe;
            }

            else
            {
                return BadRequest();
            }
        }

        [HttpPost()]
        public ActionResult<Recipe> AddRecipe(Recipe recipe)
        {
            if (recipe != null)
            {
                int userId = Int32.Parse(User.FindFirst("sub")?.Value);

                Recipe newRecipe = recipesDao.AddRecipe(recipe, userId);

                return Ok(newRecipe);
            }
            else
            {
                return BadRequest();
            }

        }


    }
}


