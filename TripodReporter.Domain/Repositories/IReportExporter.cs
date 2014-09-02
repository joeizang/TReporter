using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripodReporter.Domain.Repositories
{
    public interface IReportExporter
    {
        /// <summary>
        /// Takes values from any Data store and exports them into either excel or pdf
        /// </summary>
        void Export();
    }
}
