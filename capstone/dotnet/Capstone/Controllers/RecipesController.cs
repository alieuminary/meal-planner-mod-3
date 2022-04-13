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

    public class RecipesController : ControllerBase
    {
        private readonly IRecipesDAO recipesDao;

        public RecipesController(IRecipesDAO recipesDao)
        {
            this.recipesDao = recipesDao;
        }

        [HttpGet()]
        public ActionResult<List<Recipe>> GetRecipesList(int userId)
        {
            List<Recipe> recipesList = recipesDao.GetRecipesList(userId);

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
        public ActionResult<Recipe> GetRecipe (int recipeid)
        {
            Recipe recipe = recipesDao.GetRecipe(recipeid);

            if (recipe != null)
            {
                //NOT WORKING TO HAVE AUTHENTICATED USER

                //int userId = Int32.Parse(User.FindFirst("sub")?.Value);

                //if (userId == recipe.UserId)
                //{
                //    return recipe;
                //}

                return recipe;
            }

            else
            {
                return BadRequest();
            }
        }

        [HttpPost()]
        public ActionResult<Recipe> AddRecipe (Recipe recipe)
        {
            if (recipe != null)
            { 
                int userId = Int32.Parse(User.FindFirst("sub")?.Value);

                if (userId == recipe.UserId)
                {
                    Recipe newrRecipe = recipesDao.AddRecipe(recipe);
                    return Ok();
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


    }
}
