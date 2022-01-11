using System;
using Neocra.Core.Mvvm;
using Neocra.Xunit.Extensions;
using NSubstitute;
using Xunit;

namespace Neocra.Core.Tests.Mvvm
{
    public class RelayCommandTests
    {
        [NamedFact]
        public void Should_action_invoked_when_command_execute()
        {
            var action = Substitute.For<Action>();
            var relayCommand = new RelayCommand(action);

            relayCommand.Execute(null);

            action.Received().Invoke();
        }

        [NamedFact]
        public void Should_action_is_not_invoked_when_command_can_execute_return_false()
        {
            var action = Substitute.For<Action>();
            var relayCommand = new RelayCommand(action, () => false);

            relayCommand.Execute(null);

            action.DidNotReceive().Invoke();
        }

        [NamedFact]
        public void Should_can_execute_return_false_when_command_can_execute_return_false()
        {
            var action = Substitute.For<Action>();
            var relayCommand = new RelayCommand(action, () => false);

            relayCommand.Execute(null);

            Assert.False(relayCommand.CanExecute(null));
        }
    }
}
