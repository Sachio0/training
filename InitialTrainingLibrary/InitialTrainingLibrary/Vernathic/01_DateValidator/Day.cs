﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialTrainingLibrary.Vernathic._01_DateValidator
{
    class Day
    {
        public static bool IsCorrectDay(int year, int month, int day)
        {
            if ((1 <= day) || (day <= Month.GetMonthLenght(year, month)))
                return true;
            else return false;
        }
    }
}