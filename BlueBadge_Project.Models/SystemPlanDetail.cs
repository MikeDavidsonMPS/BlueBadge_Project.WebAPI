using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge_Project.Models
{
    public class SystemPlanDetail
    {
        public int SystemPlanId { get; set; }

        public double StartingWeight { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public string SystemPlanGoal { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
