﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeisterMask.Data.Models;

namespace TeisterMask.Data.Models
{
    public class EmployeeTask
    {
        [Required]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Required]
        public int TaskId { get; set; }

        public Task Task { get; set; }
    }
}
//•	EmployeeId – integer, Primary Key, foreign key (required)
//•	Employee – Employee
//•	TaskId – integer, Primary Key, foreign key (required)
//•	Task – Task

