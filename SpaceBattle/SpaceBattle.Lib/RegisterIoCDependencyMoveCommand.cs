using App;

namespace SpaceBattle.Lib;

/// <summary>
/// Registers IoC dependency "Commands.Move" which resolves to MoveCommand
/// constructed from a game object via "Adapters.IMovingObject".
/// This class is an ICommand itself, so registration becomes a composable action —
/// it can be added to startup macro-commands without modifying existing code (OCP).
/// </summary>
public sealed class RegisterIoCDependencyMoveCommand : ICommand
{
    public void Execute()
    {
        Ioc.Resolve<App.ICommand>("IoC.Register", "Commands.Move", (object[] args) =>
        {
            var movingObject = Ioc.Resolve<IMovingObject>("Adapters.IMovingObject", args[0]);
            return new MoveCommand(movingObject);
        }).Execute();
    }
}
