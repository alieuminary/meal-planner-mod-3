using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Planner
    {
        public int PlannerId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public bool IsSharable { get; set; }
    }
}
