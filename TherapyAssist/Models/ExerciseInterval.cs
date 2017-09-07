using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TherapyAssist.Models
{
    public class ExerciseInterval
    {
        [Key]
        public int ExerciseInterval_ID { get; set; }

        [Display(Name = "Repetitions")]
        public int Repetitions { get; set; }
        [Display(Name = "Times Per day")]
        public int TimesPerDay { get; set; }

        public int Exercise_ID { get; set; }
        public virtual Exercise exercise { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}