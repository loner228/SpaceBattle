using System;
using Moq;
using SpaceBattle.Lib;
using Xunit;

namespace SpaceBattle.Tests;

public class MoveCommandTests
{
    [Fact]
    public void Move_From_12_5_With_Velocity_minus4_1_Goes_To_8_6()
    {
        var obj = new Mock<IMovingObject>();
        obj.SetupProperty(o => o.Position, new Vector(12, 5));
        obj.SetupGet(o => o.Velocity).Returns(new Vector(-4, 1));

        var command = new MoveCommand(obj.Object);
        command.Execute();

        Assert.Equal(new Vector(8, 6), obj.Object.Position);
    }

    [Fact]
    public void Move_Throws_When_Position_Cannot_Be_Read()
    {
        var obj = new Mock<IMovingObject>();
        obj.SetupGet(o => o.Position).Throws(new InvalidOperationException("position unknown"));
        obj.SetupGet(o => o.Velocity).Returns(new Vector(1, 1));

        var command = new MoveCommand(obj.Object);

        Assert.Throws<InvalidOperationException>(() => command.Execute());
    }

    [Fact]
    public void Move_Throws_When_Velocity_Cannot_Be_Read()
    {
        var obj = new Mock<IMovingObject>();
        obj.SetupGet(o => o.Position).Returns(new Vector(1, 1));
        obj.SetupGet(o => o.Velocity).Throws(new InvalidOperationException("velocity unknown"));

        var command = new MoveCommand(obj.Object);

        Assert.Throws<InvalidOperationException>(() => command.Execute());
    }

    [Fact]
    public void Move_Throws_When_Position_Cannot_Be_Written()
    {
        var obj = new Mock<IMovingObject>();
        obj.SetupGet(o => o.Position).Returns(new Vector(1, 1));
        obj.SetupGet(o => o.Velocity).Returns(new Vector(1, 1));
        obj.SetupSet(o => o.Position = It.IsAny<Vector>())
           .Throws(new InvalidOperationException("position is read-only"));

        var command = new MoveCommand(obj.Object);

        Assert.Throws<InvalidOperationException>(() => command.Execute());
    }
}
