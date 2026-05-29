namespace SpaceBattle.Lib;

/// <summary>
/// Uniform rotation command around the object's own axis, for one discrete tick.
/// NewDirection = Direction + AngularVelocity.
/// </summary>
public sealed class RotateCommand : ICommand
{
    private readonly IRotatingObject _obj;

    public RotateCommand(IRotatingObject obj)
    {
        _obj = obj;
    }

    public void Execute()
    {
        _obj.Direction = _obj.Direction + _obj.AngularVelocity;
    }
}
