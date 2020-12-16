using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PieShopWebsite.Models;
using PieShopWebsite.Services;
using PieShopWebsite.ViewModels;

namespace PieShopWebsite.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        // // GET: /<controller>/
        // public IActionResult List()
        // {
        //     //return View(_pieRepository.AllPies);
        //     var piesViewModel = new PiesViewModel
        //     {
        //         Pies = _pieRepository.AllPies, CurrentCategory = "Cheese cakes"
        //     };
        //
        //     return View(piesViewModel);
        // }

        public ViewResult List(string category)
        {
            IEnumerable<Pie> pies;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.AllPies.OrderBy(p => p.PieId);
                currentCategory = "All pies";
            }
            else
            {
                pies = _pieRepository.AllPies.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.PieId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new PiesViewModel
            {
                Pies = pies,
                CurrentCategory = currentCategory
            });
        }
        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();

            return View(pie);
        }


    }
}

