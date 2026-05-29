using System;
using Moq;
using SpaceBattle.Lib;
using Xunit;

namespace SpaceBattle.Tests;

public class RotateCommandTests
{
    [Fact]
    public void Rotate_From_45_Degrees_With_AngularVelocity_45_Goes_To_90()
    {
        // Denominator = 8 → 45° = 1/8 оборота, 90° = 2/8 оборота.
        var obj = new Mock<IRotatingObject>();
        obj.SetupProperty(o => o.Direction, new Angle(1));
        obj.SetupGet(o => o.AngularVelocity).Returns(new Angle(1));

        var command = new RotateCommand(obj.Object);
        command.Execute();

        Assert.Equal(new Angle(2), obj.Object.Direction);
    }

    [Fact]
    public void Rotate_Throws_When_Direction_Cannot_Be_Read()
    {
        var obj = new Mock<IRotatingObject>();
        obj.SetupGet(o => o.Direction).Throws(new InvalidOperationException("direction unknown"));
        obj.SetupGet(o => o.AngularVelocity).Returns(new Angle(1));

        var command = new RotateCommand(obj.Object);

        Assert.Throws<InvalidOperationException>(() => command.Execute());
    }

    [Fact]
    public void Rotate_Throws_When_AngularVelocity_Cannot_Be_Read()
    {
        var obj = new Mock<IRotatingObject>();
        obj.SetupGet(o => o.Direction).Returns(new Angle(1));
        obj.SetupGet(o => o.AngularVelocity).Throws(new InvalidOperationException("angular velocity unknown"));

        var command = new RotateCommand(obj.Object);

        Assert.Throws<InvalidOperationException>(() => command.Execute());
    }

    [Fact]
    public void Rotate_Throws_When_Direction_Cannot_Be_Written()
    {
        var obj = new Mock<IRotatingObject>();
        obj.SetupGet(o => o.Direction).Returns(new Angle(1));
        obj.SetupGet(o => o.AngularVelocity).Returns(new Angle(1));
        obj.SetupSet(o => o.Direction = It.IsAny<Angle>())
           .Throws(new InvalidOperationException("direction is read-only"));

        var command = new RotateCommand(obj.Object);

        Assert.Throws<InvalidOperationException>(() => command.Execute());
    }
}
