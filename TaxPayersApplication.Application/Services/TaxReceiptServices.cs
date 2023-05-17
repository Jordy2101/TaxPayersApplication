using AutoMapper;
using FluentValidation;
using TaxPayersApplication.Application.DTOs;
using TaxPayersApplication.Application.Services.Base;
using TaxPayersApplication.Application.Services.Contract;
using TaxPayersApplication.Application.Validations;
using TaxPayersApplication.Common.Contans;
using TaxPayersApplication.DataAccess.Repositories.Base;
using TaxPayersApplication.Domain.TaxPayersApplicationDB;

namespace TaxPayersApplication.Application.Services
{
    public class TaxReceiptServices : ServicesBase<TaxReceipt>, ITaxReceiptServices
    {
        readonly IMapper mapper;
        public TaxReceiptServices(IBaseRepository<TaxReceipt> repository, IMapper _mapper) : base(repository)
        {
            mapper = _mapper;
        }

        public async Task<bool> CreateReceiptPayers(TaxReceiptDto data)
        {
            try
            {
                var map = mapper.Map<TaxReceipt>(data);

                var validationRules = new TaxReceiptValidations();
                var result = validationRules.Validate(map);

                if (!result.IsValid)
                {
                    var errors = string.Join(" | ", result.Errors);
                    throw new ArgumentException(errors);
                }

                base.Create(map);

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        public async Task<string> GetNFC()
        {
            var baseCode = "E310000000000";

            var lastEntity = base.LastOne();

            int lastId = lastEntity is null ? 0 : lastEntity.Id;

            int intPositions = Convert.ToInt32(Math.Floor(Math.Log10(lastId + 1) + 1));

            string newBaseCode = baseCode.Remove(baseCode.Length - intPositions);

            return $"{newBaseCode}{lastId + 1}";
        }
        
        public async Task<List<TaxReceiptDto>> GetReceiptByPayers(string id)
        {
            try
            {
                var data = base.FindByCondition(c=> c.RncCedula == id);

                data = !data.Any() ? throw new ArgumentException(MessageCodes.EmptyCollections) : data;

                var map = mapper.Map<List<TaxReceiptDto>>(data.ToList());

                return map;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
