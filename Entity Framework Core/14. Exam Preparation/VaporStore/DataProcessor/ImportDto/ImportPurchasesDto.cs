using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.ImportDto
{
    [XmlType("Purchase")]
    public class ImportPurchasesDto
    {
        [Required]
        [XmlElement("Type")]
        public string PurchaseType { get; set; }

        [Required]
        [XmlElement("Key")]
        [RegularExpression("^((([A-Z0-9]){4})\\-(([A-Z0-9]){4})\\-(([A-Z0-9]){4}))$")]
        public string Key { get; set; }

        [Required]
        [XmlElement("Date")]
        public string Date { get; set; }

        [Required]
        [XmlElement("Card")]
        [RegularExpression("^((\\d{4})\\s(\\d{4})\\s(\\d{4})\\s(\\d{4}))$")]
        public string CardNumber { get; set; }

        [Required]
        [XmlElement("title")]
        public string GameTitle { get; set; }
    }

    //•	Id – integer, Primary Key
    //•	Type – enumeration of type PurchaseType, with possible values ("Retail", "Digital") (required)
    //•	ProductKey – text, which consists of 3 pairs of 4 uppercase Latin letters and digits, separated by dashes (ex. "ABCD-EFGH-1J3L") (required)
    //•	Date – Date (required)
    //•	CardId – integer, foreign key (required)
    //•	Card – the purchase's card (required)
    //•	GameId – integer, foreign key (required)
    //•	Game – the purchase's game (required)


    //  <Purchases>
    //<Purchase title = "Dungeon Warfare 2" >
    //  < Type > Digital </ Type >
    //  < Key > ZTZ3 - 0D2S-G4TJ</Key>
    //  <Card>1833 5024 0553 6211</Card>
    //  <Date>07/12/2016 05:49</Date>
    //</Purchase>
}
