using System.Collections.Generic;
using PieShopWebsite.Models;

namespace PieShopWebsite.ViewModels
{
    public class PiesViewModel
    {
        public IEnumerable<Pie> Pies { get; set; }

        public string CurrentCategory { get; set; }
    }
}
