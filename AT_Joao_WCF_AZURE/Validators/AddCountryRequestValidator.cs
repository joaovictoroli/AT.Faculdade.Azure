using AT_Joao.BLL.Models.DTO;
using FluentValidation;

namespace AT_Joao_WCF_AZURE.Validators
{
    public class AddCountryRequestValidator : AbstractValidator<AddCountryRequest>
    {
        public AddCountryRequestValidator()
        { 
            RuleFor(x=> x.Name).NotEmpty();
            RuleFor(x => x.ImageUrl).NotEmpty();
        }
    }
}
