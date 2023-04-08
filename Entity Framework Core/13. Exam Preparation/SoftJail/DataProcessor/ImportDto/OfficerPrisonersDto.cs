using SoftJail.Data.Models.Enums;
using SoftJail.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class OfficerPrisonersDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        [XmlElement("Money")]
        public decimal Money { get; set; }

        [EnumDataType(typeof(Position))]
        [XmlElement("Position")]
        public string Position { get; set; }

        [EnumDataType(typeof(Weapon))]
        [XmlElement("Weapon")]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public PrisonerIdModel[] Prisoners { get; set; }
    }

    [XmlType("Prisoner")]
    public class PrisonerIdModel
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}

//< Officer >
//    < Name > Minerva Kitchingman </ Name >
//    < Money > 2582 </ Money >
//    < Position > Invalid </ Position >
//    < Weapon > ChainRifle </ Weapon >
//    < DepartmentId > 2 </ DepartmentId >
//    < Prisoners >
//        < Prisoner id = "15" />
//    </ Prisoners >
//</ Officer >
