using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TeisterMask.Data.Models.Enums;
using TeisterMask.Data.Models;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ImportProjectsDto
    {
        [Required]
        [XmlElement("Name")]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [XmlArray("Tasks")]
        public ImportProjectsTasksDto[] Tasks { get; set; }

    }
    //•	Id – integer, Primary Key
    //•	Name – text with length [2, 40] (required)
    //•	OpenDate – date and time (required)
    //•	DueDate – date and time (can be null)
    //•	Tasks – collection of type Task

}
//< Project >
//   < Name > Hyster - Yale </ Name >
//   < OpenDate > 05 / 02 / 2018 </ OpenDate >
//   < DueDate />
//   < Tasks >
//     < Task >
//       < Name > Broadleaf </ Name >
//       < OpenDate > 21 / 03 / 2018 </ OpenDate >
//       < DueDate > 18 / 12 / 2018 </ DueDate >
//       < ExecutionType > 0 </ ExecutionType >
//       < LabelType > 2 </ LabelType >
//     </ Task >
//     < Task >
//       < Name > Cornflag </ Name >
//       < OpenDate > 27 / 09 / 2018 </ OpenDate >
//       < DueDate > 25 / 09 / 2019 </ DueDate >
//       < ExecutionType > 1 </ ExecutionType >
//       < LabelType > 1 </ LabelType >
//     </ Task >
//     < Task >
//       < Name > Debeque </ Name >
//       < OpenDate > 17 / 10 / 2018 </ OpenDate >
//       < DueDate > 25 / 01 / 2019 </ DueDate >
//       < ExecutionType > 3 </ ExecutionType >
//       < LabelType > 2 </ LabelType >
//     </ Task >
//     < Task >
//       < Name > Bryum </ Name >
//       < OpenDate > 02 / 11 / 2018 </ OpenDate >
//       < DueDate > 19 / 01 / 2019 </ DueDate >
//       < ExecutionType > 0 </ ExecutionType >
//       < LabelType > 3 </ LabelType >
//     </ Task >
//     < Task >
//       < Name > Pacific </ Name >
//       < OpenDate > 14 / 05 / 2018 </ OpenDate >
//       < DueDate > 05 / 07 / 2019 </ DueDate >
//       < ExecutionType > 3 </ ExecutionType >
//       < LabelType > 0 </ LabelType >
//     </ Task >
//     < Task >
//       < Name > Guadalupe </ Name >
//       < OpenDate > 29 / 09 / 2018 </ OpenDate >
//       < DueDate > 23 / 12 / 2018 </ DueDate >
//       < ExecutionType > 0 </ ExecutionType >
//       < LabelType > 2 </ LabelType >
//     </ Task >
//     < Task >
//       < Name > Crandall </ Name >
//       < OpenDate > 12 / 03 / 2018 </ OpenDate >
//       < DueDate > 21 / 02 / 2019 </ DueDate >
//       < ExecutionType > 2 </ ExecutionType >
//       < LabelType > 0 </ LabelType >
//     </ Task >
//     < Task >
//       < Name > Longbract Pohlia Moss</Name>
//       <OpenDate>13/09/2018</OpenDate>
//       <DueDate>29/03/2019</DueDate>
//       <ExecutionType>2</ExecutionType>
//       <LabelType>3</LabelType>
//     </Task>
//     <Task>
//       <Name>Guadeloupe</Name>
//       <OpenDate>14/02/2018</OpenDate>
//       <DueDate>09/02/2019</DueDate>
//       <ExecutionType>1</ExecutionType>
//       <LabelType>2</LabelType>
//     </Task>
//     <Task>
//       <Name>Meyen's Sedge</Name>
//       <OpenDate>09/10/2018</OpenDate>
//       <DueDate>05/05/2019</DueDate>
//       <ExecutionType>0</ExecutionType>
//       <LabelType>3</LabelType>
//     </Task>
//   </Tasks>
// </Project>
