using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TherapyAssist.Models
{
    public class Exercise
    {
        [Key]
        public int Exercise_ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int ExerciseType_ID { get; set; }
        public virtual ExerciseType Type { get; set; }

        public virtual List<Equipment> EquipmentList { get; set; }


        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }


    }
}