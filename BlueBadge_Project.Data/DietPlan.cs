﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge_Project.Data
{
    public enum DietRestrictions
    {
        Sugar = 1,
        Gluten,
        Carbs,
        NoRestrictions

    }
    public class DietPlan

    {
        [Key]
        public int DietId { get; set; }

        [Required]
        public string Name { get; set; }

        //[Required]
       // public string DietDesc { get; set; }

        [Required]
        public bool BalancedDiet { get; set; }

        [Required]
        public bool Protein { get; set; }

        [Required]
        public bool Vegatarian { get; set; }

        [Required]
        public bool Carbo { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        public DietRestrictions DietaryRestrictions { get; set; }

    }
}
