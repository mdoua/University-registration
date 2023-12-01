using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityRegistration.Models
{
    internal class Assistant : Teacher
    {
        public int IdSupervisor { get; set; }

    }
}
