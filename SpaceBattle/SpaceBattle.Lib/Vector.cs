using System;
using System.Linq;

namespace SpaceBattle.Lib;

/// <summary>
/// Immutable n-dimensional integer vector.
/// </summary>
public sealed class Vector : IEquatable<Vector>
{
    private readonly int[] _coords;

    public Vector(params int[] coords)
    {
        _coords = coords ?? throw new ArgumentNullException(nameof(coords));
    }

    public int Size => _coords.Length;

    public int this[int index] => _coords[index];

    public static Vector operator +(Vector a, Vector b)
    {
        if (a is null) throw new ArgumentNullException(nameof(a));
        if (b is null) throw new ArgumentNullException(nameof(b));
        if (a.Size != b.Size)
        {
            throw new ArgumentException(
                $"Vectors must have the same dimension. Got {a.Size} and {b.Size}.");
        }

        var result = new int[a.Size];
        for (var i = 0; i < a.Size; i++)
        {
            result[i] = a._coords[i] + b._coords[i];
        }
        return new Vector(result);
    }

    public bool Equals(Vector? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        if (Size != other.Size) return false;
        return _coords.SequenceEqual(other._coords);
    }

    public override bool Equals(object? obj) => obj is Vector v && Equals(v);

    public override int GetHashCode()
    {
        var hash = new HashCode();
        foreach (var c in _coords)
        {
            hash.Add(c);
        }
        return hash.ToHashCode();
    }

    public static bool operator ==(Vector? left, Vector? right)
    {
        if (left is null) return right is null;
        return left.Equals(right);
    }

    public static bool operator !=(Vector? left, Vector? right) => !(left == right);
}
