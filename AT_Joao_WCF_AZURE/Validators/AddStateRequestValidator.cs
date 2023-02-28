using AT_Joao.BLL.Models.DTO;
using FluentValidation;

namespace AT_Joao_WCF_AZURE.Validators
{
    public class AddStateRequestValidator : AbstractValidator<AddStateRequest>
    {
        public AddStateRequestValidator() 
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.ImageUrl).NotEmpty();
            RuleFor(x => x.CountryId).NotEmpty();
        }
    }
}
