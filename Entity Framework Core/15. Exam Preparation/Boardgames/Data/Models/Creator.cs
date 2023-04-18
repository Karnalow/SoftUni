using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data.Models
{
    public class Creator
    {
        public Creator()
        {
            this.Boardgames = new HashSet<Boardgame>();
        }

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public ICollection<Boardgame> Boardgames { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	FirstName – text with length [2, 7] (required)
//•	LastName – text with length [2, 7] (required)
//•	Boardgames – collection of type Boardgame

