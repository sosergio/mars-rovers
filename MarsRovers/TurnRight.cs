namespace CSharpTestProject
{
    internal class TurnRight:IRoverAction
    {
        public Rover Execute(Rover rover)
        {
            var or = (int)rover.Orientation + 1;
            if (or > 3) or = 0;
            return new Rover(rover.X, rover.Y, (Orientation)or);
        }
    }
}