using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TherapyAssist.Models;

namespace TherapyAssist.ViewModels
{
    public class MyDayViewModel
    {
        public DailyLog DailyLog { get; set; }
        public List<ExerciseType> Types { get; set; }
        public bool isPhysicalTherapy { get; set; }
        public bool isOccupationalTherapy { get; set; }
        public bool isSpeechTherapy { get; set; }

        public MyDayViewModel(DailyLog log)
        {
            DailyLog = log;
            isOccupationalTherapy = DailyLog.Patient.isOccupationalTherapy;
            isPhysicalTherapy = DailyLog.Patient.isPhysicalTherapy;
            isSpeechTherapy = DailyLog.Patient.isSpeechTherapy;
            Types = new List<ExerciseType>();



        }
    }
}