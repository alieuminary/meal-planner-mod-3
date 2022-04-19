using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Capstone.Models;

namespace Capstone.DAO
{
    public class PlannerSqlDao : IPlannerDao
    {
        // set up connection string 
        private readonly string connectionString;

        public PlannerSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }


        // Get all stored Planners from DB, store into planner model
        public List<Planner> GetAllPlanners()
        {
            List<Planner> plannerList = new List<Planner>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "SELECT * FROM planner";

                    SqlCommand cmd = new SqlCommand(sqlText, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Planner planner = new Planner();
                        planner = GetPlannerFromReader(reader);
                        plannerList.Add(planner);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return plannerList;

            
        }
        private Planner GetPlannerFromReader(SqlDataReader reader)
        {
            Planner myPlanner = new Planner();

            myPlanner.PlannerId = Convert.ToInt32(reader["planner_id"]);
            myPlanner.Name = Convert.ToString(reader["name"]);
            //myPlanner.RecipeId = Convert.ToInt32(reader["recipe_id"]);
            myPlanner.UserId = Convert.ToInt32(reader["user_id"]);
            myPlanner.Day = Convert.ToString(reader["day"]);
            myPlanner.Week = Convert.ToInt32(reader["week"]);
            myPlanner.IsSharable = Convert.ToBoolean(reader["isSharable"]);

            return myPlanner;

        }
        
    }
}
