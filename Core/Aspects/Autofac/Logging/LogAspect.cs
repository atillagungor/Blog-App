using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.Utilities.Interceptors;
using Serilog;
using System.Collections.Generic;

namespace Core.Aspects.Autofac.Logging
{
    public class LogAspect : MethodInterception
    {
        private readonly ILogger _logger;

        public LogAspect(ILogger logger)
        {
            _logger = logger;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var logDetail = GetLogDetail(invocation);
            _logger.Information(logDetail.ToString());
        }

        private LogDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i]?.GetType().Name ?? "null"
                });
            }

            var logDetail = new LogDetail
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };
            return logDetail;
        }
    }
}