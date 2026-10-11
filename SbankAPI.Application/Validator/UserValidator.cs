using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SbankAPI.Application.Dto;

namespace SbankAPI.Application.Validator
{
    public class UserValidator : AbstractValidator<CreateUserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("User name is required")
                .NotNull().WithMessage("User name cannot be null")
                .MaximumLength(100).WithMessage("User name should not be more than 100 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .NotNull().WithMessage("Email cannot be null")
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("Invalid email address");

            RuleFor(x => x.Mobile)
                .NotEmpty().WithMessage("Mobile number is required")
                .NotNull().WithMessage("Mobile number cannot be null")
                .MaximumLength(12).WithMessage("Mobile number should not exceed 12 characters");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .NotNull().WithMessage("Password cannot be null")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters");
        }
    }
}
