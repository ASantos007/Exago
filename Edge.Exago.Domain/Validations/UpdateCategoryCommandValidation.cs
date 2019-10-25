using Edge.Exago.Domain.Commands;

namespace Edge.Exago.Domain.Validations
{
    public class UpdateCategoryCommandValidation : CategoryValidation<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}
