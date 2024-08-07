using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using MultiShop.Order.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Persistence.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly OrderContext _context;

        public AddressRepository(OrderContext context)
        {
            _context = context;
        }

        public async Task<List<Address>> GetAddressesByUserIdAsync(string userId)
        {
            var values = await _context.Addresses.Where(o => o.UserId == userId).ToListAsync();
            return values;
        }
    }
}
