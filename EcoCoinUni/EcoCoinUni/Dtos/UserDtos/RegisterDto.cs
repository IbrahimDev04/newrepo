using FluentValidation;
using System.Text.RegularExpressions;

namespace EcoCoinUni.Dtos.UserDtos;

public class RegisterDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmedPassword { get; set; }
}

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .MaximumLength(32);

        RuleFor(c => c.Surname)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .MaximumLength(32);

        RuleFor(c => c.Email)
            .NotEmpty()
            .NotNull()
            .Must(u =>
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                var result = regex.Match(u);
                return result.Success;
            })
                .WithMessage("Please enter valid Email");

        RuleFor(u => u.Username)
            .NotEmpty()
            .NotNull()
            .MinimumLength(6)
            .MaximumLength(45);

        RuleFor(u => u.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(6);

        RuleFor(u => u)
            .Must(u => u.Password == u.ConfirmedPassword)
                .WithMessage("Password must be equal to ConfirmedPassword");
    }
}
