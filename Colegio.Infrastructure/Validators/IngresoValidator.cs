using Colegio.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colegio.Infrastructure.Validators
{
    public class IngresoValidator: AbstractValidator<IngresoDto>
    {
        public IngresoValidator()
        {
            RuleFor(ingreso => ingreso.Nombre)
                .NotNull()
                .Length(3, 20);

            RuleFor(ingreso => ingreso.Apellido)
                .NotNull()
                .Length(3, 20);
            RuleFor(ingreso => ingreso.Identificacion)
                .NotNull()
                .MaximumLength(10);
            RuleFor(ingreso => ingreso.Edad)
                .NotNull()
                .MaximumLength(2);

        }
    }
}
