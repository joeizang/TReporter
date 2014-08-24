using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripodReporter.Domain.Entities
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [Required]
        [Display(Name="Client Name")]
        public string ClientName { get; set; }
        public virtual ICollection<Policy> Policies { get; set; }

    }
}
