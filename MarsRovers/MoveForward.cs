namespace CSharpTestProject
{
    internal class MoveForward : IRoverAction
    {
        public Rover Execute(Rover rover)
        {
            var x = rover.Orientation == Orientation.E ? rover.X + 1 :
                rover.Orientation == Orientation.W ? rover.X - 1 :
                rover.X;
            var y = rover.Orientation == Orientation.N ? rover.Y + 1 :
                rover.Orientation == Orientation.S ? rover.Y - 1 :
                rover.Y;
            return new Rover(x, y, rover.Orientation);
        }
    }
}