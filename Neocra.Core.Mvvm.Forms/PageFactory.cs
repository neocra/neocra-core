using System;
using Pattern.Core.Interfaces;
using Pattern.Core.Interfaces.Factories;
using Xamarin.Forms;

namespace Neocra.Core.Mvvm.Forms
{
    public class PageFactory : TypeFactory
    {
        private readonly IKernel kernel;
        private readonly Type viewModelType;

        public PageFactory(Type typeToCreate, Type viewModelType, IKernel kernel) : base(typeToCreate, kernel)
        {
            this.kernel = kernel;
            this.viewModelType = viewModelType;
        }

        public override object Create(CallContext context)
        {
            var instancePage = base.Create(context) as Page;

            if (instancePage != null)
            {
                var viewModel = (ViewModelBase)(this.kernel.Get(this.viewModelType) ?? throw new ArgumentException($"Not found viewmodel type {this.viewModelType}"));
                instancePage.BindingContext = viewModel;
                return instancePage;
            }

            return null!;
        }
    }
}