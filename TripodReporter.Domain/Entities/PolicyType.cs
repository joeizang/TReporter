using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripodReporter.Domain.Entities
{
    public enum PolicyType
    {
        [Display(Name="All Risk")]
        AllRisk = 1,
        Burgulary = 2,
        [Display(Name="Contractors All Risk")]
        ContractorsAllRisk = 3,
        Engineering = 4,
        Fire = 5,
        [Display(Name="Goods In Transit")]
        GoodsInTransit = 6,
        [Display(Name="Group Life")]
        GroupLife = 7,
        [Display(Name="House Holders")]
        HouseHolders = 8,
        Marine = 9,
        [Display(Name="Money Insurance")]
        MoneyInsurance = 10,
        Motor = 11,
        [Display(Name="Personal Accident")]
        PersonalAccident = 12,
        [Display(Name="Public/Product Liability")]
        PublicProductLiability = 13,
        [Display(Name="Workmen's Compensation")]
        WorkMensCompensation = 14


    }
}
