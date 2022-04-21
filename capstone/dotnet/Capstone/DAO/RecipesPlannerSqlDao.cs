using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Capstone.Models;

namespace Capstone.DAO
{
    public class RecipesPlannerSqlDao : IRecipesPlannerDao
    {
        private readonly string connectionString;

        public RecipesPlannerSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        //public List<Recipe> GetRecipesByPlanner(int plannerId)
        //{
        //    List<Recipe> recipes = new List<Recipe>();
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            SqlCommand cmd = new SqlCommand("SELECT * FROM recipes_planner " +
        //                                            "WHERE planner_id = @planner_id; ", conn);
        //            cmd.Parameters.AddWithValue("@planner_id", plannerId);
        //            SqlDataReader reader = cmd.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                Recipe recipe = new Recipe();
        //                recipe = GetRecipesPlannerFromReader(reader);
        //                recipes.Add(recipe);
        //            }
        //        }
        //    }
        //    catch (SqlException e)
        //    {
        //        Console.WriteLine(e); ;
        //    }
        //    return recipes;
        //}


        private RecipesPlanner GetRecipesPlannerFromReader(SqlDataReader reader)
        {
            RecipesPlanner myPlanner = new RecipesPlanner();
            myPlanner.rpId = Convert.ToInt32(reader["rp_id"]);
            myPlanner.PlannerId = Convert.ToInt32(reader["planner_id"]);
            myPlanner.RecipeId = Convert.ToInt32(reader["recipe_id"]);
            myPlanner.Day = Convert.ToString(reader["day"]);
            myPlanner.Week = Convert.ToInt32(reader["week"]);

            return myPlanner;
        }
    }
}
