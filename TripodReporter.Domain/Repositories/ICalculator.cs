using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripodReporter.Domain.Repositories
{
    public interface ICalculator
    {
        double CalculateComission(); //should it take parameters to calculate?
        double CalculateNetPremium();
    }
}
