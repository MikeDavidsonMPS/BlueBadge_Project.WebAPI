﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge_Project.Data
{
    public enum PlanGoal
    {
        LooseWeight = 1,
        GainMuscleMass,
        BecomeHealthly,
        NoRestrictions
    }
    public class SystemPlan
    {
        [Key]
        public int SysId { get; set; }

        //[Required]
        //public string Name { get; set; } //Not is the ProjectWireFrame

        [ForeignKey(nameof(UserId))]
        public Guid UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey(nameof(FitnessPlan))]
        public Guid FitnessId { get; set; }
        public virtual FitnessPlan FitnessPlan { get; set; }

        [ForeignKey(nameof(DietPlan))]
        public Guid DietId { get; set; }

        [Required]
        public virtual DietPlan DietPlan { get; set; }


        [Required]
        public string PlanGoal { get; set; }

        [Required, Range(85, 400)]
        public double StartingWeight { get; set; }


        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        [Required]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
