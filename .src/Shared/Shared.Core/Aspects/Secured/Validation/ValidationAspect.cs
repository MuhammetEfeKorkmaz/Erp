using Castle.DynamicProxy;
using FluentValidation;
using Shared.Backend.Core.Aspects.Base;

namespace Shared.Backend.Core.Aspects.Secured.Validation
{
    public class ValidationAspect : NormalInterception
    {
        private Type _validatorType;
        private OperationType _operationType;
        public ValidationAspect(Type validatorType, OperationType operationType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("!Bu bir doğrulama sınıfı değil");
            }
            _validatorType = validatorType;
            _operationType = operationType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType, _operationType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            bool IsList = false;
            foreach (var entity in entities)
            {
                IsList = true;
                Validate(invocation, validator, entity);
            }

            if (!IsList)
            {
                var list = invocation.Arguments.FirstOrDefault();
                Type listType = list.GetType();
                var listCount_ = (Int32)listType.GetMethod("get_Count").Invoke(list, null);

                for (int i = 0; i < listCount_; i++)
                {
                    var entity = list.GetType().GetMethod("get_Item").Invoke(list, new object[] { i });
                    Validate(invocation, validator, entity);
                }
            }
        }

        private static void Validate(IInvocation invocation, IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
                var arguments = invocation.Arguments.ToList();
                var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
                throw new FluentValidation.ValidationException(key, result.Errors);
            }
        }

    }
}
