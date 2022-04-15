using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class IngredientSqlDao : IIngredientDao
    {
        private readonly string connectionString;

        public IngredientSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Ingredient> IngredientsByRecipeId(int recipeId)
        {
            List<Ingredient> ingredients = new List<Ingredient>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT i.ingred_id, i.name, i.description, it.name " +
                                                    "FROM ingredient i " +
                                                    "JOIN recipes_ingredients ri ON ri.ingred_id = i.ingred_id " +
                                                    "JOIN ingred_type it ON it.type_id = i.type_id " +
                                                    "WHERE ri.recipe_id = @recipeId", conn);
                    cmd.Parameters.AddWithValue("@recipeId", recipeId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Ingredient ingredient = new Ingredient();
                        ingredient = GetIngredientFromReader(reader);
                        ingredients.Add(ingredient);
                    }
                }
            }
            catch (SqlException)
            {
                return null;
            }

            return ingredients;
        }

        public Ingredient GetIngredientByIngredientId(int ingredientId)
        {
            Ingredient ingredient = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT i.ingred_id, i.name, i.description, it.name " +
                                                    "FROM ingredient i " +
                                                    "JOIN ingred_type it ON it.type_id = i.type_id " +
                                                    "WHERE i.ingred_id = @ingredId", conn);
                    cmd.Parameters.AddWithValue("@ingredId", ingredientId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ingredient = GetIngredientFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                return null;
            }

            return ingredient;
        }

        public Ingredient AddIngredient(Ingredient newIngredient)
        {
            int ingredientId;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO ingredient (name, description, type_id) " +
                                                    "OUTPUT INSERTED.ingred_id " +
                                                    "VALUES (@name, @description, (SELECT type_id FROM ingred_type WHERE name = @typeId));", conn);
                    cmd.Parameters.AddWithValue("@name", newIngredient.Name);
                    cmd.Parameters.AddWithValue("@description", newIngredient.Description);
                    cmd.Parameters.AddWithValue("@typeId", newIngredient.Type);

                    ingredientId = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (SqlException)
            {
                return null;
            }

            return GetIngredientByIngredientId(ingredientId);
        }

        private Ingredient GetIngredientFromReader(SqlDataReader reader)
        {
            Ingredient ingredient = new Ingredient();

            ingredient.IngredId = Convert.ToInt32(reader["ingred_id"]);
            ingredient.Name = Convert.ToString(reader["name"]);
            ingredient.Description = Convert.ToString(reader["description"]);
            ingredient.Type = Convert.ToString(reader["name"]);

            return ingredient;
        }

    }
}
