using Castle.DynamicProxy;
using Serilog;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected ILogger Logger { get; }

        public MethodInterception()
        {
            Logger = Log.Logger.ForContext(GetType());
        }

        protected virtual void OnBefore(IInvocation invocation)
        {
            Logger.Information($"Before invocation of {invocation.Method.Name}");
        }

        protected virtual void OnAfter(IInvocation invocation)
        {
            Logger.Information($"After invocation of {invocation.Method.Name}");
        }

        protected virtual void OnException(IInvocation invocation, Exception e)
        {
            Logger.Error(e, $"Error during invocation of {invocation.Method.Name}");
        }

        protected virtual void OnSuccess(IInvocation invocation)
        {
            Logger.Information($"Invocation of {invocation.Method.Name} completed successfully.");
        }

        public override void Intercept(IInvocation invocation)
        {
            bool isSuccess = true;
            try
            {
                OnBefore(invocation);
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
                OnAfter(invocation);
            }
        }
    }
}