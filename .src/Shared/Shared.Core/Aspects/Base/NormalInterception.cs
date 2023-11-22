using Castle.DynamicProxy;

namespace Shared.Backend.Core.Aspects.Base
{
    public abstract class NormalInterception : InterceptionBaseAttiribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            OnBefore(invocation);

            invocation.Proceed();

            OnAfter(invocation);
        }
    }
}
