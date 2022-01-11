using System;
using System.Threading.Tasks;

namespace Neocra.Core.Tasks
{
    public static class TaskExtensions
    {
        private static IErrorHandler? defaultHandler;

        public static async void Fire(this Task task, ILoadingHandler? loadingHandler = null)
        {
            loadingHandler?.StartLoading();
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                defaultHandler?.Handle(ex);
            }
            finally
            {
                loadingHandler?.StopLoading();
            }
        }

        public static async void Fire(this Task task, IErrorHandler errorHandler)
        {
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                errorHandler.Handle(ex);
            }
        }

        public static IErrorHandler UseDefault(this IErrorHandler errorHandler)
        {
            defaultHandler = errorHandler;

            return errorHandler;
        }

        public static IErrorHandler CombineWithDefault(this IErrorHandler errorHandler)
        {
            _ = defaultHandler ?? throw new ArgumentException("No default handler found");
            
            return new CombineErrorHandler(defaultHandler, errorHandler);
        }
    }
}
