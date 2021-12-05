using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_system
{
    static class System
    {
        //Fields
        public static ArrayList clientList;
        public static ArrayList acountsList;
        private static long id;
        private static long acountNumber;

        //constructor
        static System()
        {
            id = 20201000;
            acountNumber = 2020101000;
            clientList = new ArrayList();
            acountsList = new ArrayList();
        }

        //methods

        //helping method
        public static bool IsClientExist(long id)
        {
            foreach (Client client in clientList)
            {
                if (client.Id == id)
                {
                    return true;
                }

            }
            return false;
        }
        //show acount information after its been created
        private static void ShowAcountCard(Client client)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("====>  Card Acount information  <=======");
            Console.WriteLine($"Client name : {client.Name}");
            Console.WriteLine($"Client id: {client.Id}");

            if (client.HasCurrent == true && client.HasBusiness == true)
            {
                Console.WriteLine($"Client Current acount number : {client.CurrentNumber}");
                Console.WriteLine($"Client Business acount number : {client.BusinessNumber}");
            }
            else if (client.HasCurrent == true)
            {
                Console.WriteLine($"Client Current acount number : {client.CurrentNumber}");
            }
            else if (client.HasBusiness == true)
            {
                Console.WriteLine($"Client Business acount number : {client.BusinessNumber}");
            }
            Console.WriteLine("------------------------------------");
        }
        //method to add acount and link it with client
        private static void Addaccount(Client client,long acountId, bool check)
        {
            //if it's bussness account 
            if (check== true) 
            {
                //creat new object of acount
                Acounts business = new Acounts(acountId, check, "Business Account");
                //add acount obj to acount array list 
                acountsList.Add(business);
                //update busness number in client obj with acount number  
                client.BusinessNumber = business.AcountNumber;
                //change has bussiness bool in client (to easy check how many acounts has)
                client.HasBusiness = true;
                //increase acount number in system with one
                acountNumber++;
                Console.WriteLine("add business account done");
            }
            //current account
            else
            {
                //creat new object of acount
                Acounts current = new Acounts(acountId, check, "Current Acount");
                //add acount obj to acount array list 
                acountsList.Add(current);
                //update current number in client obj with acount number
                client.CurrentNumber = current.AcountNumber;
                //change has current bool in client (to easy check how many acounts has)
                client.HasCurrent = true;
                //increase acount number in system with one
                acountNumber++;
                Console.WriteLine("add current account done");
            }
            
        }
        //main methods

        //add client method
        public static void AddClient()
        {
            //read info from user
            Console.Write("name of client: ");
            string name = Console.ReadLine();
            Console.Write("client job : ");
            string job = Console.ReadLine();
            Console.Write("client phone number : ");
            long phoneNumber = Convert.ToInt64(Console.ReadLine());
            Console.Write("client address : ");
            string address = Console.ReadLine();

            // Creat acount for Client
            while (true)
            {
                Console.Write("Choose the type of acount you want to creat{ ");
                Console.Write("{ C } for Current acount , { B } for bussness acount: ");
                char choice = Convert.ToChar(Console.ReadLine()); 
               
                if (char.ToUpper(choice) == 'C')
                {
                    //creat new client object and store it's data
                    Client Client = new Client(name, id, job, phoneNumber, address);
                    //add account and link it to client
                    Addaccount(Client,acountNumber,false);
                    //add client object to client array list
                    clientList.Add(Client);
                    //increase id client by one to the next comming client
                    id++;
                    //print card acount for client
                    ShowAcountCard(Client);
                    break;
                }
                else if (char.ToUpper(choice) == 'B')
                {
                    //creat new client object and store it's data
                    Client Client1 = new Client(name, id, job, phoneNumber, address);
                    //add account and link it to client
                    Addaccount(Client1, acountNumber, true);
                    //add client object to client array list
                    clientList.Add(Client1);
                    //increase id client by one to the next comming client
                    id++;
                    //print card acount for client
                    ShowAcountCard(Client1);
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!!");
                }
            }
        }


        //add new acount
        public static void OpenNewAcount()
        {
            while (true)
            {
                Console.Write("Choose { N } If You Are New , Choose { R } If You Are Already Registered , { E } for Exit: ");
                Char choose = Convert.ToChar(Console.ReadLine());
                //if new client
                if (Char.ToUpper(choose) == 'N')
                {
                    AddClient();
                    break;
                }
                //if already has acount
                else if (char.ToUpper(choose) == 'R')
                {
                    Console.Write("Enter Your Id To Check: ");
                    long id = Convert.ToInt64(Console.ReadLine());

                    //search and fetch the object of the client
                    Client client = SearchClient(id);
                    //if client is exist
                    if (client != null)
                    {
                        //if the client has already tow acounts(one current and one bussiness)
                        if (client.HasCurrent == true && client.HasBusiness == true)
                        {
                            Console.WriteLine("you have full accounts");
                            break;

                        }
                        //if just has one current acount (allowed to creat just one bussness acount) 
                        else if (client.HasCurrent == true)
                        {
                            Console.Write("you allready has current account ##Enter { B } if would to add 'Business Acount' #Enter Any thing else to Exit: ");
                            char inp = Convert.ToChar(Console.ReadLine());
                            if (Char.ToUpper(inp) == 'B')
                            {
                                //add account and link it to client
                                Addaccount(client, acountNumber, true);
                                //print card acount for client
                                ShowAcountCard(client);
                                break;
                            }
                            else { break; }
                        }
                        //if just has one bussiness acount (allowed to creat just one current acount) 
                        else if (client.HasBusiness == true)
                        {
                            Console.Write("you allready has Business Acount ##Enter { C } if would to add 'Current Acount' #Enter Any thing else to Exit: ");
                            char inp = Convert.ToChar(Console.ReadLine());
                            if (Char.ToUpper(inp) == 'C')
                            {
                                //add account and link it to client
                                Addaccount(client, acountNumber, false);
                                //print card acount for client
                                ShowAcountCard(client);
                                break;
                            }
                            else { break; }
                        }
                    }
                    else
                    {
                        Console.WriteLine("not exist");
                    }
                }
                //exit from programe
                else if (char.ToUpper(choose) == 'E')
                {
                    Console.WriteLine("see you later...");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input!!,try again...");
                }
            }

        }
        public static void Deposit(long acountNumber, double money)
        {
            
            Acounts account = SearchAccount(acountNumber);

            if (account != null)
            {   if (money != 0)
                {
                    account.AcountBalance += money;
                    Console.WriteLine("the money has deposited\n");
                }
                
            }
            else
            {
                Console.WriteLine("acount not exist!!");
            }

        }
        public static double Withdrow(long acountNumber)
        {
            //Console.Write("enter your Id acount");
            //long input = Convert.ToInt64(Console.ReadLine());
            Acounts account = SearchAccount(acountNumber);

            if (account != null)
            {
                Console.Write("Enter the money: ");
                double money = Convert.ToDouble(Console.ReadLine());
                if (money < 0)
                {
                    Console.WriteLine("can not withdraw negative value money");
                    return 0;
                }
                else if (money == 0)
                {
                    Console.WriteLine("can not withdraw zero value money");
                    return 0;
                }
                else
                {
                    if (account.Ttype == false) // current acount
                    {
                        if (account.AcountBalance >= money)
                        {
                            account.AcountBalance -= money;
                            Console.WriteLine("drow money done");
                            Console.WriteLine($"Your Acount Balance: {account.AcountBalance} ");
                            return money;
                        }
                        else
                        {
                            Console.WriteLine("Your balance not enough to drow");
                            return 0;
                        }
                    }
                    else
                    {
                        if (account.AcountBalance + 1000000 >= money)
                        {
                            account.AcountBalance -= money;
                            Console.WriteLine("drow money done");
                            Console.WriteLine($"Your Acount Balance: {account.AcountBalance} ");
                            return money;
                        }
                        else
                        {
                            Console.WriteLine("Your balance not enough to drow");
                            return 0;
                        }
                    }
                }
            }

            else { Console.WriteLine("account not exsist"); return 0.0; }

        }
        public static void Transfer()
        {

            Console.WriteLine("enter id account that you want to transfeer from it");
            long acountNum1 = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("enter id account that you want to trasfeer to it");
            long acountNum2 = Convert.ToInt64(Console.ReadLine());

            Acounts acount1 = SearchAccount(acountNum1);
            Acounts acount2 = SearchAccount(acountNum2);

            if (acount1 != null && acount2 != null)
            {

                if (acount1.Ttype == acount2.Ttype)
                {

                    // withdrow
                    double money = Withdrow(acountNum1);
                    //deposit
                    Deposit(acountNum2, money);
                    if (money != 0)
                    {
                        Console.WriteLine("transfer money done");
                    }
                    else
                    {
                        Console.WriteLine("transfer money not done");
                    }
                }
                else
                {
                    Console.WriteLine("not allowed to transfer between deffirent account");
                }
            }
            else if (acount1 == null && acount2 ==null)
            {
                Console.WriteLine("both acount is not exsists!!");
            }
            else if(acount1 == null)
            {
                Console.WriteLine("acount that want transfer from is not exsist");
            }
            else if (acount2 == null)
            {
                Console.WriteLine("acount that want transfer to is not exsist");
            }
        }
        // search function
        public static Client SearchClient(long id)
        {
            foreach (Client client in clientList)
            {
                if (id == client.Id)
                {
                    return client;
                }
            }
            return null;

        }
        public static Acounts SearchAccount(long id)
        {
            foreach (Acounts account in acountsList)
            {
                if (id == account.AcountNumber)
                {
                    return account;
                }
            }
            return null;
        }

        public static void DesplayClients()
        {
            if (clientList.Count == 0)
            {
                Console.WriteLine("no clients in system");
            }
            else
            {
                foreach (Client C in clientList)
                {
                    C.printInfo();
                }
            }
        }
        public static void DesplayAccount()
        {
            if (acountsList.Count == 0)
            {
                Console.WriteLine("no accounts in system");
            }
            else
            {
                foreach (Acounts A in acountsList)
                {
                    A.print();
                }
            }
        }
        public static void closeAccount()
        {
            
            // if the account arraylist has no objects
            if (acountsList.Count == 0)
            {
                Console.WriteLine("no account in system");
            }
            else
            {
                //enter the id for delete its acount
                Console.Write("enter id account:");
                long idAccount = Convert.ToInt64(Console.ReadLine());

                foreach (Client client in clientList)
                {
                    if (client.CurrentNumber == idAccount)
                    {
                        //search of acount object using acount number
                        Acounts acount = SearchAccount(idAccount);//return acount object
              
                        if(acount.AcountBalance > 0)
                        {
                            double restMoney = acount.AcountBalance;
                            Console.WriteLine($"withdrow the remain money in your acount {restMoney}");
                            acount.AcountBalance -= acount.AcountBalance;
                            acountsList.Remove(SearchAccount(idAccount)); //
                            Console.WriteLine("accout is closed");
                            if (client.HasBusiness == false && client.HasCurrent == false)
                            {
                                clientList.Remove(client);
                            }
                            break;
                        }
                        else
                        {
                            acountsList.Remove(SearchAccount(idAccount));
                            Console.WriteLine("accout is closed");
                            client.HasCurrent = false;
                            client.CurrentNumber = 0; //
                            if (client.HasBusiness == false && client.HasCurrent == false)
                            {
                                clientList.Remove(client);

                            }
                            break;
                        }
                        
                    }
                    else if (client.BusinessNumber == idAccount)
                    {
                        Acounts acount = SearchAccount(idAccount);
                        if (acount.AcountBalance < 0)
                        {
                            Console.WriteLine($"you can't delete this acount ,because of loan on you which is {acount.AcountBalance * -1}");
                            break;
                        }
                        else if (acount.AcountBalance > 0)
                        {
                            double restMoney = acount.AcountBalance;
                            Console.WriteLine($"withdrow the remain money in your acount {restMoney}");
                            acount.AcountBalance -= acount.AcountBalance;
                            acountsList.Remove(SearchAccount(idAccount));
                            Console.WriteLine("accout is closed");
                            if (client.HasBusiness == false && client.HasCurrent == false)
                            {
                                clientList.Remove(client);
                            }
                            break;
                        }
                        else
                        {
                            acountsList.Remove(acount);
                            Console.WriteLine("accout is closed");
                            client.HasBusiness = false;
                            client.BusinessNumber = 0; //
                            if (client.HasBusiness == false && client.HasCurrent == false)
                            {
                                clientList.Remove(client);
                            }
                            break;
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("There is no acount in the system with that id !!");
                    }

                }
            }
        }
        public static void AccountAtDate()
        {
            Console.WriteLine(" ===> DATE SHOULD BE NUMBERS <===");
            Console.Write("enter day:");
            string day = Console.ReadLine();

            Console.Write("enter month:");
            string month = Console.ReadLine();

            Console.Write("enter year:");
            string year = Console.ReadLine();

            string date = $"{day}/{month}/{year}";
            bool isThere = false;
            foreach (Acounts account in acountsList)
            {
                if (account.OpenDate == date)
                {
                    Console.WriteLine("_______________________________");
                    account.print();
                    isThere = true;
                }
            }
            if (isThere == false)
            {
                Console.WriteLine("there is no account opened in this date");
            }

        }

    }   


    /*internal class Accounts
    {
        public Accounts()
        {
        }
    }*/
}
