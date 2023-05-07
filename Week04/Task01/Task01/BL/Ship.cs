using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01.BL;

namespace Task01.BL
{
    class Ship
    {
        public string serial;
        public Angle longitude;
        public Angle latitude;

        public Ship(string serial, Angle longitude, Angle latitude)
        {
            this.serial = serial;
            this.longitude = longitude;
            this.latitude = latitude;
        }

        public void PrintShip()
        {
            Console.WriteLine("Ship is at ");
            Console.Write("Longitude : ");
            this.longitude.PrintAngle();
            Console.Write("Latitude : ");
            this.latitude.PrintAngle();
            Console.ReadKey();
        }
    }
}
