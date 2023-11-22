using Castle.DynamicProxy;

namespace Shared.Backend.Core.Aspects.Base
{
    public abstract class ExceptionInterception : InterceptionBaseAttiribute
    {
        public bool IsThrow { get; set; }=false;
        public ExceptionInterception(bool _IsThrow)
        {
            IsThrow = _IsThrow;
        } 
        
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                if (IsThrow)
                    throw; 
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);



        }
    }
}
