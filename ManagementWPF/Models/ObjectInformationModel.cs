using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementWPF.Models
{
    public class ObjectInformationModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public List<FileModel> Documents { get; set; }
        public List<FileModel> Images { get; set; }
        public List<EmployeeModel> Employees { get; set; }
    }
}
