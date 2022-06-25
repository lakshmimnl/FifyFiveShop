using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FifyFiveShop.Pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FifyFiveShop.Pages.FiftyFiveShop
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext db;

        public IndexModel(ApplicationDbContext _db)
        {
            db = _db;

        }
        public IEnumerable<Product> Products { get; set; }

        public IEnumerable<PriceRule> PriceRules { get; set; }

        public string Transaction { get; set; }

        public string TotalSum { get; set; }

        public void OnGet()
        {

            Products = db.Product.ToList();
            PriceRules = db.PriceRule.ToList();
            
        }

        


        public ActionResult OnPost(string tran)
        {
            Products = db.Product.ToList();
            PriceRules = db.PriceRule.ToList();

            var prodList = tran.Split(',').Distinct().ToList();
            List<Bill> lstBill = new List<Bill>();
            foreach (var item in prodList)
            {
                lstBill.Add(new Bill() { ProductName = item, Quantity = tran.Split(',').Count(a => a == item) });
            }

            foreach (var item in lstBill)
            {
                var SplPrice = db.PriceRule.FirstOrDefault(x => x.SKU == item.ProductName && x.Quantity == item.Quantity);
                if (SplPrice != null)
                {
                    item.Price = SplPrice.Price;
                }
                else
                {
                    item.Price = db.Product.FirstOrDefault(a => a.SKU == item.ProductName).UnitPrice * item.Quantity;
                }

            }
            ViewData["Total"] = lstBill.Sum(a => a.Price).ToString();
         
            return Page();
        }

    }
}
