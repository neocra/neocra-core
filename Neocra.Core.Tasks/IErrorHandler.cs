using System;

namespace Neocra.Core.Tasks
{
    public interface IErrorHandler
    {
        void Handle(Exception ex);
    }
}