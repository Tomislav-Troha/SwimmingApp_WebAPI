﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.Abstract.Data
{
    public class TrainingDate
    {
        public int ID_TrainingDate { get; set; }
        public DateTime Dates { get; set; }
        public DateTime Time { get; set; }
        public int MemberID { get; set; }
        public int TrainingID { get; set; }
        public int UserID { get; set; }

    }
}
