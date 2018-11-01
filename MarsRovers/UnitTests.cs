using System;
using System.Linq;
using Xunit;

namespace CSharpTestProject
{
    public class UnitTests
    {
        [Fact]
        public void ParseCanvasShouldReturnACanvas()
        {
            Canvas canvas = new Parser().ParseCanvas("5 5");
            Assert.IsType<Canvas>(canvas);
        }
        [Fact]
        public void ParseCanvasShouldReturnACanvasWithCorrectDimensions()
        {
            Canvas canvas = new Parser().ParseCanvas("5 10");
            Assert.Equal(5, canvas.Width);
            Assert.Equal(10, canvas.Heigth);
        }

        [Fact]
        public void ParseShouldReturnARoverWithCorrectPositionAndOrientation()
        {
            Rover rover = new Parser().ParseRover("1 2 N");
            Assert.Equal(1, rover.X);
            Assert.Equal(2, rover.Y);
            Assert.Equal(Orientation.N, rover.Orientation);

        }

        [Theory]
        [InlineData(Orientation.N, Orientation.W)]
        [InlineData(Orientation.W, Orientation.S)]
        [InlineData(Orientation.S, Orientation.E)]
        [InlineData(Orientation.E, Orientation.N)]
        public void TurnLeftShouldMoveRoverToTheRightPosition(Orientation startOr, Orientation endOr)
        {
            var rover = new TurnLeft().Execute(new Rover(1, 1, startOr));
            Assert.Equal(endOr, rover.Orientation);
        }

        [Theory]
        [InlineData(Orientation.N, Orientation.E)]
        [InlineData(Orientation.E, Orientation.S)]
        [InlineData(Orientation.S, Orientation.W)]
        [InlineData(Orientation.W, Orientation.N)]
        public void TurnRightShouldMoveRoverToTheRightPosition(Orientation startOr, Orientation endOr)
        {
            var rover = new TurnRight().Execute(new Rover(1, 1, startOr));
            Assert.Equal(endOr, rover.Orientation);
        }

        [Theory]
        [InlineData(1, 1, Orientation.N, 1, 2)]
        [InlineData(1, 1, Orientation.S, 1, 0)]
        [InlineData(1, 1, Orientation.E, 2, 1)]
        [InlineData(1, 1, Orientation.W, 0, 1)]
        public void MoveForwardShouldMoveRoverToTheRightPosition(int startX, int startY, Orientation or, int endX, int endY)
        {
            var rover = new MoveForward().Execute(new Rover(startX, startY, or));
            Assert.Equal(endX, rover.X);
            Assert.Equal(endY, rover.Y);
        }

        [Theory]
        [InlineData('R', typeof(TurnRight))]
        [InlineData('L', typeof(TurnLeft))]
        [InlineData('M', typeof(MoveForward))]
        public void ParseShouldReturnTheMatchingRoverAction(char c, Type type)
        {
            IRoverAction action = new Parser().ParseRoverAction(c);
            Assert.Equal(type, action.GetType());
        }

        [Fact]
        public void TestMission()
        {
            var parser = new Parser();
            var canvas = parser.ParseCanvas("5 5");
            var rover = parser.ParseRover("1 2 N");
            var actions = parser.ParseRoverActions("LMLMLMLMM");

            actions.ToList().ForEach(a => rover = a.Execute(rover));
            Assert.Equal("1 3 N", rover.ToString());
        }

    }
    
}
