using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressesByUserIdQuery
    {
        public string UserId { get; set; }

        public GetAddressesByUserIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
