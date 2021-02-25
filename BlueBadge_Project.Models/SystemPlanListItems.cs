﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge_Project.Models
{
    public class SystemPlanListItems
    {
        private int SysPlanId { get; set; }

        public int _userId { get; set; }

        public double StartingWeight { get; set; }

        public string PlanGoal { get; set; } //does this need to be an Diet/Fitness==or enum

        //[Required]
        //public DateTimeOffset CreatedUtc { get; set; }

        //[Display(Name = "Created")]
        //public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
