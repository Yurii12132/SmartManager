using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementWPF.Models
{
    public class EmployeeModel
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Specialization { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Salary { get; set; }
        private string _image;
        public string Image { get
            {
                return String.IsNullOrWhiteSpace(_image) ? "/Images/imageNULLworker.jpg" : _image;
            }
            set
            {
                this._image = value;
            }
        }
        public string Resume { get; set; }
        public string DetailInformation { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Education { get; set; }
        public string Recidence { get; set; }
        public string Seniority { get; set; }
        public int ObjectId { get; set; }
    }
}
