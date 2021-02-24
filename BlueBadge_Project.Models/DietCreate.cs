using BlueBadge_Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge_Project.Models
{
    public class DietCreate
    {
        [Required]
        public string Name { get; set; } //UserName? pull from AppicationUserData

        [Required]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string DietDesc { get; set; }

        [Required]
        public bool BalancedDiet { get; set; }

        [Required]
        public bool Protein { get; set; }

        [Required]
        public bool Vegatarian { get; set; }

        [Required]
        public bool Carbo { get; set; }

        [Required]
        public DietRestrictions DietaryRestrictions { get; set; }

    }
}
