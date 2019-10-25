using Edge.Exago.Domain.Validations;

namespace Edge.Exago.Domain.Commands
{
    public class RegisterNewCategoryCommand : CategoryCommand
    {
        public RegisterNewCategoryCommand(string name)
        {
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewCategoryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}