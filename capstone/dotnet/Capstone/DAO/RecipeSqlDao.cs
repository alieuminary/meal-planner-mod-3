using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Capstone.Models;

namespace Capstone.DAO
{
    public class RecipeSqlDao : IRecipeDao
    {
        private readonly string connectionString;

        public RecipeSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Recipe GetRecipeById(int recipeId)
        {
            Recipe recipe = new Recipe();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT r.recipe_id, r.recipe_name, r.drink_alternate, c.name AS category, a.name AS area, r.instructions, r.recipe_image, r.recipe_tags, r.youtube, r.source, r.image_source, r.date, r.user_id " +
                                                    "FROM recipe r " +
                                                    "JOIN category c ON r.category_id = c.category_id " +
                                                    "JOIN area a ON r.area_id = a.area_id " +
                                                    "WHERE r.recipe_id = @recipeId", conn);
                    cmd.Parameters.AddWithValue("@recipeId", recipeId);

                    SqlDataReader reader= cmd.ExecuteReader();

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

        public List<Recipe> GetRecipeList(int userId)
        {
            List<Recipe> recipeList = new List<Recipe>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT r.recipe_id, r.recipe_name, r.drink_alternate, c.name AS category, a.name AS area, r.instructions, r.recipe_image, r.recipe_tags, r.youtube, r.source, r.image_source, r.date, r.user_id " +
                                                    "FROM recipe r " +
                                                    "JOIN category c ON r.category_id = c.category_id " +
                                                    "JOIN area a ON r.area_id = a.area_id " +
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
        public List<Recipe> GetRecipeListByLetter(char charLetter)
        {
            List<Recipe> recipeList = new List<Recipe>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT r.recipe_id, r.recipe_name, r.drink_alternate, c.name AS category, a.name AS area, r.instructions, r.recipe_image, r.recipe_tags, r.youtube, r.source, r.image_source, r.date, r.user_id " +
                                                    "FROM recipe r " +
                                                    "JOIN category c ON r.category_id = c.category_id " +
                                                    "JOIN area a ON r.area_id = a.area_id " +
                                                    "WHERE r.recipe_name LIKE '@charLetter%'", conn);
                    cmd.Parameters.AddWithValue("@charLetter", charLetter);

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

        // Not working for whatever reason. Crashing in sQL
        public Recipe AddRecipe(Recipe recipe, int userId)
        {
            int recipeId;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO recipe (recipe_name, drink_alternate, category_id, area_id, instructions, recipe_image, recipe_tags, youtube, source, image_source, date, user_id) " +
                                                    "OUTPUT INSERTED.recipe_id " +
                                                    "VALUES (@recipeName, @drinkAlternate, (SELECT category_id FROM category WHERE name = @categoryName), (SELECT area_id FROM area WHERE name = @areaName), " +
                                                    "@instructions, @recipeImage, @recipeTags, @youtube, @source, @imageSource, @date, @userId);", conn);
                    cmd.Parameters.AddWithValue("@recipeName", recipe.RecipeName);
                    cmd.Parameters.AddWithValue("@drinkAlternate", recipe.DrinkAlternate);
                    cmd.Parameters.AddWithValue("@categoryName", recipe.CategoryName);
                    cmd.Parameters.AddWithValue("@areaName", recipe.AreaName);
                    cmd.Parameters.AddWithValue("@instructions", recipe.Instructions);
                    cmd.Parameters.AddWithValue("@recipeImage", recipe.RecipeImage);
                    cmd.Parameters.AddWithValue("@recipeTags", recipe.RecipeTags);
                    cmd.Parameters.AddWithValue("@youtube", recipe.Youtube);
                    cmd.Parameters.AddWithValue("@source", recipe.Source);
                    cmd.Parameters.AddWithValue("@imageSource", recipe.ImageSource);
                    cmd.Parameters.AddWithValue("@data", recipe.Date);
                    cmd.Parameters.AddWithValue("@userId", userId);


                    recipeId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException)
            {
                return null;
            }

            return GetRecipeById(recipeId);
        }

        private Recipe GetRecipeFromReader(SqlDataReader reader)
        {
            Recipe myRecipe = new Recipe();

            myRecipe.RecipeId = Convert.ToInt32(reader["recipe_id"]);
            myRecipe.RecipeName = Convert.ToString(reader["recipe_name"]);
            myRecipe.DrinkAlternate = Convert.ToString(reader["drink_alternate"]);
            myRecipe.CategoryName = Convert.ToString(reader["category"]);
            myRecipe.AreaName = Convert.ToString(reader["area"]);
            myRecipe.Instructions = Convert.ToString(reader["instructions"]);
            myRecipe.RecipeImage = Convert.ToString(reader["recipe_image"]);
            myRecipe.RecipeTags = Convert.ToString(reader["recipe_tags"]);
            myRecipe.Youtube = Convert.ToString(reader["youtube"]);
            myRecipe.Source = Convert.ToString(reader["source"]);
            myRecipe.ImageSource = Convert.ToString(reader["image_source"]);
            myRecipe.Date = Convert.ToString(reader["date"]);
            myRecipe.UserId = Convert.ToInt32(reader["user_id"]);

            return myRecipe;
        }


    }
}


