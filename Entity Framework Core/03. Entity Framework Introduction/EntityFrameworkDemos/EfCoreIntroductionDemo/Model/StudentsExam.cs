using System;
using System.Collections.Generic;

#nullable disable

namespace EfCoreIntroductionDemo.Model
{
    public partial class StudentsExam
    {
        public int StudentId { get; set; }
        public int ExamId { get; set; }

        public virtual Exam Exam { get; set; }
        public virtual Student Student { get; set; }
    }
}
