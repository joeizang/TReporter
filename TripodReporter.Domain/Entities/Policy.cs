using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripodReporter.Domain.Entities
{
    public class Policy
    {
        [Key]
        public int PolicyId { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        [Display(Name="Policy Number")]
        public string PolicyNumber { get; set; }
        public int InsurerId { get; set; }
        public virtual Insurer Insurer { get; set; }

        [EnumDataType(typeof(PolicyDetails))]
        [Display(Name="Policy Details")]
        public PolicyDetails PolicyDetails { get; set; } //Custom Enum that holds different details for every policy

        [EnumDataType(typeof(PolicyType))]
        [Display(Name="Policy Type")]
        public PolicyType PolicyType { get; set; } //Custom Enum that holds the different types of Policies

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:d}")]
        public DateTime PolicyDate { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal PolicyValue { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal PremiumPaid { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Comission { get; set; }

    }
}
