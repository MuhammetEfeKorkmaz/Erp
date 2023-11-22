using Castle.DynamicProxy;
using System.Reflection;

namespace Shared.Backend.Core.Aspects.Base
{
    public class InterceptorCollection : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<InterceptionBaseAttiribute>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<InterceptionBaseAttiribute>(true);
            classAttributes.AddRange(methodAttributes);
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
