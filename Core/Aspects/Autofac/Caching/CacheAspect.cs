using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Newtonsoft.Json;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private readonly int _duration;
        private readonly ICacheManager _cacheManager;

        public CacheAspect(ICacheManager cacheManager, int duration = 60)
        {
            _cacheManager = cacheManager ?? throw new ArgumentNullException(nameof(cacheManager));
            _duration = duration;
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = $"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}";
            var arguments = invocation.Arguments.ToList();

            var key = GenerateCacheKey(methodName, arguments);

            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }

            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }

        private string GenerateCacheKey(string methodName, List<object> arguments)
        {
            var argList = arguments.Select(arg => JsonConvert.SerializeObject(arg) ?? "<Null>").ToList();
            var key = $"{methodName}({string.Join(",", argList)})";
            return key;
        }
    }
}