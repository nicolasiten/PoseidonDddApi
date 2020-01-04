using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoseidonTradeDddApi.Application.Curve.Commands.UpdateCurvePoint
{
    public class UpdateCurvePointItemCommandValidator : AbstractValidator<UpdateCurvePointItemCommand>
    {
        public UpdateCurvePointItemCommandValidator()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0);

            RuleFor(c => c.Term)
                .GreaterThan(0);

            RuleFor(c => c.Value)
                .GreaterThan(0);
        }
    }
}
