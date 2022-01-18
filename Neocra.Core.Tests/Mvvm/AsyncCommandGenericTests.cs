using System;
using System.Threading.Tasks;
using Neocra.Core.Mvvm;
using Neocra.Xunit.Extensions;
using NSubstitute;
using Xunit;

namespace Neocra.Core.Tests.Mvvm;

public class AsyncCommandGenericTests
{
    [NamedFact]
    public void Should_func_is_invoked_when_command_execute()
    {
        var action = Substitute.For<Func<int, Task>>();
        var relayCommand = new AsyncCommand<int>(action);

        relayCommand.Execute(1);

        action.Received().Invoke(Arg.Any<int>());
    }
    
    [NamedFact]
    public void Should_can_execute_return_true_when_command_execute()
    {
        var action = Substitute.For<Func<int, Task>>();
        var relayCommand = new AsyncCommand<int>(action);

        var val = relayCommand.CanExecute(1);

        Assert.True(val);
    }
    
    [NamedFact]
    public void Should_func_is_invoked_when_send_null_in_parameter()
    {
        var action = Substitute.For<Func<int, Task>>();
        var relayCommand = new AsyncCommand<int>(action, canExecute: i => true);

        relayCommand.Execute(null);

        action.Received().Invoke(Arg.Any<int>());
    }
    
    [NamedFact]
    public void Should_can_execute_return_true_when_send_null_in_parameter()
    {
        var action = Substitute.For<Func<int, Task>>();
        var relayCommand = new AsyncCommand<int>(action, canExecute: i => true);

        var val = relayCommand.CanExecute(null);

        Assert.True(val);
    }
}