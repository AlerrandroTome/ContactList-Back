using ContactList.Core.Dtos.Login;
using FluentValidation;

namespace ContactList.Infrastructure.Validators.Login
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(w => w.UserName).NotEmpty()
                     .NotNull()
                     .MinimumLength(5);

            RuleFor(w => w.Password).NotEmpty().Length(4, 10);
        }
    }
}
