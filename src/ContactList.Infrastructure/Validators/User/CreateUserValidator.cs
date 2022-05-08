using ContactList.Core.Dtos.User;
using FluentValidation;

namespace ContactList.Infrastructure.Validators.User
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
        }
    }
}
