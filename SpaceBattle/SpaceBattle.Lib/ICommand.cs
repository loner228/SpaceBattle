namespace SpaceBattle.Lib;

/// <summary>
/// Base interface for all game commands.
/// Satisfies SOLID:
/// - SRP: single responsibility — execute a command;
/// - OCP: new commands are added by implementing this interface, no existing code is modified;
/// - LSP: any implementation is substitutable wherever ICommand is expected;
/// - ISP: minimal interface — only what every command must support;
/// - DIP: high-level modules depend on this abstraction, not on concrete commands.
/// </summary>
public interface ICommand
{
    void Execute();
}
