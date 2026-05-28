using System;
using SpaceBattle.Lib;
using Xunit;

namespace SpaceBattle.Tests;

public class VectorTests
{
    [Fact]
    public void Addition_OfOppositeVectors_GivesZero()
    {
        var a = new Vector(1, -1, 2);
        var b = new Vector(-1, 1, -2);
        var expected = new Vector(0, 0, 0);

        var result = a + b;

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Addition_OfDifferentDimensions_3D_Plus_2D_Throws()
    {
        var a = new Vector(1, 2, 3);
        var b = new Vector(1, 2);

        Assert.Throws<ArgumentException>(() => a + b);
    }

    [Fact]
    public void Addition_OfDifferentDimensions_2D_Plus_3D_Throws()
    {
        var a = new Vector(1, 2);
        var b = new Vector(1, 2, 3);

        Assert.Throws<ArgumentException>(() => a + b);
    }

    [Fact]
    public void Equals_OnEqualCoordinatesButDifferentObjects_ReturnsTrue()
    {
        var a = new Vector(1, 2, 3);
        var b = new Vector(1, 2, 3);

        Assert.True(a.Equals(b));
    }

    [Fact]
    public void OperatorEq_OnEqualCoordinatesButDifferentObjects_ReturnsTrue()
    {
        var a = new Vector(1, 2, 3);
        var b = new Vector(1, 2, 3);

        Assert.True(a == b);
    }

    [Fact]
    public void Equals_OnDifferentCoordinates_ReturnsFalse()
    {
        var a = new Vector(1, 2, 3);
        var b = new Vector(1, 2, 4);

        Assert.False(a.Equals(b));
    }

    [Fact]
    public void OperatorNotEq_OnDifferentCoordinates_ReturnsTrue()
    {
        var a = new Vector(1, 2, 3);
        var b = new Vector(1, 2, 4);

        Assert.True(a != b);
    }

    [Fact]
    public void GetHashCode_IsAvailable()
    {
        var v = new Vector(1, 2, 3);

        // Сам факт того, что вызов GetHashCode не падает,
        // и одинаковые векторы дают одинаковый хэш — основа контракта.
        var hash1 = v.GetHashCode();
        var hash2 = new Vector(1, 2, 3).GetHashCode();

        Assert.Equal(hash1, hash2);
    }
}
