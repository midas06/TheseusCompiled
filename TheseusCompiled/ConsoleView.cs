using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheseusCompiled
{
    class ConsoleView : IView
    {
        // GENERIC
        public void Start()
        {
            Console.Clear();
        }
        public void Stop()
        {
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
        public void Display<T>(T message)
        {
            Console.WriteLine(message);
        }


        // FILER
        public int ChoosePool(string prompt = "")
        {
            Console.WriteLine(prompt);
            return int.Parse(Console.ReadLine());
        }


        // GAME
        public string SetLevel(string prompt = "")
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        // BUILDER
        public Point SetDimensions(string prompt = "")
        {
            Point point = new Point();
            Console.WriteLine(prompt);
            Console.WriteLine("set X");
            point.X = int.Parse(Console.ReadLine());
            Console.WriteLine("set Y");
            point.Y = int.Parse(Console.ReadLine());
            return point;
        }


    }
}
