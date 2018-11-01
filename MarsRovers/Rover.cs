using System.Collections.Generic;

namespace CSharpTestProject
{
    public class Rover
    {
        public Rover(int v1, int v2, Orientation orientation)
        {
            X = v1;
            Y = v2;
            Orientation = orientation;
        }

        public int X { get; }
        public int Y { get; }
        public Orientation Orientation { get; }

        public override string ToString()
        {
            return $"{X} {Y} {Orientation}";
        }
    }
}