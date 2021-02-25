using BlueBadge_Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge_Project.Models
{
    public enum FitRestrictions
    {
        LowImpact = 1,
        Asthma,
        HighBloodPressure,
        NoRestrictions
    }
    public class FitnessCreate
    {
        public int FitnessId { get; set; }

        [Required]
        public string Name { get; set; } //UserName? pull from AppicationUserData

        //[Required]
        //[MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        //public string FitnessDesc { get; set; }

        [Required]
        public bool WeightLoss { get; set; }

        [Required]
        public bool MuscleGain { get; set; }

        [Required]
        public bool Endurance { get; set; }



        [Required]
        public FitRestrictions FitnessRestrictions { get; set; }
    }
}
