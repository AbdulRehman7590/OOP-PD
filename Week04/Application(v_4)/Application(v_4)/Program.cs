using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Application_v_4_.BL;

namespace Application_v_4_
{
    class Program
    {
        static string[] Chat = new string[100];
        static string[] ChatSender = new string[100];
        static string[,] Message = new string[100, 100];

        static int Msg = 0, MSGR = 0;

        static void Main(string[] args)
        {
            // List Declaration
            List<Credentials> loginInfo = new List<Credentials>();
            List<ProductsData> inventory = new List<ProductsData>();

            string pin = "";
            string number;

            /* Program loading  */
            LoadPin(ref pin);
            Loadlogindata(loginInfo);
            LoadProductsData(inventory);
            LoadAnnouncements();

            /* Working */
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
                    SignUp(loginInfo, pin);
                }
                else if (number == "2")
                {
                    SignIN(loginInfo, inventory, pin);
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
        static string AskingProduct()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Enter the name of the product : ");
            return Console.ReadLine();
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


        static void SignUp(List<Credentials> loginInfo, string pin)
        {
            Printmenu("Role Selection");

            int role = ReturnRole();

            if (role == 1)
            {
                if (CheckAdmin(loginInfo) == false)
                {
                    TakingInput(loginInfo, role);
                    PinSetup(ref pin);
                }
                else
                {
                    PinSignUp(loginInfo, role, pin);
                }
            }
            else if (role == 2)
            {
                PinSignUp(loginInfo, role, pin);
            }
            else if (role == 3)
            {
                TakingInput(loginInfo, role);
            }
            else if (role == 4)
            {
            }
            else
            {
                Console.WriteLine("Invalid number");
                Halt();
            }
        }
        static int ReturnRole()
        {
            Console.WriteLine("1. As Admin");
            Console.WriteLine("2. As Employee");
            Console.WriteLine("3. As Customer");
            Console.WriteLine("4. Move Back");
            SelectOpt();
            return int.Parse(Console.ReadLine());
        }
        static void PinSignUp(List<Credentials> loginInfo, int role, string pin)
        {
            if (EnterAdminCode(pin) == true)
            {
                TakingInput(loginInfo, role);
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine("You can't Sign Up without Pin");
                Halt();
            }
        }
        static void TakingInput(List<Credentials> loginInfo, int role)
        {
            string userName = EnterUserName();
            if (IsUserExists(loginInfo, userName) != -1)
            {
                Console.WriteLine(" ");
                Console.WriteLine("User Already Exists");
                Console.WriteLine(" ");
            }
            else
            {
                string password = EnterUserPass(userName);
                string contact = EnterUserContact(userName, password);

                Credentials info = new Credentials(role, userName, password, contact);
                loginInfo.Add(info);
                Storelogindata(loginInfo);

                Console.WriteLine(" ");
                Console.WriteLine("Sign Up Successfully");
                Console.WriteLine(" ");
            }
            Halt();
        }


        static string EnterUserName()
        {
            string name;
            Printmenu("Sign Up Screen");
            do
            {
                Console.Write("Enter Username : ");
                name = Console.ReadLine();
            }
            while (name == null);

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


        static bool IsNum(string data)
        {
            bool check = false;
            int isdigit;

            for (int count = 0; count < data.Length; count++)
            {
                isdigit = (int)(data[count]);
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


        static bool CheckAdmin(List<Credentials> loginInfo)
        {
            bool flag = false;
            foreach (var x in loginInfo)
            {
                flag = x.CheckAdmin();
                if (flag)
                {
                    break;
                }
            }
            return flag;
        }
        static void PinSetup(ref string pin)
        {
            Printmenu("Sign Up Screen");

            while (true)
            {
                Console.Write("Enter Pin (5-digit) to Login : ");
                pin = Console.ReadLine();
                if (pin.Length == 5 && IsNum(pin) == true)
                {
                    break;
                }
            }
            Console.WriteLine("Pin Updated! ");
            UpdatePin(pin);
            Halt();
        }
        static bool EnterAdminCode(string pin)
        {
            bool flag = false;
            string code;
            Console.Write("Enetr 5-digit Pin to Sign Up : ");
            code = Console.ReadLine();
            if (code == pin)
            {
                flag = true;
            }
            return flag;
        }


        static void SignIN(List<Credentials> loginInfo, List<ProductsData> inventory, string pin)
        {
            Printmenu("Sign-In Screen");
            bool counter = false;

            Console.Write("Enter the User-name : ");
            string name = Console.ReadLine();

            Console.Write("Enter the Password : ");
            string pass = Console.ReadLine();

            if (name != null && pass != null)
            {
                Credentials user = new Credentials(name, pass);
                counter = SigningIN(loginInfo, inventory, user, pin);
            }
            if (counter == false)
            {
                Console.WriteLine(" ");
                Console.WriteLine("No User Found !");
                Halt();
            }
        }
        static bool SigningIN(List<Credentials> loginInfo, List<ProductsData> inventory, Credentials user, string pin)
        {
            bool counter = false;

            for (int idx = 0; idx < loginInfo.Count; idx++)
            {
                if (loginInfo[idx].userName == user.userName && loginInfo[idx].password == user.password)
                {
                    if (loginInfo[idx].role == 1)
                    {
                        AdminInterface(loginInfo, inventory, user, pin);
                    }
                    else if (loginInfo[idx].role == 2)
                    {
                        /*Employeeinterface(inventory);*/
                    }
                    else if (loginInfo[idx].role == 3)
                    {
                        /* Customerinterface(inventory);*/
                    }
                    counter = true;
                    break;
                }
            }
            return counter;
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


        static void AdminInterface(List<Credentials> loginInfo, List<ProductsData> inventory, Credentials user, string pin)
        {
            string option;
            while (true)
            {
                ShowAdminControls();
                option = Console.ReadLine();

                if (option == "1")
                {
                    ProductView(inventory);
                }
                else if (option == "2")
                {
                    OnSaleproducts(inventory);
                }
                else if (option == "3")
                {
                    AddProduct(inventory);
                }
                else if (option == "4")
                {
                    UpdateProduct(inventory);
                }
                else if (option == "5")
                {
                    PlaceSale(inventory);
                }
                else if (option == "6")
                {
                    ManageEmployee(loginInfo);
                }
                else if (option == "7")
                {
                    CustomerTraffic(loginInfo);
                }
                else if (option == "8")
                {
                    Messenger(loginInfo, user.userName);
                }
                else if (option == "9")
                {
                    Announcements(user.userName);
                }
                else if (option == "10")
                {
                    PinSetup(ref pin);
                }
                else if (option == "11")
                {
                    ChangePass(loginInfo, user.userName);
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


        static void AddProduct(List<ProductsData> inventory)
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
                    PlusProduct(inventory);
                }
                else if (num == "2")
                {
                    MinusProduct(inventory);
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
        static void PlusProduct(List<ProductsData> inventory)
        {
            inventory.Add(TakingProductInput(inventory));
            StoreProductsData(inventory);

            Console.WriteLine(" ");
            Console.WriteLine("Product added successfully !");
            Halt();
        }
        static void MinusProduct(List<ProductsData> inventory)
        {
            string option, pname;
            int num;
            while (true)
            {
                Printmenu("Remove Products");

                SearchBack();
                SelectOpt();
                option = Console.ReadLine();

                if (option == "1")
                {
                    pname = AskingProduct();
                    num = IsProductExists(inventory, pname);
                    if (num != -1)
                    {
                        inventory.RemoveAt(num);
                        /* CartRemoving(ProductName);  */
                        StoreProductsData(inventory);

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


        static ProductsData TakingProductInput(List<ProductsData> inventory)
        {
            string productName = EnterProductName(inventory);
            float price = float.Parse(EnterProductPrice(productName));
            int quantity = int.Parse(EnterProductQuantity(productName, price));
            int sale = 0;

            ProductsData items = new ProductsData(productName, price, quantity, sale);

            return items;
        }
        static string EnterProductName(List<ProductsData> inventory)
        {
            string var;
            while (true)
            {
                Printmenu("Adding Product");
                var = AskingProduct();
                if (IsProductExists(inventory, var) != -1)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Product Already exists.");
                    Halt();
                }
                else if (var != null)
                {
                    break;
                }
            }
            return var;
        }
        static string EnterProductPrice(string pname)
        {
            string var;
            while (true)
            {
                Printmenu("Adding Product");
                Console.WriteLine("Enter the name of the product : " + pname);
                Console.Write("Enter the price of product (per piece) : ");
                var = Console.ReadLine();
                if (IsNum(var) == false)
                {
                    ValidNumber();
                }
                else if (var != null)
                {
                    break;
                }
            }
            return var;
        }
        static string EnterProductQuantity(string pname, float price)
        {
            string var;
            while (true)
            {
                Printmenu("Adding Product");
                Console.WriteLine("Enter the name of the product : " + pname);
                Console.WriteLine("Enter the price of product (per piece) : " + price);
                Console.Write("Enter the quantity of the product : ");
                var = Console.ReadLine();
                if (IsNum(var) == false)
                {
                    ValidNumber();
                }
                else if (var != null)
                {
                    break;
                }
            }
            return var;
        }


        static void UpdateProduct(List<ProductsData> inventory)
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
                    UpdatePrice(inventory);
                }
                else if (option == "2")
                {
                    UpdateQuantity(inventory);
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
        static void UpdatePrice(List<ProductsData> inventory)
        {
            string option, pname;
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
                    pname = AskingProduct();
                    idx = IsProductExists(inventory, pname);
                    if (idx != -1)
                    {
                        Console.WriteLine("Old Price is : " + inventory[idx].price);

                        Console.Write("Enter the new price : ");
                        inventory[idx].price = float.Parse(Console.ReadLine());

                        Console.WriteLine("  ");
                        Console.WriteLine("Price Updated !");
                        StoreProductsData(inventory);
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
        static void UpdateQuantity(List<ProductsData> inventory)
        {
            string option, pname;
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
                    pname = AskingProduct();
                    idx = IsProductExists(inventory, pname);
                    if (idx != -1)
                    {
                        Console.WriteLine("Old quantity is : " + inventory[idx].quantity);

                        Console.Write("Enter the new quantity : ");
                        inventory[idx].quantity = int.Parse(Console.ReadLine());

                        Console.WriteLine("  ");
                        Console.WriteLine("Quantity Updated !");
                        StoreProductsData(inventory);
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


        static void PlaceSale(List<ProductsData> inventory)
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
                    AddonSale(inventory);
                }
                else if (num == "2")
                {
                    RemovefromSale(inventory);
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
        static void AddonSale(List<ProductsData> inventory)
        {
            string option, pname;
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
                    pname = AskingProduct();
                    idx = IsProductExists(inventory, pname);
                    if (idx != -1)
                    {
                        Console.WriteLine(" ");
                        Console.Write("Place a sale of : ");
                        inventory[idx].sale = int.Parse(Console.ReadLine());
                        StoreProductsData(inventory);
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
        static void RemovefromSale(List<ProductsData> inventory)
        {
            string option, pname;
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
                    pname = AskingProduct();
                    idx = IsProductExists(inventory, pname);
                    if (idx != -1)
                    {
                        inventory[idx].sale = 0;
                        StoreProductsData(inventory);
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


        static void ManageEmployee(List<Credentials> loginInfo)
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
                    EmployeeDetails(loginInfo);
                }
                else if (option == "2")
                {
                    RemoveEmployee(loginInfo);
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
        static void EmployeeDetails(List<Credentials> loginInfo)
        {
            Printmenu("Employee Detail's");
            int index = 0;

            Console.WriteLine("Index".PadRight(20, ' ') + "Name".PadRight(20, ' ') + "Contact No.");
            Console.WriteLine(" ");
            for (int x = 0; x < loginInfo.Count; x++)
            {
                if (loginInfo[x].role == 2)
                {
                    index++;
                    Console.WriteLine((index.ToString()).PadRight(20, ' ') + (loginInfo[x].userName).PadRight(20, ' ') + "+92" + (loginInfo[x].contact));
                }
            }
            Halt();
        }
        static void RemoveEmployee(List<Credentials> loginInfo)
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
                    idx = IsUserExists(loginInfo, cname);
                    if (idx != -1 && loginInfo[idx].role == 2)
                    {
                        loginInfo.RemoveAt(idx);
                        Storelogindata(loginInfo);
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


        static void CustomerTraffic(List<Credentials> loginInfo)
        {
            Printmenu("Customer Traffic");
            int index = 0;

            Console.WriteLine("Index".PadRight(20, ' ') + "Name".PadRight(20, ' ') + "Contact no.");
            Console.WriteLine(" ");

            for (int x = 0; x < loginInfo.Count; x++)
            {
                if (loginInfo[x].role == 2)
                {
                    Console.WriteLine((index.ToString()).PadRight(20, ' ') + (loginInfo[x].userName).PadRight(20, ' ') + "+92 " + loginInfo[x].contact);
                }
            }
            Halt();
        }


        static void ChangePass(List<Credentials> loginInfo, string loginName)
        {
            Printmenu("Change Password");
            int idx;
            idx = IsUserExists(loginInfo, loginName);
            Console.WriteLine("Old Password is : " + loginInfo[idx].password);
            Console.WriteLine("");
            Console.Write("Enter new password : ");
            loginInfo[idx].password = EnterUserPass(loginInfo[idx].userName);
            /* Updatelogindata();*/
            Console.WriteLine(" ");
            Console.WriteLine("Password updated !");
            Halt();
        }


        static void Announcements(string loginName)
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
                    Sent(loginName);
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
        static void Sent(string loginName)
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
                    ChatSender[Msg] = loginName;
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
                Console.WriteLine(" ");
                Console.WriteLine("No New Announements!");
            }
            Halt();
        }


        static void Messenger(List<Credentials> loginInfo, string loginName)
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
                    SentMessage(loginInfo, loginName);
                }
                else if (option == "2")
                {
                    ReceivedMessage(loginName);
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
        static void SentMessage(List<Credentials> loginInfo, string loginName)
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
                    idx = IsUserExists(loginInfo, receiver);
                    if (idx != -1)
                    {
                        Message[MSGR, 0] = receiver;
                        for (int x = 0; x < MSGR; x++)
                        {
                            if (Message[x, 1] == loginName)
                            {
                                TypeMessage(x, Message);
                                status = true;
                                break;
                            }
                        }
                        if (status == false)
                        {
                            Message[MSGR, 1] = loginName;
                            TypeMessage(MSGR, Message);
                            MSGR++;
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
        static void TypeMessage(int x, string[,] Message)
        {
            int colIndex = 0;
            while (Message[x, colIndex] != null)
            {
                colIndex++;
            }
            Console.Write("Type Message : ");
            Message[x, colIndex] = Console.ReadLine();
        }
        static void ReceivedMessage(string loginName)
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
                    for (int x = 0; x < Message.GetLength(0); x++)
                    {
                        if (Message[x, 0] == loginName)
                        {
                            Printmenu("Received Messages");
                            for (int y = 2; y < Message.GetLength(1); y++)
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


        static void ProductView(List<ProductsData> inventory)
        {
            Printmenu("Products Details");

            if (inventory.Count > 0)
            {
                int index = 0;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Index" + "Name".PadLeft(20, ' ') + "Price".PadLeft(25, ' ') + "Quantity".PadLeft(20, ' '));
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.White;
                for (int x = 0; x < inventory.Count; x++)
                {
                    index++;
                    Console.WriteLine(index + (inventory[x].productName).PadLeft(25, ' ') + ((inventory[x].price).ToString()).PadLeft(20, ' ') + ((inventory[x].quantity).ToString()).PadLeft(20, ' '));
                }
            }
            else
            {
                Console.WriteLine("No product added!");
            }
            Halt();
        }
        static void OnSaleproducts(List<ProductsData> inventory)
        {
            Printmenu("Products on Sale");
            if (inventory.Count > 0)
            {
                int index = 0;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Index" + "Name".PadLeft(20, ' ') + "Price".PadLeft(20, ' ') + "Quantity".PadLeft(20, ' ') + "Sale".PadLeft(20, ' '));
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.White;
                for (int x = 0; x < inventory.Count; x++)
                {
                    if (inventory[x].sale > 0)
                    {
                        index++;
                        Console.WriteLine(index + (inventory[x].productName).PadLeft(25, ' ') + ((inventory[x].price).ToString()).PadLeft(20, ' ') + ((inventory[x].quantity).ToString()).PadLeft(20, ' ') + ((inventory[x].sale).ToString() + "%").PadLeft(20, ' '));
                    }
                }
            }
            else
            {
                Console.WriteLine("No product added!");
            }
            Halt();
        }


        static int IsUserExists(List<Credentials> loginInfo, string cname)
        {
            int num = -1;
            for (int x = 0; x < loginInfo.Count; x++)
            {
                if (loginInfo[x].userName == cname)
                {
                    num = x;
                    break;
                }
            }
            return num;
        }
        
        static int IsProductExists(List<ProductsData> inventory, string pname)
        {
            int num = -1;
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].productName == pname)
                {
                    num = i;
                    break;
                }
            }
            return num;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /*File Hadnling Functions*/

        /*User Data*/
        static void Storelogindata(List<Credentials> info)
        {
            StreamWriter myFile = new StreamWriter("UserData.txt");
            for (int x = 0; x < info.Count; x++)
            {
                myFile.WriteLine(info[x].role + "," + info[x].userName + "," + info[x].password + "," + info[x].contact);
            }
            myFile.Flush();
            myFile.Close();
        }
        static void Loadlogindata(List<Credentials> info)
        {
            string line;
            if (File.Exists("UserData.txt"))
            {
                StreamReader myFile = new StreamReader("UserData.txt");
                while (!(myFile.EndOfStream))
                {
                    line = myFile.ReadLine();
                    if (line != "")
                    {
                        string[] splitarray = line.Split(',');

                        int role = int.Parse(splitarray[0]);
                        string name = splitarray[1];
                        string password = splitarray[2];
                        string contact = splitarray[3];
                        if (name != null && password != null && contact != null)
                        {
                            Credentials data = new Credentials(role, name, password, contact);
                            info.Add(data);
                        }
                    }
                }
                myFile.Close();
            }
            else
            {
                Console.WriteLine("Unable to load data !!!");
            }
        }

        /*Admin Pin*/
        static void LoadPin(ref string pin)
        {
            if (File.Exists("AdminPin.txt"))
            {
                StreamReader File = new StreamReader("AdminPin.txt");
                pin = File.ReadLine();
                File.Close();
            }
        }
        static void UpdatePin(string pin)
        {
            StreamWriter File = new StreamWriter("AdminPin.txt");
            File.WriteLine(pin);
            File.Flush();
            File.Close();
        }

        /*Products Data*/
        static void StoreProductsData(List<ProductsData> inventory)
        {
            StreamWriter myFile = new StreamWriter("ProductsData.txt", true);
            for (int x = 0; x < inventory.Count; x++)
            {
                myFile.WriteLine(inventory[x].productName + "," + inventory[x].price + "," + inventory[x].quantity + "," + inventory[x].sale);
            }
            myFile.Flush();
            myFile.Close();
        }
        static void LoadProductsData(List<ProductsData> inventory)
        {
            string line;
            if (File.Exists("ProductsData.txt"))
            {
                StreamReader myFile = new StreamReader("ProductsData.txt");
                while (!(myFile.EndOfStream))
                {
                    line = myFile.ReadLine();
                    if (line != "")
                    {
                        string[] splittedarray = line.Split(',');

                        string productName = splittedarray[0];
                        float price = float.Parse(splittedarray[1]);
                        int quantity = int.Parse(splittedarray[2]);
                        int sale = int.Parse(splittedarray[3]);
                        if (productName != null && IsNum(price.ToString()) && IsNum(quantity.ToString()) && IsNum(sale.ToString()))
                        {
                            ProductsData data = new ProductsData(productName, price, quantity, sale);
                            inventory.Add(data);
                        }
                    }
                }
                myFile.Close();
            }
            else
            {
                Console.WriteLine("Unable to load Data !!!");
            }
        }

        /* Announcements */
        static void StoreAnnouncements(string name, string announced)
        {
            StreamWriter File = new StreamWriter("Announcements.txt", true);
            File.WriteLine(name + "," + announced);
            File.Close();
        }
        static void LoadAnnouncements()
        {
            string line;
            if (File.Exists("Announcements.txt"))
            {
                StreamReader File = new StreamReader("Announcements.txt");
                while (!(File.EndOfStream))
                {
                    line = File.ReadLine();
                    if (line != "")
                    {
                        string[] array = line.Split(',');
                        ChatSender[Msg] = array[0];
                        Chat[Msg] = array[1];
                        Msg++;
                    }
                }
                File.Close();
            }
        }

    }
}
