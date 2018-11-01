namespace CSharpTestProject
{
    internal class TurnLeft : IRoverAction
    {
        public Rover Execute(Rover rover)
        {
            var or = (int)rover.Orientation-1;
            if (or < 0) or = 3;
            return new Rover(rover.X, rover.Y, (Orientation)or);
        }
    }
}