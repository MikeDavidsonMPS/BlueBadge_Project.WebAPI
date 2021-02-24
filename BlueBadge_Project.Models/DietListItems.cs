using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge_Project.Models
{
    public class DietListItems
    {
        public int DietId { get; set; }

        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Description")]
        public string DietDesc { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
