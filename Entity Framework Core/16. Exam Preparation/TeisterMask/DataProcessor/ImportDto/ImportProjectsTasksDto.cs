using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Task")]
    public class ImportProjectsTasksDto
    {
        [Required]
        [XmlElement("Name")]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }

        [Required]
        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [XmlElement("ExecutionType")]
        public int ExecutionType { get; set; }

        [XmlElement("LabelType")]
        public int LabelType { get; set; }
    }
    //•	Id – integer, Primary Key
    //•	Name – text with length [2, 40] (required)
    //•	OpenDate – date and time (required)
    //•	DueDate – date and time (required)
    //•	ExecutionType – enumeration of type ExecutionType, with possible values (ProductBacklog, SprintBacklog, InProgress, Finished) (required)
    //•	LabelType – enumeration of type LabelType, with possible values (Priority, CSharpAdvanced, JavaAdvanced, EntityFramework, Hibernate) (required)
    //•	ProjectId – integer, foreign key (required)
    //•	Project – Project 
    //•	EmployeesTasks – collection of type EmployeeTask


    //   < Task >
    //       < Name > Broadleaf </ Name >
    //       < OpenDate > 21 / 03 / 2018 </ OpenDate >
    //       < DueDate > 18 / 12 / 2018 </ DueDate >
    //       < ExecutionType > 0 </ ExecutionType >
    //       < LabelType > 2 </ LabelType >
    //     </ Task >
}
