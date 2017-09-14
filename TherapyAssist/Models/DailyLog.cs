using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TherapyAssist.Models
{
    public class DailyLog
    {
        [Key]
        public int DailyLog_ID { get; set; }

        public int User_ID { get; set; }
        public virtual UserDetail UserDetail { get; set; }

        public virtual List<ExerciseInterval> Exercises { get; set; }


        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

    }
}