﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.ImportDto
{
    public class ImportGameDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string Genre { get; set; }

        public string[] Tags { get; set; }
    }

    //•	Id – integer, Primary Key
    //•	Name – text (required)
    //•	Price – decimal (non-negative, minimum value: 0) (required)
    //•	ReleaseDate – Date (required)
    //•	DeveloperId – integer, foreign key (required)
    //•	Developer – the game's developer (required)
    //•	GenreId – integer, foreign key (required)
    //•	Genre – the game's genre (required)
    //•	Purchases - collection of type Purchase
    //•	GameTags - collection of type GameTag. Each game must have at least one tag.
}

//"Name": "Dota 2",
//		"Price": 0,
//		"ReleaseDate": "2013-07-09",
//		"Developer": "Valve",
//		"Genre": "Action",
//		"Tags": [
//			"Multi-player",
//			"Co-op",
//			"Steam Trading Cards",
//			"Steam Workshop",
//			"SteamVR Collectibles",
//			"In-App Purchases",
//			"Valve Anti-Cheat enabled"
//		]