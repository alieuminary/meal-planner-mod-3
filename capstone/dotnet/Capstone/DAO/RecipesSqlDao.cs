/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Capstone.Models;

namespace Capstone.DAO
{
    public class RecipesSqlDao : IRecipesDAO
    {
        private readonly string connectionString;

        public RecipesSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Recipe GetRecipe(int recipeId)
        {
            Recipe recipe = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT r.recipe_name, r.description, r.prep_time, r.cook_time, r.date_created, c.name " +
                                                    "FROM recipes r " +
                                                    "JOIN cuisine c ON r.cuisine_id = c.cuisine_id " +
                                                    "WHERE r.recipe_id = @recipeId", conn);
                    cmd.Parameters.AddWithValue("@recipeId", recipeId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        recipe = GetRecipeFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                return null;
            }

            return recipe;
        }

        public List<Recipe> GetRecipesList(int userId)
        {
            List<Recipe> recipeList = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT r.recipe_name, r.description, r.prep_time, r.cook_time, r.date_created, c.name " +
                                                    "FROM recipes r " +
                                                    "JOIN cuisine c ON r.cuisine_id = c.cuisine_id " +
                                                    "WHERE r.user_id = @userId", conn);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Recipe recipe = new Recipe();
                        recipe = GetRecipeFromReader(reader);
                        recipeList.Add(recipe);
                    }
                }
            }
            catch (SqlException)
            {
                return null;
            }

            return recipeList;
        }

        public Recipe AddRecipe(Recipe recipe)
        {
            int recipeId;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    //need to figure out how to convert cuisine id int to description string//

                    SqlCommand cmd = new SqlCommand("INSERT INTO recipes (recipe_name, description, prep_time, cook_time, date_created, cuisine_id) " +
                                                    "OUTPUT INSERTED.recipe_id " +
                                                    "VALUES (@recipeName, @description, @prepTime, @cookTime, @dateCreated, @cuisineId)", conn);
                    cmd.Parameters.AddWithValue("@recipeName", recipe.RecipeName);
                    cmd.Parameters.AddWithValue("@description", recipe.Description);
                    cmd.Parameters.AddWithValue("@prepTime", recipe.PrepTime);
                    cmd.Parameters.AddWithValue("@cookTime", recipe.CookTime);
                    cmd.Parameters.AddWithValue("@dateCreated", recipe.DateCreated);
                    cmd.Parameters.AddWithValue("@cuisineId", recipe.CuisineName);

                    recipeId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException)
            {
                return null;
            }

            return GetRecipe(recipeId);
        }

        private Recipe GetRecipeFromReader(SqlDataReader reader)
        {
            Recipe recipe = new Recipe();

            recipe.RecipeName = Convert.ToString(reader["recipe_name"]);
            recipe.Description = Convert.ToString(reader["description"]);
            recipe.PrepTime = Convert.ToInt32(reader["prep_time"]);
            recipe.CookTime = Convert.ToInt32(reader["cook_time"]);
            recipe.DateCreated = Convert.ToDateTime(reader["date_created"]);
            recipe.CuisineName = Convert.ToString(reader["name"]);

            return recipe;
        }


    }
}
*/