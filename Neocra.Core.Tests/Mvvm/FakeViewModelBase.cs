using Neocra.Core.Mvvm;

 namespace Neocra.Core.Tests.Mvvm
{
    public class FakeViewModelBase : ViewModelBase
    {
        private string toto;

        public string Toto
        {
            get { return this.toto; }
            set
            {
                this.toto = value;
                base.RaisePropertyChanged();
            }
        }

        internal void RaiseProperty(string propertyName = "")
        {
            base.RaisePropertyChanged(propertyName);
        }
    }
}