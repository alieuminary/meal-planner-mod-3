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

        // retrieve a planner (by ID)
        //Planner GetPlannerById(int plannerId);
    }
}
