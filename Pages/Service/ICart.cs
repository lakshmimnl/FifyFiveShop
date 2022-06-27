using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FifyFiveShop.Pages.Service
{
    public interface ICart
    {
        int CalculateTotal(string SKUs);
    }
}
