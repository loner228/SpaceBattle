using System;
using SpaceBattle.Lib;
using Xunit;

namespace SpaceBattle.Tests;

public class AngleTests
{
    [Fact]
    public void Addition_Of_5_And_7_With_Denominator_8_Gives_4()
    {
        var a = new Angle(5);
        var b = new Angle(7);

        var result = a + b;

        Assert.Equal(new Angle(4), result);
    }

    [Fact]
    public void Equals_OnAngles_15_And_23_WithDenominator_8_ReturnsTrue()
    {
        var a = new Angle(15);
        var b = new Angle(23);

        Assert.True(a.Equals(b));
    }

    [Fact]
    public void OperatorEq_OnAngles_15_And_23_WithDenominator_8_ReturnsTrue()
    {
        var a = new Angle(15);
        var b = new Angle(23);

        Assert.True(a == b);
    }

    [Fact]
    public void Equals_OnAngles_1_And_2_WithDenominator_8_ReturnsFalse()
    {
        var a = new Angle(1);
        var b = new Angle(2);

        Assert.False(a.Equals(b));
    }

    [Fact]
    public void OperatorNotEq_OnAngles_1_And_2_WithDenominator_8_ReturnsTrue()
    {
        var a = new Angle(1);
        var b = new Angle(2);

        Assert.True(a != b);
    }

    [Fact]
    public void GetHashCode_IsAvailable_AndConsistentWithEquals()
    {
        var a = new Angle(15);
        var b = new Angle(23); // те же значения после нормализации

        Assert.Equal(a.GetHashCode(), b.GetHashCode());
    }

    [Fact]
    public void Math_Cos_Accepts_Angle_Without_Explicit_Cast()
    {
        // Дополнительный тест на implicit double — закрывает требование задания
        // "вычисление синуса и косинуса от Angle без предварительного явного приведения".
        var angle = new Angle(0);

        var cos = Math.Cos(angle);
        var sin = Math.Sin(angle);

        Assert.Equal(1.0, cos, precision: 10);
        Assert.Equal(0.0, sin, precision: 10);
    }
}
