using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TherapyAssist.Models
{
    [Table("Therapist")]
    public class Therapist: UserDetail
    {
     

        public virtual List<Patient> Patients { get; set; }

        public string MedicalInstitutionName { get; set; }

    }
}