using System;

namespace Neocra.Core.Tasks
{
    public class CombineErrorHandler : IErrorHandler
    {
        private readonly IErrorHandler parent;
        private readonly IErrorHandler handler;

        public CombineErrorHandler(IErrorHandler parent, IErrorHandler handler)
        {
            this.parent = parent;
            this.handler = handler;
        }

        public void Handle(Exception ex)
        {
            this.handler?.Handle(ex);
            this.parent?.Handle(ex);
        }
    }
}