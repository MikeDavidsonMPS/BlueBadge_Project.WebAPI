﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge_Project.Models
{
    public enum PlanGoal
    {
        LooseWeight = 1,
        GainMuscleMass,
        BecomeHealthly,
        NoRestrictions
    }

    public class SystemPlanCreate
    {
        public int SysId { get; set; }

        [Required]
        [Range(85, 400)]
        public double StartingWeight { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "There are too many characters in this field.")]
        public string PlanGoal { get; set; }//does this need to be an Diet/Fitness==or enum
    }
}
