using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressesByUserIdQueryHandler
    {
        private readonly IAddressRepository _repository;

        public GetAddressesByUserIdQueryHandler(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAddressesByUserIdQueryResult>> Handle(GetAddressesByUserIdQuery query)
        {
            var values = await _repository.GetAddressesByUserIdAsync(query.UserId);
            return values.Select(x => new GetAddressesByUserIdQueryResult
            {
                AddressId = x.AddressId,
                City = x.City,
                Detail1 = x.Detail1,
                District = x.District,
                UserId = x.UserId,
                Zipcode = x.Zipcode,
                Surname = x.Surname,
                Phone = x.Phone,
                Name = x.Name,
                Email = x.Email,
                Detail2 = x.Detail2,
                Country = x.Country
            }).ToList();
        }
    }
}
