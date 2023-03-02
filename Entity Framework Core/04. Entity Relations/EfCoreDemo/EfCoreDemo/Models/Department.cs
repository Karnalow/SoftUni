using System.Collections;
using System.Collections.Generic;

namespace EfCoreDemo.Models
{
    public class Department
    {
        public Department()
        {
            this.Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        //Optional - inverse property
        public ICollection<Employee> Employees { get; set; }
    }
}
