using System;
using System.Collections.Generic;

#nullable disable

namespace EfCoreIntroductionDemo.Model
{
    public partial class Teacher
    {
        public Teacher()
        {
            InverseManager = new HashSet<Teacher>();
        }

        public int TeacherId { get; set; }
        public string Name { get; set; }
        public int? ManagerId { get; set; }

        public virtual Teacher Manager { get; set; }
        public virtual ICollection<Teacher> InverseManager { get; set; }
    }
}
