using System;
using System.Collections.Generic;

#nullable disable

namespace EfCoreIntroductionDemo.Model
{
    public partial class Model
    {
        public int ModelId { get; set; }
        public string Name { get; set; }
        public int ManufactuderId { get; set; }

        public virtual Manufacture Manufactuder { get; set; }
    }
}
