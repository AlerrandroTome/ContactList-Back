using ContactList.Core.Dtos.User;
using FluentValidation;

namespace ContactList.Infrastructure.Validators.User
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
            RuleFor(w => w.UserName).NotEmpty().Length(1, 200);

            RuleFor(w => w.Password).NotEmpty().Length(4, 10);

            RuleFor(w => w.Name).NotEmpty().Length(1,200);
        }
    }
}
