using FluentValidation;

namespace EcoCoinUni.Dtos.UserDtos;

public class LoginDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}
public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {

        RuleFor(u => u.Username)
            .NotEmpty()
            .NotNull()
            .MinimumLength(6)
            .MaximumLength(45);

        RuleFor(u => u.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(6);
    }
}
