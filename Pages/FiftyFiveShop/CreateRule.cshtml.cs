using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FifyFiveShop.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FifyFiveShop.Pages.FiftyFiveShop
{
    public class CreateRuleModel : PageModel
    {
        private ApplicationDbContext db;

        public CreateRuleModel(ApplicationDbContext _db)
        {
            db = _db;

        }
        [BindProperty]
        public PriceRule PriceRule { get; set; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await db.PriceRule.AddAsync(PriceRule);
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
