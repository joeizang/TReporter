using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripodReporter.Domain.Entities
{
    public class Insurer
    {
        [Key]
        public int InsurerId { get; set; }
        [Required]
        [Display(Name="Insurer Name")]
        public string Name { get; set; }
        public virtual ICollection<Policy> Policies { get; set; }

    }
}
