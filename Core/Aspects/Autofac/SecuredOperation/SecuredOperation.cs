using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Core.Aspects.Autofac.SecuredOperation
{
    public class SecuredOperation : MethodInterception
    {
        private readonly string[] _roles;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            // IHttpContextAccessor'ı ServiceTool üzerinden alır
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>()
                ?? throw new ArgumentNullException(nameof(IServiceProvider), "IHttpContextAccessor could not be resolved.");
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

            if (!roleClaims.Intersect(_roles).Any())
            {
                throw new System.Exception(AspectMessages.AccessDenied);
            }
        }
    }

    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; set; }
    }
}