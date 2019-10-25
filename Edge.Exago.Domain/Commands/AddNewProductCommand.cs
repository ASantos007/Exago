using Edge.Exago.Domain.Validations;
using System;

namespace Edge.Exago.Domain.Commands
{
    public class AddNewProductCommand : CategoryCommand
    {
        public AddNewProductCommand(Guid categoryId, string name)
        {
            Id = categoryId;
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddNewProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}