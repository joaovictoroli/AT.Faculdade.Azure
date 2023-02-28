using AT_Joao.BLL.Models.DTO;
using FluentValidation;

namespace AT_Joao_WCF_AZURE.Validators
{
    public class UpdateCountryRequestValidator : AbstractValidator<UpdateCountryRequest>
    {
        public UpdateCountryRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.ImageUrl).NotEmpty();
        }
    }
}
