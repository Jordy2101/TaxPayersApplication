using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxPayersApplication.Domain.TaxPayersApplicationDB;

namespace TaxPayersApplication.Application.Validations
{
    public class TaxReceiptValidations : AbstractValidator<TaxReceipt>
    {
        public TaxReceiptValidations()
        {
            RuleFor(x => x.NCF).NotEmpty().WithMessage("Campo NCF es requerido");

            RuleFor(x => x.RncCedula).NotEmpty().WithMessage("Campo Rnc Cedula es requerido");

            RuleFor(x => x.Amount).NotEmpty().WithMessage("Campo Precio es requerido");

            RuleFor(x => x.Tax18).NotEmpty().WithMessage("Campo ITBIS es requerido");
        }
    }
}
