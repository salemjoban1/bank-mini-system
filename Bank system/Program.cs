using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;

namespace Bank_system
{
    class Program
    {
        static void Main(string[] args)
        {
            mainInterface:
            try {
                while (true)
                {
                    Console.WriteLine("\n========= Weclonme to system bank ========== ");

                    Console.WriteLine("(1) add client");
                    Console.WriteLine("(2) add new account");
                    Console.WriteLine("(3) deposit");
                    Console.WriteLine("(4) withdrow");
                    Console.WriteLine("(5) transfer");
                    Console.WriteLine("(6) search Client");
                    Console.WriteLine("(7) search Account");

                    Console.WriteLine("(8) desplay clients");
                    Console.WriteLine("(9) desplay accounts");
                    Console.WriteLine("(10) close account");
                    Console.WriteLine("(11) account open at time");

                    Console.WriteLine("(12) exit\n");

                    Console.Write("choose number: ");
                    string choose = Console.ReadLine();

                    if (choose == "1")
                    {
                        // add client 
                        System.AddClient();
                        Console.WriteLine("_____________________________");
                    }
                    else if (choose == "2")
                    {
                        // add new account
                        System.OpenNewAcount();
                    }
                    else if (choose == "3")
                    {
                        Console.WriteLine("Enter id account");
                        long inputId = Convert.ToInt64(Console.ReadLine());
                        Console.WriteLine("Enter money");
                        double money = Convert.ToDouble(Console.ReadLine());
                        if (money < 0)
                        {
                            Console.WriteLine("can not deposit negitive money value");
                            goto mainInterface;
                        }
                        else
                        {
                            System.Deposit(inputId, money);
                        }
                    }
                    else if (choose == "4")
                    {
                        Console.WriteLine("enter id account");
                        long inputId = Convert.ToInt64(Console.ReadLine());
                        System.Withdrow(inputId);

                    }
                    else if (choose == "5")
                    {
                        System.Transfer();
                    }
                    else if (choose == "6")
                    {
                        //search client
                        Console.WriteLine("enter id client");
                        long id = Convert.ToInt64(Console.ReadLine());
                        if (System.SearchClient(id) == null) { Console.WriteLine("Clients not exsist"); }
                        else { System.SearchClient(id).printInfo(); }
                    }
                    else if (choose == "7")
                    {
                        // search account
                        Console.WriteLine("enter id account");
                        long id = Convert.ToInt64(Console.ReadLine());

                        if (System.SearchAccount(id) == null) { Console.WriteLine("account not exsist"); }
                        else { System.SearchAccount(id).print(); }
                    }
                    else if (choose == "8")
                    {
                        System.DesplayClients();
                    }
                    else if (choose == "9")
                    {
                        System.DesplayAccount();
                    }
                    else if (choose == "10")
                    {
                        System.closeAccount();
                    }
                    else if (choose == "11")
                    {
                        System.AccountAtDate();
                    }
                    else if (choose == "12")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong choice!!");

                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong Input Format");
                //go to main interface
                goto mainInterface;
            }
        }
    }
    
}





