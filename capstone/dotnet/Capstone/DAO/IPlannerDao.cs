using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;


namespace Capstone.DAO
{
    public interface IPlannerDao
    {
        // List of all planners
        List<Planner> GetAllPlanners();

        // Display specific planner by Planner Id
        Planner GetPlannerByPlannerId(int plannerId);


        // retrieve a planner by (user_id)
        List<Planner> GetPlannerByUserId(int userId);

        // Add/Create a meal plan
        Planner AddMealPlan(string name, int user_id, string day, int week, bool isSharable);


    }
}
