﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.TraininigLibrary.Developers.Duch.DuchOmr.DuchInterfaces
{
	 public interface IDuchRider
	{
		string GetRiderType();
		string RiderType { get; set; }
		string WhatAmIRiding();
	}
}