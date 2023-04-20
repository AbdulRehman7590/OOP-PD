using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace App
{
    class Program
    {
        static string[] Role = new string[100];
        static string[] Username = new string[100];
        static string[] Password = new string[100];
        static string[] Contact = new string[100];
        static string[] Product = new string[100];
        static int[] Price = new int[100];
        static int[] Quantity = new int[100];
        static int[] OrigialQuantity = new int[100];
        static int[] Sale = new int[100];
        static string[] Chat = new string[100];
        static string[] ChatSender = new string[100];
        static string[,] Message = new string[100, 100];

        static string Pin, LoginName, LoginPass;
        static int Count = 0, ProductsCount = 0, Msg = 0, MSGR = 0, MSGC = 2;
        
        static void Main(string[] args)
        {
            /* Program loading  */
            Loadpin();
            Loadlogindata();
            LoadProductsData();
            LoadAnnouncements();

            /* Working */
            string number;
            while (true)
            {
                Printmenu("Login Screen");

                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Sign In");
                Console.WriteLine("3. Exit");
                SelectOpt();
                number = Console.ReadLine();

                if (number == "1")
                {
                    SignUp();
                }
                else if (number == "2")
                {
                    SignIN();
                }
                else if (number == "3")
                {
                    break;
                }
                else
                {
                    ValidNumber();
                    Halt();
                }


            }
        }

        static void SelectOpt()
        {
            Console.WriteLine(" ");
            Console.Write("Select Option : ");
        }
        static void ValidNumber()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Enter valid number !");
        }
        static void Halt()
        {
            Console.WriteLine(" ");
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
        static void SearchBack()
        {
            Console.WriteLine("1. Search");
            Console.WriteLine("2. Move Back");
        }

        static void Printmenu(string menu)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(1, 2);
            Console.WriteLine(" $$$$$$\\  $$$$$$\\ $$$$$$$$\\ $$\\     $$\\        $$$$$$\\  $$\\   $$\\  $$$$$$\\  $$$$$$$\\  ");
            Console.SetCursorPosition(1, 3);
            Console.WriteLine("$$  __$$\\ \\_$$  _|\\__$$  __|\\$$\\   $$  |      $$  __$$\\ $$ |  $$ |$$  __$$\\ $$  __$$\\  ");
            Console.SetCursorPosition(1, 4);
            Console.WriteLine("$$ /  \\__|  $$ |     $$ |    \\$$\\ $$  /       $$ /  \\__|$$ |  $$ |$$ /  $$ |$$ |  $$ |");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(1, 5);
            Console.WriteLine("$$ |        $$ |     $$ |     \\$$$$  /        \\$$$$$$\\  $$$$$$$$ |$$ |  $$ |$$$$$$$  |");
            Console.SetCursorPosition(1, 6);
            Console.WriteLine("$$ |        $$ |     $$ |      \\$$  /          \\____$$\\ $$  __$$ |$$ |  $$ |$$  ____/ ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(1, 7);
            Console.WriteLine("$$ |  $$\\   $$ |     $$ |       $$ |          $$\\   $$ |$$ |  $$ |$$ |  $$ |$$ |      ");
            Console.SetCursorPosition(1, 8);
            Console.WriteLine("\\$$$$$$  |$$$$$$\\    $$ |       $$ |          \\$$$$$$  |$$ |  $$ | $$$$$$  |$$ |      ");
            Console.SetCursorPosition(1, 9);
            Console.WriteLine(" \\______/ \\______|   \\__|       \\__|           \\______/ \\__|  \\__| \\______/ \\__|      ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("**************************************************************************************");

            Console.SetCursorPosition(27, 12);
            Console.WriteLine(DateTime.Now);

            Console.SetCursorPosition(0, 14);
            Console.WriteLine("**************************************************************************************");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(30, 14);
            Console.WriteLine("( " + menu + " )");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
        }

        static void SignUp()
        {
            Printmenu("Role Selection");

            string option;

            Console.WriteLine("1. As Admin");
            Console.WriteLine("2. As Employee");
            Console.WriteLine("3. As Customer");
            Console.WriteLine("4. Move Back");
            Console.WriteLine(" ");
            Console.Write("Select Option : ");
            option = Console.ReadLine();

            if (option == "1")
            {
                if (CheckAdmin() == false)
                {
                    TakingInput(option);
                    PinSetup();
                }
                else
                {
                    if (EnterAdminCode() == true)
                    {
                        TakingInput(option);
                    }
                    else
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("YOu can't Sign Up as Admin without Pin ! ");
                        Halt();
                    }
                }
            }
            else if (option == "2")
            {
                if (EnterAdminCode() == true)
                {
                    TakingInput(option);
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("You can't Sign Up as Employee without Pin");
                    Halt();
                }
            }
            else if (option == "3")
            {
                TakingInput(option);
            }
            else if (option == "4")
            {
            }
            else
            {
                Console.WriteLine("Invalid number");
                Halt();
            }

        }


        static void TakingInput(string option)
        {
            string name, pass, phone;

            name = EnterUserName();
            pass = EnterUserPass(name);
            phone = EnterUserContact(name, pass);
            SignupWorking(option, name, pass, phone);
        }


        static string EnterUserName()
        {
            string name;

            Printmenu("Sign Up Screen");

            Console.Write("Enter Username : ");
            name = Console.ReadLine();

            return name;
        }

        static string EnterUserPass(string name)
        {
            string pass;

            while (true)
            {
                Printmenu("Sign Up Screen");

                Console.WriteLine("Enter Username : " + name);

                Console.Write("Set Password (4-digits) : ");
                pass = Console.ReadLine();

                if (pass.Length == 4)
                {
                    break;
                }
            }
            return pass;
        }

        static string EnterUserContact(string name, string pass)
        {
            string phone;

            while (true)
            {
                Printmenu("Sign Up Screen");

                Console.WriteLine("Enter Username : " + name);

                Console.WriteLine("Set Password (4-digits) : " + pass);

                Console.Write("Enter Contact number (10-digits) :  +92 ");
                phone = Console.ReadLine();

                if (phone.Length == 10 && IsNum(phone) == true)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Enter Correct Number ");
                }
            }
            return phone;
        }

        static bool IsNum(string phone)
        {
            bool check = false;
            int isdigit;

            for (int count = 0; count < phone.Length; count++)
            {
                isdigit = (int)(phone[count]);
                if (isdigit >= 48 && isdigit <= 57)
                {
                    check = true;
                }
                else
                {
                    check = false;
                    break;
                }
            }
            return check;
        }

        static void SignupWorking(string option, string name, string pass, string phone)
        {
            if (Sign(option, name, pass, phone) == false)
            {
                Console.WriteLine(" ");
                Console.WriteLine("User Already Exists");
                Console.WriteLine(" ");
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine("Sign Up Successfully");
                Console.WriteLine(" ");
            }
        }

        static bool CheckAdmin()
        {
            bool flag = false;
            for (int x = 0; x < Count; x++)
            {
                if (Role[x] == "1")
                {
                    flag = true;
                }
            }
            return flag;
        }

        static void PinSetup()
        {
            Printmenu("Sign Up Screen");

            while (true)
            {
                Console.Write("Enter Pin (5-digit) to Login : ");
                Pin = Console.ReadLine();
                if (Pin.Length == 5 && IsNum(Pin) == true)
                {
                    break;
                }
            }
            Console.WriteLine("Pin Updated! ");
            Updatepin();
            Halt();
        }

        static bool EnterAdminCode()
        {
            bool flag = false;
            string code;
            Console.Write("Enetr 5-digit Pin to Sign Up : ");
            code = Console.ReadLine();
            if (code == Pin)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        static bool Sign(string num, string name, string pass, string contct)
        {
            bool status = true;

            for (int index = 0; index < Count; index++)
            {
                if (Username[index] == name && Password[index] == pass)
                {
                    status = false;
                    break;
                }
            }
            if (status == true)
            {
                Role[Count] = num;
                Username[Count] = name;
                Password[Count] = pass;
                Contact[Count] = contct;
                Storelogindata(num, name, pass, contct);
                Count++;
            }
            return status;
        }

        static void SignIN()
        {
            Printmenu("Sign-In Screen");

            int counter = 0;

            Console.Write("Enter the User-name : ");
            LoginName = Console.ReadLine();

            Console.Write("Enter the Password : ");
            LoginPass = Console.ReadLine();

            for (int idx = 0; idx < Count; idx++)
            {
                if (Username[idx] == LoginName && Password[idx] == LoginPass)
                {
                    if (Role[idx] == "1")
                    {
                        AdminInterface();
                    }
                    else if (Role[idx] == "2")
                    {
                        /*Employeeinterface();*/
                    }
                    else if (Role[idx] == "3")
                    {
                        /* Customerinterface();*/
                    }
                    break;
                }
                counter++;
            }
            if (counter == Count)
            {
                Console.WriteLine(" ");
                Console.WriteLine("No User Found !");
                Halt();
            }
        }
        static bool LogOut()
        {
            Printmenu("Log-Out Screen");

            bool status = false;

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("|| Are you sure you want to Log out ? ||");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press 1 to Log-Out");
            Console.WriteLine("Press any key to cancel...");
            Console.WriteLine("  ");
            Console.Write("Select Option : ");

            if (Console.ReadLine() == "1")
            {
                status = true;
            }
            return status;
        }



        static void AdminInterface()
        {
            string option;
            while (true)
            {
                ShowAdminControls();
                option = Console.ReadLine();

                if (option == "1")
                {
                    ProductView();
                }
                else if (option == "2")
                {
                    OnSaleproducts();
                }
                else if (option == "3")
                {
                    AddProduct();
                }
                else if (option == "4")
                {
                    UpdateProduct();
                }
                else if (option == "5")
                {
                    PlaceSale();
                }
                else if (option == "6")
                {
                    ManageEmployee();
                }
                else if (option == "7")
                {
                    CustomerTraffic();
                }
                else if (option == "8")
                {
                    Messenger();
                }
                else if (option == "9")
                {
                    Announcements();
                }
                else if (option == "10")
                {
                    PinSetup();
                }
                else if (option == "11")
                {
                    ChangePass();
                }
                else if (option == "12")
                {
                    if (LogOut() == true)
                    {
                        break;
                    }
                }
                else
                {
                    ValidNumber();
                    Halt();
                }
            }

        }
        static void ShowAdminControls()
        {
            Printmenu("Admin Interface");

            Console.WriteLine("1. View List of Products");
            Console.WriteLine("2. View Products on Sale");
            Console.WriteLine(" ");
            Console.WriteLine("3. Add/Remove Product");
            Console.WriteLine("4. Update the Product");
            Console.WriteLine("5. Place product on Sale");
            Console.WriteLine(" ");
            Console.WriteLine("6. Manage Employee");
            Console.WriteLine("7. See Customer traffic");
            Console.WriteLine(" ");
            Console.WriteLine("8. Open Messenger");
            Console.WriteLine("9. Check Announcements Section");
            Console.WriteLine(" ");
            Console.WriteLine("10. Update Sign-Up Pin");
            Console.WriteLine("11. Change Log-In Password");
            Console.WriteLine(" ");
            Console.WriteLine("12. Log out");
            SelectOpt();
        }

        static void AddProduct()
        {
            string num;
            while (true)
            {
                Printmenu("Add/Remove Products");

                Console.WriteLine("1. Add Products");
                Console.WriteLine("2. Remove Products");
                Console.WriteLine("3. Back to main menu");
                SelectOpt();
                num = Console.ReadLine();

                if (num == "1")
                {
                    PlusProduct();
                }
                else if (num == "2")
                {
                    MinusProduct();
                }
                else if (num == "3")
                {
                    break;
                }
                else
                {
                    ValidNumber();
                    Halt();
                }
            }
        }
        static void PlusProduct()
        {
            string val, checkProduct;
            while (true)
            {
                Printmenu("Adding Product");
                Console.Write("Enter the name of the product : ");
                checkProduct = Console.ReadLine();
                if (IsProductExists() != -1)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Product Already exists.");
                }
                else
                {
                    Product[ProductsCount] = checkProduct;
                    break;
                }
            }
            Printmenu("Adding Product");
            while (true)
            {
                Console.Write("Price of Product (per piece) : ");
                val = Console.ReadLine();
                if (IsNum(val) == false)
                {
                    ValidNumber();
                }
                else
                {
                    Price[ProductsCount] = int.Parse(val);
                    break;
                }
            }

            Console.Write("Enter quantity of product : ");
            Quantity[Count] = int.Parse(Console.ReadLine());

            /* OriginalQuantity[ProductsCount] = Quantity[ProductsCount];  */
            Sale[ProductsCount] = 0;
            StoreProductsData(Product[ProductsCount], Price[ProductsCount], Quantity[ProductsCount], Sale[ProductsCount]);
            ProductsCount++;
            Console.WriteLine(" ");
            Console.WriteLine("Product added successfully !");
            Halt();
        }
        static void MinusProduct()
        {
            string option;
            int num;
            while (true)
            {
                Printmenu("Remove Products");

                SearchBack();
                SelectOpt();
                option = Console.ReadLine();

                if (option == "1")
                {
                    Console.WriteLine(" ");
                    num = IsProductExists();
                    if (num != -1)
                    {
                        Remove(num, ProductsCount);
                        /* CartRemoving(ProductName);  */
                        ProductsCount--;
                        UpdateProductsData();

                        Console.WriteLine(" ");
                        Console.WriteLine("Product removed successfully! ");
                    }
                    else
                    {
                        Console.WriteLine("No product found !");
                    }
                }
                else if (option == "2")
                {
                    break;
                }
                else
                {
                    ValidNumber();
                }
                Halt();
            }
        }

        static void UpdateProduct()
        {
            string option;
            while (true)
            {
                Printmenu("Update Products");

                Console.WriteLine("1. Update the product's Price");
                Console.WriteLine("2. Update the products's Quantity");
                Console.WriteLine("3. Move back to main menu");
                SelectOpt();
                option = Console.ReadLine();

                if (option == "1")
                {
                    UpdatePrice();
                }
                else if (option == "2")
                {
                    UpdateQuantity();
                }
                else if (option == "3")
                {
                    break;
                }
                else
                {
                    ValidNumber();
                    Halt();
                }
            }
        }
        static void UpdatePrice()
        {
            string option;
            int idx;
            while (true)
            {
                Printmenu("Update the Price");

                SearchBack();
                SelectOpt();
                option = Console.ReadLine();

                if (option == "1")
                {
                    Printmenu("Update the Price");
                    Console.WriteLine(" ");
                    idx = IsProductExists();
                    if (idx != -1)
                    {
                        Console.WriteLine("Old Price is : " + Price[idx]);

                        Console.Write("Enter the new price : ");
                        Price[idx] = int.Parse(Console.ReadLine());

                        Console.WriteLine("  ");
                        Console.WriteLine("Price Updated !");
                        UpdateProductsData();
                    }
                    else
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("No product found !");
                    }
                }
                else if (option == "2")
                {
                    break;
                }
                else
                {
                    ValidNumber();
                }
                Halt();
            }
        }
        static void UpdateQuantity()
        {
            string option;
            int idx;
            while (true)
            {
                Printmenu("Update the Quantity");

                SearchBack();
                SelectOpt();
                option = Console.ReadLine();

                if (option == "1")
                {
                    Printmenu("Update the Quantity");
                    Console.WriteLine(" ");
                    idx = IsProductExists();
                    if (idx != -1)
                    {
                        Console.WriteLine("Old quantity is : " + Quantity[idx]);

                        Console.Write("Enter the new quantity : ");
                        Quantity[idx] = int.Parse(Console.ReadLine());
                        /* OriginalQuantity[idx] = Qantity[idx];  */
                        Console.WriteLine("  ");
                        Console.WriteLine("Quantity Updated !");
                        UpdateProductsData();
                    }
                    else
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("No product found !");
                    }
                }
                else if (option == "2")
                {
                    break;
                }
                else
                {
                    ValidNumber();
                }
                Halt();
            }
        }

        static void PlaceSale()
        {
            string num;
            while (true)
            {
                Printmenu("Place Sale");

                Console.WriteLine("1. Add on Sale");
                Console.WriteLine("2. Remove from Sale");
                Console.WriteLine("3. Back to menu");
                SelectOpt();
                num = Console.ReadLine();
                if (num == "1")
                {
                    AddonSale();
                }
                else if (num == "2")
                {
                    RemovefromSale();
                }
                else if (num == "3")
                {
                    break;
                }
                else
                {
                    ValidNumber();
                    Halt();
                }
            }
        }
        static void AddonSale()
        {
            string option;
            int idx;
            while (true)
            {
                Printmenu("Add on Sale");

                SearchBack();
                SelectOpt();
                option = Console.ReadLine();

                if (option == "1")
                {
                    Printmenu("Add on Sale");

                    idx = IsProductExists();
                    if (idx != -1)
                    {
                        Console.WriteLine(" ");
                        Console.Write("Place a sale of : ");
                        Sale[idx] = int.Parse(Console.ReadLine());
                        UpdateProductsData();
                        Console.WriteLine(" ");
                        Console.WriteLine("Sale added..");
                    }
                    else
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("No product found !");
                    }
                }
                else if (option == "2")
                {
                    break;
                }
                else
                {
                    ValidNumber();
                }
                Halt();
            }
        }
        static void RemovefromSale()
        {
            string option;
            int idx;
            while (true)
            {
                Printmenu("Remove from Sale");

                SearchBack();
                SelectOpt();
                option = Console.ReadLine();

                if (option == "1")
                {
                    Printmenu("Remove from Sale");

                    idx = IsProductExists();
                    if (idx != -1)
                    {
                        Sale[idx] = 0;
                        UpdateProductsData();
                        Console.WriteLine(" ");
                        Console.WriteLine("Sale removed...");
                    }
                    else
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("No product found !");
                    }
                }
                else if (option == "2")
                {
                    break;
                }
                else
                {
                    ValidNumber();
                }
                Halt();
            }
        }

        static void ManageEmployee()
        {
            string option;
            while (true)
            {
                Printmenu("Manage Employee");

                Console.WriteLine("1. Watch Employee details");
                Console.WriteLine("2. Remove Employee");
                Console.WriteLine("3. Back to main menu");
                SelectOpt();
                option = Console.ReadLine();

                if (option == "1")
                {
                    EmployeeDetails();
                }
                else if (option == "2")
                {
                    RemoveEmployee();
                }
                else if (option == "3")
                {
                    break;
                }
                else
                {
                    ValidNumber();
                    Halt();
                }
            }
        }
        static void EmployeeDetails()
        {
            Printmenu("Employee Detail's");
            int index = 0;

            Console.WriteLine("Index".PadRight(20, ' ') + "Name".PadRight(20, ' ') + "Contact No.");
            Console.WriteLine(" ");
            for (int x = 0; x < Count; x++)
            {
                if (Role[x] == "2")
                {
                    index++;
                    Console.WriteLine((index.ToString()).PadRight(20, ' ') + Username[x].PadRight(20, ' ') + "+92" + Contact[x]);
                }
            }
            Halt();
        }
        static void RemoveEmployee()
        {
            string option, cname;
            int idx;
            while (true)
            {
                Printmenu("Remove Employee");

                SearchBack();
                SelectOpt();
                option = Console.ReadLine();

                if (option == "1")
                {
                    Printmenu("Remove Employee");
                    Console.WriteLine(" ");
                    Console.Write("Enter the name :");
                    cname = Console.ReadLine();
                    idx = IsUserExists(cname);
                    if (idx != -1 && Role[idx] == "2")
                    {
                        for (int i = idx; i < Count - 1; i++)
                        {
                            Role[i] = Role[i + 1];
                            Username[i] = Username[i + 1];
                            Contact[i] = Contact[i + 1];
                        }
                        Count--;
                        Updatelogindata();
                        Console.WriteLine(" ");
                        Console.WriteLine("Employee Removed !");
                    }
                    else
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("No User exists !");
                    }
                }
                else if (option == "2")
                {
                    break;
                }
                else
                {
                    ValidNumber();
                }
                Halt();
            }
        }

        static void CustomerTraffic()
        {
            Printmenu("Customer Traffic");
            int index = 0;

            Console.WriteLine("Index".PadRight(20, ' ') + "Name".PadRight(20, ' ') + "Contact no.");
            Console.WriteLine(" ");

            for (int x = 0; x < Count; x++)
            {
                if (Role[x] == "3")
                {
                    Console.WriteLine((index.ToString()).PadRight(20, ' ') + Username[x].PadRight(20, ' ') + "+92 " + Contact[x]);
                }
            }
            Halt();
        }

        static void ChangePass()
        {
            Printmenu("Change Password");
            int idx;
            idx = IsUserExists(LoginName);
            Console.WriteLine("Old Password is : " + Password[idx]);
            Console.WriteLine("");
            Console.Write("Enter new password : ");
            Password[idx] = Console.ReadLine();
            Updatelogindata();
            Console.WriteLine(" ");
            Console.WriteLine("Password updated !");
            Halt();
        }

        static void Announcements()
        {
            string option;
            while (true)
            {
                Printmenu("Announcements");
                Console.WriteLine("1. Make announcement");
                Console.WriteLine("2. Watch announcements");
                Console.WriteLine("3. Back to main menu");
                SelectOpt();
                option = Console.ReadLine();

                if (option == "1")
                {
                    Sent();
                }
                else if (option == "2")
                {
                    Received();
                }
                else if (option == "3")
                {
                    break;
                }
                else
                {
                    ValidNumber();
                    Halt();
                }
            }
        }
        static void Sent()
        {
            string option, announced;
            while (true)
            {
                Printmenu("Announcements");
                Console.WriteLine("1. Announce");
                Console.WriteLine("2. Move back");
                SelectOpt();
                option = Console.ReadLine();

                if (option == "1")
                {
                    Printmenu("Announcements");
                    ChatSender[Msg] = LoginName;
                    Console.Write("Type Announcement : ");
                    announced = Console.ReadLine();
                    if (announced != "")
                    {
                        Chat[Msg] = announced;
                        Msg++;
                        StoreAnnouncements(ChatSender[Msg], Chat[Msg]);
                    }
                }
                else if (option == "2")
                {
                    break;
                }
                else
                {
                    ValidNumber();
                }
                Halt();
            }
        }
        static void Received()
        {
            if (Msg > 0)
            {
                Printmenu("Announcements");

                for (int x = 0; x < Msg; x++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("From :  " + ChatSender[x]);
                    Console.WriteLine(" ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(Chat[x]);
                }
            }
            else
            {
                Console.WriteLine("No New Announements!");
            }
            Halt();
        }



        static void Messenger()
        {
            string option;
            while (true)
            {
                Printmenu("Messenger");

                Console.WriteLine("1. Sent message");
                Console.WriteLine("2. Received messages");
                Console.WriteLine("3. Back to main menu");
                SelectOpt();
                option = Console.ReadLine();

                if (option == "1")
                {
                    SentMessage();
                }
                else if (option == "2")
                {
                    ReceivedMessage();
                }
                else if (option == "3")
                {
                    break;
                }
                else
                {
                    ValidNumber();
                    Halt();
                }
            }
        }
        static void SentMessage()
        {
            string option, receiver;
            int idx;
            bool status = false;
            while (true)
            {
                Printmenu("Messenger");

                Console.WriteLine("1. Open Messenger");
                Console.WriteLine("2. Move Back");
                SelectOpt();
                option = Console.ReadLine();

                if (option == "1")
                {
                    Printmenu("Messenger");

                    Console.Write("Enter receiver's name : ");
                    receiver = Console.ReadLine();
                    idx = IsUserExists(receiver);
                    if (idx != -1)
                    {
                        Message[MSGR, 0] = receiver;
                        for (int x = 0; x < MSGR; x++)
                        {
                            if (Message[x, 1] == LoginName)
                            {
                                Console.Write("Type Message : ");
                                Message[x, MSGC] = Console.ReadLine();
                                MSGC++;
                                status = true;
                                break;
                            }
                        }
                        if (status == false)
                        {
                            Message[MSGR, 1] = LoginName;
                            Console.Write("Type Message : ");
                            Message[MSGR, MSGC] = Console.ReadLine();
                            MSGR++;
                            MSGC++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No user found !");
                    }
                }
                else if (option == "2")
                {
                    break;
                }
                else
                {
                    ValidNumber();
                }
                Halt();
            }
        }
        static void ReceivedMessage()
        {
            string option;
            bool status = false;
            while (true)
            {
                Printmenu("Receieved Messages");

                Console.WriteLine("1. Open Messenger");
                Console.WriteLine("2. Move Back");
                SelectOpt();
                option = Console.ReadLine();

                if (option == "1")
                {
                    for (int x = 0; x < MSGR; x++)
                    {
                        if (Message[x, 0] == LoginName)
                        {
                            Printmenu("Received Messages");
                            for (int y = 2; y < MSGC; y++)
                            {
                                if (Message[x, y] != "")
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.Write(Message[x, 1] + " : ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine(Message[x, y]);
                                }
                                Console.WriteLine(" ");
                            }
                            status = true;
                        }
                    }
                    if (status == false)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("No New message");
                    }
                }
                else if (option == "2")
                {
                    break;
                }
                else
                {
                    ValidNumber();
                }
                Halt();
            }
        }


        static void ProductView()
        {
            if (Count > 0)
            {
                Printmenu("Products Details");
                int index = 0;
                /*int ratio = 0;*/

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Index" + "Name".PadLeft(20, ' ') + "Price".PadLeft(25, ' ') + "Quantity".PadLeft(20, ' '));
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.White;
                for (int x = 0; x < ProductsCount; x++)
                {
                    index++;
                    /*ratio = WhichQuantity(idx);*/
                    Console.WriteLine(index + Product[x].PadLeft(25, ' ') + (Price[x].ToString()).PadLeft(20, ' ') + /*(ratio.ToString())*/(Quantity[x].ToString()).PadLeft(20, ' '));
                }
            }
            else
            {
                Console.WriteLine("No product added!");
            }
            Halt();
        }
        static void OnSaleproducts()
        {
            Printmenu("Products on Sale");
            int index = 0;
            /*int ratio = 0;*/

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Index" + "Name".PadLeft(20, ' ') + "Price".PadLeft(20, ' ') + "Quantity".PadLeft(20, ' ') + "Sale".PadLeft(20, ' '));
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.White;
            for (int x = 0; x < ProductsCount; x++)
            {
                if (Sale[x] > 0)
                {
                    index++;
                    /*ratio = WhichQuantity(idx);*/
                    Console.WriteLine(index + Product[x].PadLeft(25, ' ') + (Price[x].ToString()).PadLeft(20, ' ') + /*(ratio.ToString())*/(Quantity[x].ToString()).PadLeft(20, ' ') + (Sale[x].ToString() + "%").PadLeft(20, ' '));
                }
            }
            Halt();
        }


        static void Remove(int index, int totalcount)
        {
            for (int x = index; x < totalcount - 1; x++)
            {
                Product[x] = Product[x + 1];
                Price[x] = Price[x + 1];
                Quantity[x] = Quantity[x + 1];
                Sale[x] = Sale[x + 1];
            }
        }
        static int IsUserExists(string cname)
        {
            int num = -1;
            for (int x = 0; x < Count; x++)
            {
                if (cname == Username[x])
                {
                    num = x;
                }
            }
            return num;
        }
        static int IsProductExists()
        {
            int num = -1;
            string pname;
            Console.Write("Enter the name of the Product : ");
            pname = Console.ReadLine();
            for (int i = 0; i < ProductsCount; i++)
            {
                if (Product[i] == pname)
                {
                    num = i;
                    break;
                }
            }
            return num;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /* File Hadnling Functions */

        /*  User Data */
        static void Storelogindata(string num, string name, string pass, string cntct)
        {
            string textname = "UserData.txt";
            StreamWriter sign = new StreamWriter(textname, true);
            sign.WriteLine(num + "," + name + "," + pass + "," + cntct);
            sign.Close();
        }
        static void Loadlogindata()
        {
            string line;
            string textname = "UserData.txt";
            if (File.Exists(textname))
            {
                StreamReader sign = new StreamReader(textname);
                while (!(sign.EndOfStream))
                {
                    line = sign.ReadLine();
                    if (line != "")
                    {
                        Console.WriteLine(line);
                        string[] splitarray = line.Split(',');
                        Role[Count] = splitarray[0];
                        Username[Count] = splitarray[1];
                        Password[Count] = splitarray[2];
                        Contact[Count] = splitarray[3];
                        Count++;
                    }
                }
                sign.Close();
            }
        }
        static void Updatelogindata()
        {
            string textname = "UserData.txt";
            StreamWriter sign = new StreamWriter(textname);
            for (int x = 0; x < Count; x++)
            {
                sign.WriteLine(Role[x] + "," + Username[x] + "," + Password[x] + "," + Contact[x]);
            }
            sign.Close();
        }

        /* Admin Pin */
        static void Loadpin()
        {
            string textname = "AdminPin.txt";
            if (File.Exists(textname))
            {
                StreamReader pinfile = new StreamReader(textname);
                Pin = pinfile.ReadLine();
                pinfile.Close();
            }
        }
        static void Updatepin()
        {
            string textname = "AdminPin.txt";
            StreamWriter pinfile = new StreamWriter(textname);
            pinfile.WriteLine(Pin);
            pinfile.Close();
        }

        /* Products Data */
        static void StoreProductsData(string name, int value, int ratio, int salevalue)
        {
            string textname = "ProductsData.txt";
            StreamWriter Prod = new StreamWriter(textname, true);
            Prod.WriteLine(name + "," + value + "," + ratio + "," + salevalue);
            Prod.Close();
        }
        static void LoadProductsData()
        {
            string line;
            string textname = "ProductsData.txt";
            if (File.Exists(textname))
            {
                StreamReader Prod = new StreamReader(textname);
                while (!(Prod.EndOfStream))
                {
                    line = Prod.ReadLine();
                    if (line != "")
                    {
                        string[] splittedarray = line.Split(',');
                        Product[ProductsCount] = splittedarray[0];
                        Price[ProductsCount] = int.Parse(splittedarray[1]);
                        Quantity[ProductsCount] = int.Parse(splittedarray[2]);
                        /* OriginalQuantity[ProductsCount] = Quantity[ProductsCount]; */
                        Sale[ProductsCount] = int.Parse(splittedarray[3]);
                        ProductsCount++;
                    }
                }
                Prod.Close();
            }
        }
        static void UpdateProductsData()
        {
            string textname = "ProductsData.txt";
            StreamWriter Prod = new StreamWriter(textname);
            for (int x = 0; x < ProductsCount; x++)
            {
                Prod.WriteLine(Product[x] + "," + Price[x] + "," + Quantity[x] + "," + Sale[x]);
            }
            Prod.Close();
        }

        /* Announcements */
        static void StoreAnnouncements(string name, string announced)
        {
            string textname = "Announcements.txt";
            StreamWriter announce = new StreamWriter(textname, true);
            announce.WriteLine(name + "," + announced);
            announce.Close();
        }
        static void LoadAnnouncements()
        {
            string line;
            string textname = "Announcements.txt";
            if (File.Exists(textname))
            {
                StreamReader announce = new StreamReader(textname);
                while (!(announce.EndOfStream))
                {
                    line = announce.ReadLine();
                    if (line != "")
                    {
                        string[] array = line.Split(',');
                        ChatSender[Msg] = array[0];
                        Chat[Msg] = array[1];
                        Msg++;
                    }
                }
                announce.Close();
            }
        }

    }
}
