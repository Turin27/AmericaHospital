using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmericaHospital.Models.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}
