using Boardgames.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data.Models
{
    public class Boardgame
    {
        public Boardgame()
        {
            this.BoardgamesSellers = new HashSet<BoardgameSeller>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Rating { get; set; }

        [Required]
        public int YearPublished { get; set; }

        [Required]
        public CategoryType CategoryType { get; set; }

        [Required]
        public string Mechanics { get; set; }

        [Required]
        public int CreatorId { get; set; }

        public Creator Creator { get; set; }

        public ICollection<BoardgameSeller> BoardgamesSellers  { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	Name – text with length [10…20] (required)
//•	Rating – double in range [1…10.00] (required)
//•	YearPublished – integer in range [2018…2023] (required)
//•	CategoryType – enumeration of type CategoryType, with possible values (Abstract, Children, Family, Party, Strategy) (required)
//•	Mechanics – text (string, not an array) (required)
//•	CreatorId – integer, foreign key (required)
//•	Creator – Creator
//•	BoardgamesSellers – collection of type BoardgameSeller

