using FluentValidation;
using Quhinja.Services.Models.InputModels.Ingridient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quhinja.Services.Validations
{
    class IngridientInputBasicModelValidator : AbstractValidator<IngridientBasicInputModel>
    {
        public IngridientInputBasicModelValidator()
        {
            RuleFor(ing=>ing.Name)
            .Matches(@"^[a-zA-Z0-9_.-/s]*$");

        }
    }
}
