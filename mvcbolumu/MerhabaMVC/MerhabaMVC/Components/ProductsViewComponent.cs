using MerhabaMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace MerhabaMVC.Components
{
    public class ProductsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
           var ogrenci = new Ogrenci() { FirstName="Mehmet"};
            return View(ogrenci);
        }
    }
}
