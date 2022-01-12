using Neocra.Xunit.Extensions;
using Xunit;

namespace Neocra.Core.Tests.Mvvm
{
    public class ViewModelBaseTests
    {
        [NamedFact]
        public void Should_notify_property_changed_when_raise_property()
        {
            var baseViewModel = new FakeViewModelBase();
            var watcher = new PropertyChangedWatcher();
            baseViewModel.PropertyChanged += watcher.PropertyChanged;

            baseViewModel.RaiseProperty();

            Assert.True(watcher.IsRaised);
        }

        [NamedFact]
        public void Should_notify_property_changed_toto_when_raise_property_toto()
        {
            var baseViewModel = new FakeViewModelBase();
            var watcher = new PropertyChangedWatcher();
            baseViewModel.PropertyChanged += watcher.PropertyChanged;

            baseViewModel.RaiseProperty("Toto");

            Assert.Equal("Toto", watcher.PropertyName);
        }

        [NamedFact]
        public void Should_notify_property_changed_toto_when_set_property()
        {
            var baseViewModel = new FakeViewModelBase();
            var watcher = new PropertyChangedWatcher();
            baseViewModel.PropertyChanged += watcher.PropertyChanged;

            baseViewModel.Toto = "Value";

            Assert.Equal("Toto", watcher.PropertyName);
        }
    }
}
