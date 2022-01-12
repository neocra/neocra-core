using System;
using System.Threading.Tasks;

namespace Neocra.Core.Mvvm.Forms
{
    public interface INavigateFrom
    {
        Task NavigateFrom(Type toPage);
    }
}