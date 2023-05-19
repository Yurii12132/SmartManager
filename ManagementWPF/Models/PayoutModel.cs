using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementWPF.Models
{
    public class PayoutModel
    {
        public int id { get; set; }
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int? FileId { get; set; }
        public DateTime Date { get; set; }
    }
}
