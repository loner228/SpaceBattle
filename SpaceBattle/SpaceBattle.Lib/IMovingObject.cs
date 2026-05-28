namespace SpaceBattle.Lib;

/// <summary>
/// Abstraction of an object capable of uniform translational motion.
/// MoveCommand depends on this abstraction (DIP), not on any concrete game object.
/// Implementations may throw if a property cannot be determined or changed.
/// </summary>
public interface IMovingObject
{
    Vector Position { get; set; }
    Vector Velocity { get; }
}
