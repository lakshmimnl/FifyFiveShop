using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FifyFiveShop.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FifyFiveShop.Pages.FiftyFiveShop
{
    public class EditProductModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }
        private ApplicationDbContext db;
        public EditProductModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        public async Task OnGet(int id)
        {
            Product = await db.FindAsync<Product>(id);
        }

        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                Product prodToUpdate = await db.Product.FindAsync(Product.Id);
                prodToUpdate.SKU = Product.SKU;
                prodToUpdate.UnitPrice = Product.UnitPrice;
                await db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }

}
