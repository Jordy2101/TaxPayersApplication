using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using TaxPayersApplication.Application.Services.Base;
using TaxPayersApplication.Domain.TaxPayersApplicationDB;
using AutoMapper;
using TaxPayersApplication.DataAccess.Repositories.Base;
using TaxPayersApplication.Application.Services.Contract;
using TaxPayersApplication.Common.Dtos;
using TaxPayersApplication.Application.DTOs;
using TaxPayersApplication.Common.Filters;
using TaxPayersApplication.Common.Contans;
using TaxPayersApplication.Common.Paged;
using TaxPayersApplication.Application.Validations;

namespace TaxPayersApplication.Application.Services
{
    public class TaxPayersServices : ServicesBase<TaxPayers>, ITaxPayersServices
    {
        readonly IMapper mapper;
        public TaxPayersServices(IBaseRepository<TaxPayers> repository, IMapper _mapper) : base(repository)
        {
            mapper = _mapper;
        }

        public async Task<int> Create(TaxPayersDto data)
        {
            try
            {
                var map = mapper.Map<TaxPayers>(data);

                var validationRules = new TaxPayersValidations();
                var result = validationRules.Validate(map);

                if (!result.IsValid)
                {
                    var errors = string.Join(" | ", result.Errors);
                    throw new ArgumentException(errors);
                }

                map.IsActive = true;
                return base.Create(map);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Pagination> GetPagedtaxPayers(TaxPayersFilter filter)
        {
            try
            {
                var data = filter.keyword is not null ? base.FindByCondition(c => c.Name.Contains(filter.keyword)) : base.FindAll() ;

                data = !data.Any() ? throw new ArgumentException(MessageCodes.EmptyCollections) : data;

                var pag = PagedList<TaxPayers>.Create(data, filter.PageNumber, filter.PageSize);

                return new Pagination()
                {
                    Data = pag.OrderByDescending(c => c.Id),
                    TotalCount = pag.TotalCount,
                    PageSize = pag.PageSize,
                    CurrentPage = pag.CurrentPage,
                    TotalPages = pag.TotalPages
                };
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> InactiveTaxPayers(int id)
        {
            try
            {
                var data = base.GetOne(id);

                data.IsActive = false;

                base.Update(data);

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
