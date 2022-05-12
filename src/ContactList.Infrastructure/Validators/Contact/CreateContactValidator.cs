using ContactList.Core.Dtos.Contact;
using FluentValidation;

namespace ContactList.Infrastructure.Validators.Contact
{
    public class CreateContactValidator : AbstractValidator<CreateContactDto>
    {
        public CreateContactValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.Email).Length(1,200);
            RuleFor(p => p.PhoneNumber).Length(1,20);
            RuleFor(p => p.WhatsappNumber).Length(1,20);
        }
    }
}
