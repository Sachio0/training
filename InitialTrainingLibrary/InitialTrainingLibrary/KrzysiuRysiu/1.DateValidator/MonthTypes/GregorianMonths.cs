﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitialTrainingLibrary.KrzysiuRysiu._1.DateValidator.Interfaces;

namespace InitialTrainingLibrary.KrzysiuRysiu._1.DateValidator.MonthTypes
{
	class GregorianMonths : IMonthType
	{
		public bool ValidateMonth()
		{
			return true;
		}
	}
}