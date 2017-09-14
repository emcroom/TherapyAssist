using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TherapyAssist.Models
{
    public class Therapist: UserDetail
    {
        [Key]
        public int Therapist_ID { get; set; }

        public virtual List<Patient> Patients { get; set; }

        public string MedicalInstitutionName { get; set; }

    }
}