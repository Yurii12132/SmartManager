using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementWPF.Models
{
    public class ObjectModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime CloseDate { get; set; }
    }
}
