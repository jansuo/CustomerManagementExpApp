using CustomersAPI.Models;
using FluentValidation;
namespace CustomersAPI.Validators
{
    public class CustomerValidator : AbstractValidator<CustomerModel>
    {
        public CustomerValidator()
        {
            RuleFor(model => model.Email)
                .EmailAddress()
                .WithMessage("Invalid email address");
            RuleFor(model => model.FirstName)
                .NotEmpty()
                .WithMessage("First name is empty");
            RuleFor(model => model.LastName)
                .NotEmpty()
                .WithMessage("Last name is empty");
        }
    }
}
