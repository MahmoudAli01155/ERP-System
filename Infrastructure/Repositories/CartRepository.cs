using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(ApplicationDBContext context) : base(context) { }

        public async Task<Cart?> GetUserCartAsync(Guid userId)
        {
            return await _dbSet
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.CreatedBy == userId.ToString());
        }
    }
}
