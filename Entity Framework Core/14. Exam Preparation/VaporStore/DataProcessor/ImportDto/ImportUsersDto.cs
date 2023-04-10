﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaporStore.DataProcessor.ImportDto
{
    public class ImportUsersDto
    {
        [Required]
        [RegularExpression("^(([A-Z]{1}[a-z]+)\\s([A-Z]{1}[a-z]+))")]
        public string FullName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Range(3, 103)]
        public int Age { get; set; }

        public IEnumerable<CardsInputModel> Cards { get; set; }
    }

    //•	Id – integer, Primary Key
    //•	Username – text with length [3, 20] (required)
    //•	FullName – text, which has two words, consisting of Latin letters. Both start with an upper letter and are followed by lower letters. The two words are separated by a single space (ex. "John Smith") (required)
    //•	Email – text (required)
    //•	Age – integer in the range [3, 103] (required)
    //•	Cards – collection of type Card

    public class CardsInputModel
    {
        [Required]
        [RegularExpression("^((\\d{4})\\s(\\d{4})\\s(\\d{4})\\s(\\d{4}))$")]
        public string Number { get; set; }

        [Required]
        [RegularExpression("^(\\d{3})$")]
        public string Cvc { get; set; }

        [Required]
        public string Type { get; set; }
    }

    //•	Id – integer, Primary Key
    //•	Number – text, which consists of 4 pairs of 4 digits, separated by spaces (ex. "1234 5678 9012 3456") (required)
    //•	Cvc – text, which consists of 3 digits (ex. "123") (required)
    //•	Type – enumeration of type CardType, with possible values ("Debit", "Credit") (required)
    //•	UserId – integer, foreign key (required)
    //•	User – the card's user (required)
    //•	Purchases – collection of type Purchase
}

//"FullName": "Invalid Invalidman",
//		"Username": "",
//		"Email": "invalid@invalid.com",
//		"Age": 20,
//		"Cards": [
//			{
//				"Number": "1111 1111 1111 1111",
//				"CVC": "111",
//				"Type": "Debit"
//			}
//		]
