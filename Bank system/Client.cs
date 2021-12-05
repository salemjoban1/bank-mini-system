using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_system
{
    class Client
    {
        //fields
        private string name;
        private long id;
        public string Job { get; set;}
        private long phoneNumber;
        public string Address { get; set; }
        public bool HasCurrent { get; set; }
        public bool HasBusiness { get; set; }
        private long currentNumber;
        private long businessNumber;
        //constructor
        public Client(string name, long id, string job, long phoneNumber, string address)
        {
            Name = name.Trim();
            Id = id;
            Job = job.Trim();
            PhoneNumber = phoneNumber;
            Address = address.Trim();
            HasCurrent = false;
            HasBusiness = false;
        }

        //property
        public string Name
        {

            get { return name; }
            set { name = value; }
        }
        public long Id
        {
            get { return id; }
            set
            {
                if (value >= 20201000)
                {
                    id = value;
                }
                else
                {
                    Console.WriteLine("id must be equal or more than 20201000");
                }
            }
        }
        public long PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (value > 0)
                {
                    phoneNumber = value;
                }
                else
                {
                    Console.WriteLine("Wrong phone number");
                }
            }
        }

        public long CurrentNumber
        {
            get { return currentNumber; }
            set
            {
                if (value >= 2020101000)
                    currentNumber = value;
            }
        }
        public long BusinessNumber
        {
            get { return businessNumber; }
            set
            {
                if (value >= 2020101000)
                    businessNumber = value;
            }
        }

        //methods
        public void printInfo()
        {
            
            Console.WriteLine("---------------------------------------\n");
            Console.WriteLine($"Client name: {name}");
            Console.WriteLine($"Client id: {id}");
            Console.WriteLine($"Client job: {Job}");
            Console.WriteLine($"Client phone number: {phoneNumber}");
            Console.WriteLine($"Client adress: {Address}");
            

            if (HasCurrent == true && HasBusiness == true)
            {
                Console.WriteLine($"Client has current acount with number: {currentNumber}");
                Console.WriteLine($"Client has Business acount with number: {businessNumber}");
            }
            else if (HasCurrent == true)
            {
                Console.WriteLine($"Client has current acount with number: {currentNumber}");
            }
            else if (HasBusiness == true)
            {
                Console.WriteLine($"Client has current acount with number: {businessNumber}");
            }


            Console.WriteLine("---------------------------------------\n");
        }


    }

}
