using App;
using App.Scopes;
using Moq;
using SpaceBattle.Lib;
using Xunit;

namespace SpaceBattle.Tests;

public class RegisterIoCDependencyMoveCommandTests
{
    public RegisterIoCDependencyMoveCommandTests()
    {
        // Inicialize IoC and switch to a fresh scope so each test is isolated.
        new InitCommand().Execute();
        var scope = Ioc.Resolve<object>("IoC.Scope.Create");
        Ioc.Resolve<App.ICommand>("IoC.Scope.Current.Set", scope).Execute();
    }

    [Fact]
    public void Execute_Registers_CommandsMove_Dependency_Resolvable_To_MoveCommand()
    {
        // Arrange: any game object — its concrete type doesn't matter, only the adapter does.
        var gameObject = new object();

        // Mock the adapter dependency that MoveCommand requires (DIP — we depend on the abstraction).
        var movingMock = new Mock<IMovingObject>();
        Ioc.Resolve<App.ICommand>(
            "IoC.Register",
            "Adapters.IMovingObject",
            (object[] args) => movingMock.Object).Execute();

        // Act: register Commands.Move.
        new RegisterIoCDependencyMoveCommand().Execute();

        // Assert: dependency resolves to a MoveCommand instance.
        var resolved = Ioc.Resolve<SpaceBattle.Lib.ICommand>("Commands.Move", gameObject);
        Assert.IsType<MoveCommand>(resolved);
    }
}
