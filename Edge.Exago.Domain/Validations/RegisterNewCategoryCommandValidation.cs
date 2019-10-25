using Edge.Exago.Domain.Commands;

namespace Edge.Exago.Domain.Validations
{
    public class RegisterNewCategoryCommandValidation : CategoryValidation<RegisterNewCategoryCommand>
    {
        public RegisterNewCategoryCommandValidation()
        {
            ValidateName();
        }
    }
}
