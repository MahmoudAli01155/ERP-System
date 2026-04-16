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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDBContext _context;

        public CategoryRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Category?> GetWithProductsAsync(Guid id)
        {
            return await _context.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> IsNameExistsAsync(string arName, string enName)
        {
            return await _context.Categories
                .AnyAsync(c => c.ArName == arName || c.EnName == enName);
        }
    }
}
