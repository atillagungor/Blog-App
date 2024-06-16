using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.SecuredOperation
{
    public class SecuredOperation : MethodInterception
    {
        private readonly string[] _roles;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles, IServiceProvider serviceProvider)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = serviceProvider.GetService<IHttpContextAccessor>()
                ?? throw new ArgumentNullException(nameof(serviceProvider));
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
}