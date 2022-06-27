using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FifyFiveShop.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FifyFiveShop.Pages.FiftyFiveShop
{
    public class EditRuleModel : PageModel
    {
        [BindProperty]
        public PriceRule PriceRule { get; set; }
        private ApplicationDbContext db;
        public EditRuleModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        public async Task OnGet(int id)
        {
            PriceRule = await db.FindAsync<PriceRule>(id);
        }

        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                PriceRule ruleToUpdate = await db.PriceRule.FindAsync(PriceRule.Id);
                ruleToUpdate.SKU = PriceRule.SKU;
                ruleToUpdate.Price = PriceRule.Price;
                ruleToUpdate.Quantity = PriceRule.Quantity;
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
