using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01.BL
{
    class Angle
    {
        public int degree;
        public float minutes;
        public char direction;

        public Angle(int degree, float minutes, char direction)
        {
            this.degree = degree;
            this.minutes = minutes;
            this.direction = direction;
        }

        public void PrintAngle()
        {
            Console.WriteLine(degree + "\u00b0" + minutes + "\u00b0" + "  " + direction + "\u00b0" + "\u00b0");
        }

        public void UpdateData(string n)
        {
            Console.Write("Enter " + n + " Degree : ");
            this.degree = int.Parse(Console.ReadLine());

            Console.Write("Enter " + n + " Minutes : ");
            this.minutes = float.Parse(Console.ReadLine());
            
            Console.Write("Enter " + n + " Direction : ");
            this.direction = char.Parse(Console.ReadLine());
        }
    }
}
