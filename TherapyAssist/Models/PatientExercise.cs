using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TherapyAssist.Models
{
    public class PatientExercise
    {
        [Key]
        public int PatientExercise_ID { get; set; }

        public int ExerciseInterval_ID { get; set; }
        public virtual ExerciseInterval ExerciseInterval { get; set; }

        public int Patient_ID { get; set; }
        public virtual Patient Patient { get; set; }

        public bool isComplete { get; set; } = false;
        public DateTime CompletedDateTime { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}