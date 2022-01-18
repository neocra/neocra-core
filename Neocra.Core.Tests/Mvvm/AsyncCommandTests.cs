using System;
using System.Threading.Tasks;
using Neocra.Core.Mvvm;
using Neocra.Xunit.Extensions;
using NSubstitute;
using Xunit;

namespace Neocra.Core.Tests.Mvvm;

public class AsyncCommandTests
{
    [NamedFact]
    public void Should_func_is_invoked_when_command_execute()
    {
        var action = Substitute.For<Func<Task>>();
        var relayCommand = new AsyncCommand(action);

        relayCommand.Execute(null);

        action.Received().Invoke();
    }
    
    [NamedFact]
    public void Should_can_execute_return_true_when_command_execute()
    {
        var action = Substitute.For<Func<Task>>();
        var relayCommand = new AsyncCommand(action);

        var val = relayCommand.CanExecute(null);

        Assert.True(val);
    }
}