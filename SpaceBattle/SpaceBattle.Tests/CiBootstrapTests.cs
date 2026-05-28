using Xunit;
using SpaceBattle.Lib;

namespace SpaceBattle.Tests;

public class CiBootstrapTests
{
    [Fact]
    public void Ping_Returns_1()
    {
        Assert.Equal(1, CiBootstrap.Ping());
    }
}
