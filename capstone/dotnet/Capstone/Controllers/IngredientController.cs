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

    public class IngredientController : ControllerBase
    {
        private readonly IIngredientDao ingredientDao;

        public IngredientController(IIngredientDao ingredientDao)
        {
            this.ingredientDao = ingredientDao;
        }

        [HttpGet("{recipeId}")]
        public ActionResult<List<Ingredient>> GetIngredientsByRecipeId(int recipeid)
        {
            List<Ingredient> ingredients = ingredientDao.IngredientsByRecipeId(recipeid);

            if (ingredients != null)
            {
                return ingredients;
            }

            else
            {
                return BadRequest();
            }
        }

        [HttpPost()]
        public ActionResult<Ingredient> AddIngredient(Ingredient newIngredient)
        {
            if (newIngredient != null)
            {

                Ingredient ingredient = ingredientDao.AddIngredient(newIngredient);

                return Ok(ingredient);
            }
            else
            {
                return BadRequest();
            }

        }


    }
}
