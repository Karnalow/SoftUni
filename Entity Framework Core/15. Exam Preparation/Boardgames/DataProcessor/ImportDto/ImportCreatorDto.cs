using Boardgames.Data.Models.Enums;
using Boardgames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Creator")]
    public class ImportCreatorDto
    {
        [Required]
        [XmlElement("FirstName")]
        [StringLength(7, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [XmlElement("LastName")]
        [StringLength(7, MinimumLength = 2)]
        public string LastName { get; set; }

        [XmlElement("Boardgames")]
        public IEnumerable<ImportCreatorBoardgameDto> Boardgames { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	FirstName – text with length [2, 7] (required)
//•	LastName – text with length [2, 7] (required)
//•	Boardgames – collection of type Boardgame

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

