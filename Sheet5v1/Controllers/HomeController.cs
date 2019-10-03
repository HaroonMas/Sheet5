using Sheet5v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sheet5v1.Controllers
{
    public class HomeController : Controller
    {

        const double TAX = 0.15;
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Class1 order, FormCollection myForm)

        {
            Class1 c1 = new Class1();
            double[] subPrice = new double[] { 3.99, 4.99, 5.99, 6.99, 4.99 };
            String subName = Enum.GetName(typeof(Class1.subTypes), order.Subs);
            var typeprice = subPrice[(int)order.Subs];

            double[] sizePrice = new double[] { 3.99, 2.99, 1.99, 0.99 };
            String subSize = Enum.GetName(typeof(Class1.subSize), order.size);
            var sizeprice = sizePrice[(int)order.size];

            double[] subMealPrice = new double[] { 0.0, 2.50, 2.99 };
            String subMeal = Enum.GetName(typeof(Class1.mealType), order.Meal);
            var mealprice = subMealPrice[(int)order.Meal];

            int quantity = order.Quantity;
            mealprice = mealprice * quantity;
            double TypeNSizeTotal = Math.Round(typeprice * sizeprice * quantity, 2);
            double subTotal = TypeNSizeTotal + mealprice;
            double tax = Math.Round(subTotal * TAX, 2);
            double Total = Math.Round((tax + subTotal), 2);
            double TotalTax = 0.0;
            double TotalCost = 0.0;

            c1.Quantity = quantity;
            c1.Subs = order.Subs;
            c1.size = order.size;
            c1.Meal = order.Meal;

            List<Class1> newList = new List<Class1>();

          


            if (TempData["newList"] != null)
            {
                newList = (List<Class1>)TempData.Peek("newList");
            }
            
            if (TempData["TotalTaxes"] != null)

                TotalTax += Convert.ToDouble(TempData.Peek("TotalTaxes"));
            TempData.Keep("TotalTaxes");


            if (TempData["TotalCost"] != null)
            
                TotalCost += Convert.ToDouble(TempData.Peek("TotalCost"));
                TempData.Keep("TotalCost");

            newList.Add(c1);
            TempData["subName"] = subName;
            TempData.Keep("subName");
            TempData["subSize"] = subSize;
            TempData.Keep("subSize");
            TempData["subMeal"] = subMeal;
            TempData.Keep("subMeal");
            TempData["typeprice"] = typeprice;
            TempData.Keep("typeprice");
            TempData["sizeprice"] = sizeprice;
            TempData.Keep("sizeprice");
            TempData["mealprice"] = mealprice;
            TempData.Keep("mealprice");
            TempData["TypeNSizeTotal"] = TypeNSizeTotal;
            TempData.Keep("TypeNSizeTotal");
            TempData["subTotal"] = subTotal;
            TempData.Keep("subTotal");
            TempData["tax"] = tax;
            TempData.Keep("tax");
            TempData["Total"] = Total;
            TempData.Keep("Total");
            TempData["quantity"] = quantity;
            TempData.Keep("quantity");
            TempData["TotalTaxes"] = tax + TotalTax;
            TempData.Keep("TotalTaxes");
            TempData["TotalCost"] = subTotal + TotalCost;
            TempData.Keep("TotalCost");
            TempData["newList"] = newList;
            TempData.Keep("newList");



            return View("Receipt");
        }
      public ActionResult Details()
        {
            return View();
        }

        
    }
}