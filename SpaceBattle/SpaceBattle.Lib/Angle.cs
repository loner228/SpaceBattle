using System;

namespace SpaceBattle.Lib;

/// <summary>
/// Angle to the OX axis represented as a rational number Numerator / Denominator
/// of a full revolution. Denominator is shared across all angles in the system
/// (a static field) — addition is exact, no floating-point drift.
/// </summary>
public sealed class Angle : IEquatable<Angle>
{
    /// <summary>
    /// Shared denominator for all angles. Numerators are taken modulo this value.
    /// </summary>
    public static int Denominator { get; set; } = 8;

    public int Numerator { get; }

    public Angle(int numerator)
    {
        // Normalize to the range [0, Denominator) — ensures (15, 8) and (23, 8) are equal.
        var d = Denominator;
        Numerator = ((numerator % d) + d) % d;
    }

    public static Angle operator +(Angle a, Angle b)
    {
        if (a is null) throw new ArgumentNullException(nameof(a));
        if (b is null) throw new ArgumentNullException(nameof(b));
        return new Angle(a.Numerator + b.Numerator);
    }

    /// <summary>
    /// Implicit conversion to radians — enables Math.Cos(angle) / Math.Sin(angle)
    /// without an explicit (double) cast.
    /// </summary>
    public static implicit operator double(Angle angle)
    {
        if (angle is null) throw new ArgumentNullException(nameof(angle));
        return 2.0 * Math.PI * angle.Numerator / Denominator;
    }

    public bool Equals(Angle? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Numerator == other.Numerator;
    }

    public override bool Equals(object? obj) => obj is Angle a && Equals(a);

    public override int GetHashCode() => Numerator.GetHashCode();

    public static bool operator ==(Angle? left, Angle? right)
    {
        if (left is null) return right is null;
        return left.Equals(right);
    }

    public static bool operator !=(Angle? left, Angle? right) => !(left == right);
}
