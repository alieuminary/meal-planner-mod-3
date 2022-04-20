﻿using System;
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

        // retrieve specific planner (by planner Id)
        public Planner GetPlannerByPlannerId(int plannerId)
        {
            Planner planner = new Planner();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "SELECT * FROM planner WHERE planner_id = @planner_id";

                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@planner_id", plannerId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                       
                        planner = GetPlannerFromReader(reader);
                        
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return planner;
        }


        // Retrieving a planner(s) from DB by user ID, store into planner model
        public List<Planner> GetPlannerByUserId(int userId)
        {
            List<Planner> plannerList = new List<Planner>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "SELECT u.user_id, username, planner_id, name, day, week, isSharable FROM planner as p JOIN users as u ON p.user_id = u.user_id WHERE p.user_id = @user_id"; 
                   // string sqlText = "SELECT r.planner_id, r.name, r.user_id, r.day, r.week, r.isSharable FROM planner as r JOIN recipes_planner as rp ON rp.planner_id = r.planner_id JOIN users as u ON r.user_id = u.user_id WHERE u.user_id = @user_id";


                    SqlCommand cmd = new SqlCommand(sqlText, conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);

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


        // POST method: add new meal plan

        public Planner AddMealPlan(string name, int user_id, string day, int week, bool isSharable)
        {
            Planner newMealPlan = new Planner();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sqlText = "INSERT INTO planner (name, user_id, day, week, isSharable) VALUES (@name, @user_id, @day, @week, @isSharable)";
                    SqlCommand cmd = new SqlCommand(sqlText, conn);

                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@user_id", user_id);
                    cmd.Parameters.AddWithValue("@day", day);
                    cmd.Parameters.AddWithValue("@week", week);
                    cmd.Parameters.AddWithValue("@isSharable", isSharable);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return newMealPlan;
        }







        // Mapping reader
        private Planner GetPlannerFromReader(SqlDataReader reader)
        {
            Planner myPlanner = new Planner();

            myPlanner.PlannerId = Convert.ToInt32(reader["planner_id"]);
            myPlanner.Name = Convert.ToString(reader["name"]);
            myPlanner.UserId = Convert.ToInt32(reader["user_id"]);  // causes an error when value is NULL so I commented it out
            myPlanner.Day = Convert.ToString(reader["day"]);
            myPlanner.Week = Convert.ToInt32(reader["week"]);
            myPlanner.IsSharable = Convert.ToBoolean(reader["isSharable"]);

            return myPlanner;

        }
        
    }
}
