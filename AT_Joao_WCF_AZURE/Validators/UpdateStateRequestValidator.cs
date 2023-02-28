using AT_Joao.BLL.Models.DTO;
using AT_Joao.BLL.Models.Entities;
using FluentValidation;

namespace AT_Joao_WCF_AZURE.Validators
{
    public class UpdateStateRequestValidator : AbstractValidator<UpdateStateRequest>
    {
        public UpdateStateRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.ImageUrl).NotEmpty();
            RuleFor(x => x.CountryId).NotEmpty();
        }
    }
}
