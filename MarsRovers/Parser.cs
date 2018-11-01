using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CSharpTestProject
{
    internal class Parser
    {
        public Parser()
        {
        }

        internal Canvas ParseCanvas(string v)
        {
            var split = v.Split(" ");
            return new Canvas(int.Parse(split[0]), int.Parse(split[1]));
        }

        internal Rover ParseRover(string v)
        {
            var split = v.Split(" ");
            return new Rover(int.Parse(split[0]), int.Parse(split[1]), (Orientation)Enum.Parse(typeof(Orientation), split[2]));
        }

        internal IRoverAction ParseRoverAction(char c)
        {
            switch (c)
            {
                case 'L':return new TurnLeft();
                case 'R':return new TurnRight();
                case 'M':return new MoveForward();
                default: return null;
            }
        }

        internal IEnumerable<IRoverAction> ParseRoverActions(string v)
        {
            return v.ToCharArray().Select(ParseRoverAction);
        }
    }
}