﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.TraininigLibrary.Developers.R4D3K.OMR.Employee;
using Toci.TraininigLibrary.Developers.R4D3K.OMR.Interfaces;

namespace Toci.TraininigLibrary.Developers.R4D3K.OMR.Abstract_Class
{
    public abstract class EmployeeBase : IEmployee
    {
        protected int Id { get; set; }
        protected string FirstName { get; set; }
        protected string LastName { get; set; }
        protected KindOfJob Position { get; set; }
        //protected int WorkingHours { get; set; }

        protected EmployeeBase(int id,string firstname,string lastname, KindOfJob position)
        {

        }

        public double GetSalary(KindOfJob koj, int workingHours)
        {
            switch (koj)
            {
                case KindOfJob.Chef:
                    return workingHours * 50;
                    break;
                case KindOfJob.Cook:
                    return workingHours * 30;
                    break;
                case KindOfJob.Menager:
                    return workingHours * 60;
                    break;
                case KindOfJob.Waiter:
                    return workingHours * 10;
                    break;
                case KindOfJob.Barman:
                    return workingHours * 21;
                    break;
            }
            return 0;
        }
    }
}
