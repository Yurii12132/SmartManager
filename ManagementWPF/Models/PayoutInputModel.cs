using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementWPF.Models
{
    public class PayoutInputModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public byte[] File { get; set; }
        public DateTime Date { get; set; }
    }
}
