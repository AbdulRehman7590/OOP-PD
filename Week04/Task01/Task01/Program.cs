using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01.BL;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            List<Ship> ships = new List<Ship>();
            do
            {
                Console.Clear();
                option = Menu();
                if (option == 1)
                {
                    ships.Add(AddShip());
                    Console.WriteLine("Ship Added !!!");
                }
                else if (option == 2)
                {
                    ViewShipPosition(ships).PrintShip();
                }
                else if (option == 3)
                {
                    Console.WriteLine("Ship serial is : " + ViewShipName(ships));
                }
                else if (option == 4)
                {
                    if (ChangeCoordinates(ships) == true)
                    {
                        Console.WriteLine("Data changed !!!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Data !!!");
                    }
                }
                else if (option == 5)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Option ");
                }
            }
            while (true);
        }

        static int Menu()
        {
            Console.WriteLine("1. Add Ship");
            Console.WriteLine("2. View Ship Position");
            Console.WriteLine("3. View Ship Serial number");
            Console.WriteLine("4. Change Ship Position");
            Console.WriteLine("5. Exit");
            Console.Write("Select option : ");
            return int.Parse(Console.ReadLine());
        }

        static Ship AddShip()
        {
            Console.Write("Enter Ship Serial Number : ");
            string serial = Console.ReadLine();

            Angle longitude = Coordinates("Longitude");

            Angle latitude = Coordinates("Latitude");

            Ship ship = new Ship(serial, longitude, latitude);

            return ship;
        }

        static Angle Coordinates(string n)
        {
            Console.Write("Enter" + n + "degree : ");
            int degree = int.Parse(Console.ReadLine());

            Console.Write("Enter" + n + " minutes : ");
            float minutes = float.Parse(Console.ReadLine());

            Console.Write("Enter" + n + " direction : ");
            char direction = char.Parse(Console.ReadLine());

            Angle data = new Angle(degree, minutes, direction);

            return data;
        }

        static Ship ViewShipPosition(List<Ship> Ships)
        {
            Console.Write("Enter Ship serial Number  : ");
            string name = Console.ReadLine();

            return Search(name, Ships);
        }

        static Ship Search(string n, List<Ship> ships)
        {
            for (int x = 0; x < ships.Count; x++)
            {
                if (n == ships[x].serial)
                {
                    return ships[x];
                }
            }
            return null;
        }

        static string ViewShipName(List<Ship> Ships)
        {
            Angle longi = Coordinates("longitude");

            Console.WriteLine(" ");

            Angle lati = Coordinates("latitude");

            return SearchbyCoordinates(longi, lati, Ships); ;
        }

        static string SearchbyCoordinates(Angle A, Angle B, List<Ship> Ships)
        {
            for (int x = 0; x < Ships.Count; x++)
            {
                if ((A.degree == Ships[x].longitude.degree && A.minutes == Ships[x].longitude.minutes && A.direction == Ships[x].longitude.direction) && (B.degree == Ships[x].latitude.degree && B.minutes == Ships[x].latitude.minutes && B.direction == Ships[x].latitude.direction))
                {
                    return Ships[x].serial;
                }
            }
            return null;
        }

        static bool ChangeCoordinates(List<Ship> Ships)
        {
            Console.WriteLine("Enter Ship serial : ");
            string name = Console.ReadLine();

            Ship data = Search(name, Ships);

            if (data != null)
            {
                data.longitude.UpdateData("Longitudde");

                data.latitude.UpdateData("Latitude");

                return true;
            }
            return false;
        }

    }
}
