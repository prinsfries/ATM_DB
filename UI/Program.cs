using atmBL;
using atmDL;
using ATMMODEL;
using Microsoft.VisualBasic.FileIO;
using System.Security.Cryptography.X509Certificates;

namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EWDataServices data = new EWDataServices();
            EWService service = new EWService();
            MoneyService monkey = new MoneyService();
            SqlDbData db = new SqlDbData();
            MainMenu();

            void MainMenu()
            {
                Console.WriteLine("Hello, welcome to Aguas E-wallet ATM");
                Console.WriteLine("Select:");
                Console.WriteLine("1. Login\n2. Register\n0. Admin Settings");
                Console.Write("Input: ");
                byte menu = Convert.ToByte(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        Login();
                        break;
                    case 2:
                        Register();
                        break;
                    case 0:
                        AdminSettings();
                        break;
                    default:
                        Console.WriteLine("\nError!\nPlease restart the program and input a valid choice");
                        break;
                }
            }

            void Login()
            {
                Console.WriteLine("\nPlease input your E-wallet card pin");
                Console.Write("Input: ");
                string Pin = Console.ReadLine();
                service.VerifyPinDB(Pin);

                EWallet got = service.VerifyPinDB(Pin);
                Console.WriteLine($"\nWelcome, {got.name}!");
                Console.WriteLine($"Password: {got.EWPin}");
                Console.WriteLine($"Bank Amount: {got.money}");
                int bank = got.money;
                String pin = got.EWPin;
                Proceed(bank, pin);
            }
            void Register()
            {
                Console.WriteLine($"\nPlease enter your credentials:");
                Console.Write($"Name:");
                string Name = Console.ReadLine();
                Console.Write($"Pin:");
                string pin = Console.ReadLine();
                service.AddNewUser(Name, pin);
                Console.WriteLine("Successfully Registered with freebie 1000!");
            }
            void Del()
            {
                Console.WriteLine("Input pin number of account to delete");
                Console.Write("Pin: ");
                string pin = Console.ReadLine();
                if (pin == "")
                {
                    invalid();
                }
                else
                {
                    Console.WriteLine("Are you really sure you want to terminate this account?");
                    Console.WriteLine("\n1. Yes\n2. No\n");
                    Console.Write("Input:");
                    byte choice = Convert.ToByte(Console.ReadLine());
                    if (choice == 1)
                    {
                        Console.WriteLine("Deleting Account...");
                        service.DeleteUser(pin);
                        Console.WriteLine("Account Deleted Successfully");
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("Deletion Cancelled");
                        Console.WriteLine("Please restart system...");
                    }
                    else
                    {
                        Console.WriteLine("\nError!\nPlease restart the program and input a valid choice");
                    }
                }
            }
            void AdminSettings()
            {
                Console.WriteLine("\nInput valid admin password");
                Console.Write("Password: ");
                string pw = Console.ReadLine();
                if(pw == "000")
                {
                    Console.WriteLine("1. Delete User\n2. Display All Users");
                    byte choice = Convert.ToByte(Console.ReadLine());
                    if (choice == 1)
                    {
                        Del();
                    }
                    else if (choice == 2)
                    {
                        DisplayAll();
                    }
                    else
                    {
                        invalid();
                    }
                }
                else
                {
                    invalid();
                }
            }

            void Proceed(int bank, string pin)
                {
                    Console.WriteLine($"Amount: {bank}");
                    Console.WriteLine("Please select a transaction to be done:");
                    Console.WriteLine("1. Withdraw");
                    Console.WriteLine("2. Deposit");
                    Console.Write("Input: ");
                    byte choice = Convert.ToByte(Console.ReadLine());
                    switch (choice)
                    {
                        //withdraw
                        case 1:
                            choices(bank);
                            int wd = Convert.ToInt32(Console.ReadLine());
                            if (wd == 9)
                            {
                                customAmount(bank);
                                wd = Convert.ToInt32(Console.ReadLine());
                                monkey.customInputWith(bank, wd, pin);
                                if (monkey.customInputWith(bank, wd, pin) == 0)
                                {
                                    insuff();
                                }
                                else
                                {
                                    CustomsuccessWith(bank, wd, pin);
                                }

                            }
                            else if (wd <= 9 && wd > 0)
                            {
                                monkey.WITH(bank, wd,pin);
                                if (monkey.Withdraw(bank, wd, pin) == 0)
                                {
                                    insuff();
                                }
                                else
                                {
                                    successWith(bank, wd, pin);
                                }
                            }
                            else
                            {
                                invalid();
                            }
                            break;

                        //deposit
                        case 2:
                            choices(bank);
                            wd = Convert.ToInt32(Console.ReadLine());
                            if (wd == 9)
                            {
                                customAmount(bank);
                                wd = Convert.ToInt32(Console.ReadLine());
                                monkey.customInputDepo(bank, wd, pin);
                                CustomsuccessDepo(bank, wd, pin);
                            }
                            else if (wd <= 9 && wd > 0)
                            {
                                monkey.DEPO(bank, wd, pin);
                                if (monkey.deposit(bank, wd, pin) == 0)
                                {
                                    insuff();
                                }
                                else
                                {
                                    successDepo(bank, wd, pin);
                                }
                            }
                            else
                            {
                                invalid();
                            }
                            break;

                        default:
                            invalid();
                            break;
                    }
                }
            void choices(int moneymoney)
                {
                    Console.WriteLine();
                    Console.WriteLine("Money in account: " + moneymoney);
                    Console.WriteLine("Select amount to process:");
                    Console.WriteLine("1. 100");
                    Console.WriteLine("2. 200");
                    Console.WriteLine("3. 500");
                    Console.WriteLine("4. 1,000");
                    Console.WriteLine("5. 2,000");
                    Console.WriteLine("6. 5,000");
                    Console.WriteLine("7. 7,500");
                    Console.WriteLine("8. 10,000");
                    Console.WriteLine("9. Custom");
                    Console.Write("Input: ");
                }
            void successWith(int bank, int wd, string pin)
                {
                    Console.WriteLine("\nSuccessfully withdrawn!");
                    Console.WriteLine($"Your account now contains: " + monkey.Withdraw(bank, wd, pin) + "php");
                    Console.WriteLine("Claim Your Cash and E-Wallet Card below...");
                    Console.WriteLine("Thank you!\n");
                }
            void CustomsuccessWith(int bank, int wd, string pin)
                {
                    Console.WriteLine("\nSuccessfully withdrawn!");
                    Console.WriteLine($"Your account now contains: " + monkey.customInputWith(bank, wd, pin) + "php");
                    Console.WriteLine("Claim Your Cash and E-Wallet Card below...");
                    Console.WriteLine("Thank you!\n");
                }
            void successDepo(int bank, int wd, string pin)
                {
                    Console.WriteLine("\nSuccessfully deposited!");
                    Console.WriteLine($"Your account now contains: " + monkey.deposit(bank, wd, pin) + "php");
                    Console.WriteLine("Claim Your Receipt and E-Wallet Card below...");
                    Console.WriteLine("Thank you!\n");
                }
            void CustomsuccessDepo(int bank, int wd, string pin)
                {
                    Console.WriteLine("\nSuccessfully deposited!");
                    Console.WriteLine($"Your account now contains: " + monkey.customInputDepo(bank, wd, pin) + "php");
                    Console.WriteLine("Claim Your Receipt and E-Wallet Card below...");
                    Console.WriteLine("Thank you!\n");

                }
            void customAmount(int moneymoney)
                {
                    Console.Write("Input amount to process: ");
                }
            void insuff()
                {
                    Console.WriteLine("Insufficient funds bro");
                }
            void invalid()
                {
                    Console.WriteLine("\nInvalid Input " +
                        "\nPlease start over...");
                }

            void DisplayAll()
                {
                    List<EWallet> users = SqlDbData.GetEW();
                    int i = 0;
                    foreach (var item in users)
                    {
                        i++;
                        Console.WriteLine("\nUser" + i);
                        Console.WriteLine(item.name);
                        Console.WriteLine(item.EWPin + "\n");
                    }
                }
            
        }
    }
}


//bool result = service.VerifyPin(Pin);
//if (result)
//{
//    if (Pin == "12")
//    {
//        EWallet show = data.GetUser1();
//        int bank = show.money.amount;
//        Console.WriteLine();
//        Console.WriteLine($"Hello, {show.name}!");
//        Console.WriteLine($"EWallet Money: {show.money.amount}php");
//        Proceed(bank);

//    }
//    else if (Pin == "123")
//    {
//        EWallet show = data.GetUser2();
//        int bank = show.money.amount;
//        Console.WriteLine();
//        Console.WriteLine($"Hello, {show.name}!");
//        Console.WriteLine($"EWallet Money: {show.money.amount}php");
//        Proceed(bank);
//    }
//    else if (Pin == "1234")
//    {
//        EWallet show = data.GetUser3();
//        int bank = show.money.amount;
//        Console.WriteLine();
//        Console.WriteLine($"Hello, {show.name}!");
//        Console.WriteLine($"EWallet Money: {show.money.amount}php");
//        Proceed(bank);
//    }