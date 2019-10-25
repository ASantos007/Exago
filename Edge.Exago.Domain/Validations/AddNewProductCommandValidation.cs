using Edge.Exago.Domain.Commands;

namespace Edge.Exago.Domain.Validations
{
    public class AddNewProductCommandValidation : CategoryValidation<AddNewProductCommand>
    {
        public AddNewProductCommandValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}
