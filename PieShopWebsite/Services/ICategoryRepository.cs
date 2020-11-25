using System.Collections.Generic;
using PieShopWebsite.Models;

namespace PieShopWebsite.Services
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
