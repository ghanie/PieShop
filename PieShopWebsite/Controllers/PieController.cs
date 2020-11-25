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
            PiesViewModel piesViewModel = new PiesViewModel();
            piesViewModel.Pies = _pieRepository.AllPies;

            piesViewModel.CurrentCategory = "Cheese cakes";
            return View(piesViewModel);
        }
    }
}

