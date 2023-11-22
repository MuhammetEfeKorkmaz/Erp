using _IdentityServer.Entities.DbModels;
using FluentValidation;
using Shared.Backend.Core.Aspects.Secured.Validation;

namespace _IdentityServer.Business.Services.ValidationRules
{
    public class UserOperationClaimsValidator : AbstractValidator<UserOperationClaims>
    {
        public UserOperationClaimsValidator(OperationType _operationType)
        {
            if (_operationType == OperationType.Add)
            {
                RuleFor(c => c.Id).Empty().WithMessage("Boş Olmalıdır.");

            }
            else if (_operationType == OperationType.Update)
            {
                RuleFor(c => c.Id).NotEmpty().WithMessage("boş geçilemez.").GreaterThan(1).WithMessage("Id Değeri 1 den büyük Olmalıdır.");
            }

            RuleFor(c => c.UserFID).GreaterThan(1).WithMessage("boş geçilemez.").LessThan(int.MaxValue).WithMessage("en fazla 4000 karakter olabilir.");
        }
    }
}
