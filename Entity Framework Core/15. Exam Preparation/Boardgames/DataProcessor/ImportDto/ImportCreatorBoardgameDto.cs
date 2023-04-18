using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Boardgame")]
    public class ImportCreatorBoardgameDto
    {
        [Required]
        [XmlElement("Name")]
        [StringLength(20, MinimumLength = 10)]
        public string Name { get; set; }

        [Required]
        [XmlElement("Rating")]
        [Range(1, 10.00)]
        public double Rating { get; set; }

        [Required]
        [XmlElement("YearPublished")]
        [Range(2018, 2023)]
        public int YearPublished { get; set; }

        [Required]
        [XmlElement("CategoryType")]
        public int CategoryType { get; set; }

        [Required]
        [XmlElement("Mechanics")]
        public string Mechanics { get; set; }
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


//< Creators >
//    < Creator >
//        < FirstName > Debra </ FirstName >
//        < LastName > Edwards </ LastName >
//        < Boardgames >
//            < Boardgame >
//                < Name > 4 Gods </ Name >
//                < Rating > 7.28 </ Rating >
//                < YearPublished > 2017 </ YearPublished >
//                < CategoryType > 4 </ CategoryType >
//                < Mechanics > Area Majority / Influence, Hand Management, Set Collection, Simultaneous Action Selection, Worker Placement</Mechanics>
//			</Boardgame>
//			<Boardgame>
//				<Name>7 Steps</Name>
//				<Rating>7.01</Rating>
//				<YearPublished>2015</YearPublished>
//				<CategoryType>4</CategoryType>
//				<Mechanics>Action Queue, Hand Management, Push Your Luck, Set Collection</Mechanics>
//			</Boardgame>
//	     …
//		</Boardgames>
//	</Creator>
