using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementWPF.Models
{
    public class OutlayEmployeeModel
    {
        public int id { get; set; }
        public int ObjectId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int Minutes { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
    }
}
