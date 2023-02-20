using System;
using System.Collections.Generic;

#nullable disable

namespace EfCoreIntroductionDemo.Model
{
    public partial class Passport
    {
        public Passport()
        {
            People = new HashSet<Person>();
        }

        public int PassportsId { get; set; }
        public string PassportNumber { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
