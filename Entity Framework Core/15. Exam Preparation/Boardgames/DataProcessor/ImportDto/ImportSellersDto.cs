using Boardgames.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.DataProcessor.ImportDto
{
    public class ImportSellersDto
    {
        [Required]
        [StringLength(20 , MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Address { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        [RegularExpression(@"(www\.[a-zA-Z0-9\-]{2,256}\.com)")]
        public string Website { get; set; }

        public int[] Boardgames { get; set; }
    }

    //•	Id – integer, Primary Key
    //•	Name – text with length [5…20] (required)
    //•	Address – text with length [2…30] (required)
    //•	Country – text (required)
    //•	Website – a string (required). First four characters are "www.", followed by upper and lower letters, digits or '-' and the last three characters are ".com".
    //•	BoardgamesSellers – collection of type BoardgameSeller
}

//{
//    "Name": "EPFamily Direct",
//    "Address": "6620 Donec St., 12893",
//    "Country": "France",
//	  "Website": "www.epfamily direct.com",
//    "Boardgames": [

//            100,
//			66,
//			78,
//			95,
//			41,
//			98,
//			55,
//			100
//    ]
//  },
