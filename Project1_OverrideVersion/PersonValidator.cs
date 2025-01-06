using FluentValidation;

namespace Project1_OverrideVersion;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        this.RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");

        this.RuleFor(p => p.Age)
            .InclusiveBetween(0, 120).WithMessage("Age must be between 0 and 120.");
    }
}
