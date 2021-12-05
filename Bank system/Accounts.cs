using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_system
{
    class Acounts
    {
        //fileids
        private long acountNumber;
        public double AcountBalance { get; set; }
        public bool Ttype { get; set; } // false = current
        public string WhatType { get; set; } 
        //private string whatType;
        public string OpenDate { get;} //property
 
        //constructor
        public Acounts(long acountNumber, bool type, string whatType)
        {
            Ttype = type;
            WhatType = whatType;
            AcountNumber = acountNumber;
            OpenDate = $"{DateTime.Today.Day}/{DateTime.Today.Month}/{DateTime.Today.Year}";
        }
        //property
        public long AcountNumber
        {
            get { return acountNumber; }
            set
            {
                if (value >= 2020101000)
                {
                    acountNumber = value;
                }
            }
        }
        //methods
        public void print()
        {
            Console.WriteLine("---------------------------------------\n");
            Console.WriteLine($"acount number : {acountNumber}");
            Console.WriteLine($"balance : {AcountBalance}");
            Console.WriteLine($"Type of acount : {WhatType}");
            Console.WriteLine($"date of open account : {OpenDate}");
            Console.WriteLine("---------------------------------------\n");

        }

    }

}
 