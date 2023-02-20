using System;
using System.Collections.Generic;

#nullable disable

namespace EfCoreIntroductionDemo.Model
{
    public partial class Manufacture
    {
        public Manufacture()
        {
            Models = new HashSet<Model>();
        }

        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public DateTime? EstablishedOn { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}
