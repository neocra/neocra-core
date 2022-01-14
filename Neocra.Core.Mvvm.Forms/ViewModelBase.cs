using System.Threading.Tasks;
using Neocra.Core.Tasks;

namespace Neocra.Core.Mvvm.Forms
{
    public abstract class ViewModelBase : Neocra.Core.Mvvm.ViewModelBase, ILoadingHandler
    {
        private bool isLoading;

        public bool IsLoading
        {
            get => this.isLoading;
            set => this.Set(ref this.isLoading, value);
        }
        
         public virtual Task AfterNavigationAsync()
         {
             return Task.CompletedTask;
         }

        public virtual void StartLoading()
        {
            this.IsLoading = true;
        }

        public virtual void StopLoading()
        {
            this.IsLoading = false;
        }
        
        
        private bool isInit = false;
        
        internal object? Parameter { get; set; }

        public T GetParameter<T>()
        {
            return (T)this.Parameter!;
        }
        
        public Task InitOrResumeAsync(object? parameter = null)
        {
            this.Parameter = parameter;

            if (!this.isInit)
            {
                this.isInit = true;
                return this.InitAsync();
            }
            
            return this.Resume();
        }
        
        protected virtual Task InitAsync()
        {
            return Task.CompletedTask;
        }

        protected virtual Task Resume()
        {
            return Task.CompletedTask;
        }
    }
}