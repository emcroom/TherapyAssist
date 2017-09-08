using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TherapyAssist.Models
{
    public class UserDetail
    {
        [Key]
        public int User_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool isPatient { get; set; }
        public bool isTherapist { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}