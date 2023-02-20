using System;
using System.Collections.Generic;

#nullable disable

namespace EfCoreIntroductionDemo.Model
{
    public partial class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public decimal? Salary { get; set; }
        public int? PassportId { get; set; }

        public virtual Passport Passport { get; set; }
    }
}
