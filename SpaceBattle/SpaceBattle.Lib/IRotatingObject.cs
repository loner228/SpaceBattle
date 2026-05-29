namespace SpaceBattle.Lib;

/// <summary>
/// Abstraction of an object capable of uniform rotation around its own axis.
/// RotateCommand depends on this abstraction (DIP), not on any concrete game object.
/// Implementations may throw if a property cannot be determined or changed.
/// </summary>
public interface IRotatingObject
{
    Angle Direction { get; set; }
    Angle AngularVelocity { get; }
}
