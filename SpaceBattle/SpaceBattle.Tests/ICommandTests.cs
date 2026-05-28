using Moq;
using SpaceBattle.Lib;
using Xunit;

namespace SpaceBattle.Tests;

public class ICommandTests
{
    [Fact]
    public void ICommand_Implementation_Execute_Is_Called()
    {
        // Arrange: любая реализация ICommand через mock
        var commandMock = new Mock<ICommand>();
        ICommand command = commandMock.Object;

        // Act
        command.Execute();

        // Assert: контракт соблюден — Execute может быть вызван
        commandMock.Verify(c => c.Execute(), Times.Once);
    }
}
