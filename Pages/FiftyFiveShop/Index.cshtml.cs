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

        public double TotalSum { get; set; }

        public void OnGet()
        {

            Products = db.Product.ToList();
            PriceRules = db.PriceRule.ToList();
            
        }

        


        public ActionResult OnPost(string tran)
        {
            TotalSum = CalculateTotal(tran);
            ViewData["Total"] = TotalSum;
            return Page();
        }

        public double CalculateTotal(string tran)
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
                var SplPrice = db.PriceRule.FirstOrDefault(x => x.SKU == item.ProductName);//&& x.Quantity == item.Quantity);
                var unitPrice = db.Product.FirstOrDefault(a => a.SKU == item.ProductName).UnitPrice; 
                if (SplPrice != null)
                {
                    var Units = item.Quantity % SplPrice.Quantity;
                    var individualItems = item.Quantity - (Units * SplPrice.Quantity);

                    item.Price = (Units * SplPrice.Price)+(individualItems * unitPrice);
                }
                else
                {
                    item.Price = unitPrice * item.Quantity;
                }

            }
            return lstBill.Sum(a => a.Price);
        }
    }
}
