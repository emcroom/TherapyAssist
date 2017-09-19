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
        public DateTime MyDate { get; set; }
        public int User_ID { get; set; }
        public virtual Patient Patient { get; set; }

        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }

    }
}