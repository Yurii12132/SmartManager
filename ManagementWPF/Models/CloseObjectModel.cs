using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementWPF.Models
{
    public class CloseObjectModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string DatePeriod { get; set; }
        public double Payout { get; set; }
        public double Outlay { get; set; }
        public double Income { get; set; }
    }
}
