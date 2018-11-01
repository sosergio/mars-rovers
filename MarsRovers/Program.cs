using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpTestProject
{
    public class Program
    {
        public static void Main(string[] input)
        {
            var parser = new Parser();
            var canvas = parser.ParseCanvas(Console.ReadLine());
            var rover1 = parser.ParseRover(Console.ReadLine());
            var actions1 = parser.ParseRoverActions(Console.ReadLine());
            var rover2 = parser.ParseRover(Console.ReadLine());
            var actions2 = parser.ParseRoverActions(Console.ReadLine());

            actions1.ToList().ForEach(a => rover1 = a.Execute(rover1));
            actions2.ToList().ForEach(a => rover2 = a.Execute(rover2));

            Console.WriteLine(rover1.ToString());
            Console.WriteLine(rover2.ToString());
            Console.ReadKey();
        }
    }
}
