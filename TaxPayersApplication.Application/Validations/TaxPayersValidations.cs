using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxPayersApplication.Domain.TaxPayersApplicationDB;

namespace TaxPayersApplication.Application.Validations
{
    public class TaxPayersValidations : AbstractValidator<TaxPayers>
    {
        public TaxPayersValidations() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Campo nombre es requerido")
                                .Length(3, 50).WithMessage("Debe de tener un nombre de 3 a 50 letras");

            RuleFor(x => x.RncCedula).NotEmpty().WithMessage("Campo Rnc Cedula es requerido");

            RuleFor(x => x.TypeTaxPayers).NotEmpty().WithMessage("Campo tipo Persona es requerido");
        }
    }
}
