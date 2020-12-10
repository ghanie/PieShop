using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PieShopWebsite.Data;
using PieShopWebsite.Models;

namespace PieShopWebsite.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> AllCategories => _context.Categories;
    }
}
