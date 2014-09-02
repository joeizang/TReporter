using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripodReporter.Domain.Repositories
{
    public interface IEmailer
    {
        /// <summary>
        /// Sends an email with either an excel or pdf document as an attachment to any specified user
        /// </summary>
        /// <returns>return true if sending was successful or false if it fails</returns>
        bool SendEmail();
    }
}
