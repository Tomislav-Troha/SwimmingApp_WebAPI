﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.Abstract.Data
{
    public class Attendance
    {
        public int Id { get; set; }
        public string AttDesc { get; set; }
        public string Type { get; set; }
        public int MemberID { get; set; }
        public int TrainingID { get; set; }
        public int UserID { get; set; }
    }
}