using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoseidonTradeDddApi.Application.Curve.Commands.CreateCurvePoint
{
    public class CreateCurvePointItemCommandValidator : AbstractValidator<CreateCurvePointItemCommand>
    {
        public CreateCurvePointItemCommandValidator()
        {
            RuleFor(c => c.Term)
                .GreaterThan(0);

            RuleFor(c => c.Value)
                .GreaterThan(0);
        }
    }
}
