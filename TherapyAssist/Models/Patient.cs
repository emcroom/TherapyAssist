using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TherapyAssist.Models
{
    public class Patient: UserDetail
    {
        [Key]
        public int Pateint_ID { get; set; }
        
        public virtual List<PatientExercise> PatientExercises { get; set; }
        public virtual List<Therapist> Therapists { get; set; }

        public bool isPhysicalTherapy { get; set; }
        public bool isOccupationalTherapy { get; set; }
        public bool isSpeechTherapy { get; set; }


    }
}