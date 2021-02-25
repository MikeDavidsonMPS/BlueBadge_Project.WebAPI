using BlueBadge_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge_Project.Models
{
    public class FitnessEdit
    {
        public int FitnessId { get; set; }
        public string Name { get; set; }
        //public string FitnessDesc { get; set; }
        public bool WeightLoss { get; set; }
        public bool MuscleGain { get; set; }
        public bool Endurance { get; set; }
        public FitRestrictions FitnessRestriction { get; set; }

    }
}
