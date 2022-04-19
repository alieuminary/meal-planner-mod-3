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
    public class PlannerController : ControllerBase
    {
        private readonly IPlannerDao plannerDao;

        public PlannerController(IPlannerDao plannerDao)
        {
            this.plannerDao = plannerDao;
        }


        [HttpGet()]

        public ActionResult<List<Planner>> GetAllPlanners()
        {
            List<Planner> planners = plannerDao.GetAllPlanners();

            if (planners != null)
            {
                return Ok(planners);
            }
            else
            {
                return BadRequest();
            }
        }
        
    }
}
