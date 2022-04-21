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
