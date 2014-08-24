using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripodReporter.Domain.Entities
{
    public enum PolicyDetails
    {
        NewPolicy,
        Renewal,
        OpenCover,
        Adjustment
    }

    public enum PolicyType
    {
        WorkmensCompensation,
        Fire,
        Theft,
        Burgulary,
        GroupLife,
        MarineOpenCover,
        MotorVehicle
    }
}
