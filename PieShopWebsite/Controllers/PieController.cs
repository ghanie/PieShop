using Microsoft.AspNetCore.Mvc;
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

        // GET: /<controller>/
        public IActionResult List()
        {
            //return View(_pieRepository.AllPies);
            PiesViewModel piesViewModel = new PiesViewModel
            {
                Pies = _pieRepository.AllPies, CurrentCategory = "Cheese cakes"
            };

            return View(piesViewModel);
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

