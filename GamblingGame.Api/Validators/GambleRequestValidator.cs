using FluentValidation;
using GamblingGame.Api.Models.Dtos;
using GamblingGame.Domain.Consts;

namespace GamblingGame.Api.Validators
{
    public class GambleRequestValidator : AbstractValidator<GambleRequest>
    {
        public GambleRequestValidator()
        {
            RuleFor(r => r.Number).Must(n => n is >= 0 and <= Const.GambleDrawUpperLimit);
            RuleFor(r => r.Points).Must(n => n > 0);
        }
    }
}
