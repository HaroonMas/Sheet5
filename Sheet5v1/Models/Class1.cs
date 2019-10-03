using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sheet5v1.Models
{
    public class Class1
    {

        public subTypes Subs { get; set; }
        public subSize size { get; set; }
        public mealType Meal { get; set; }

        public int Quantity { get; set; }

        public enum subTypes
        {
            TheMichaelJackson,
            ThePrince,
            TheBackStreetBoys,
            TheRamys,
            TheDeekSuckas

        }

        public enum subSize
        {
            Extra_Large,
            Large,
            Medium,
            small

        }
        public enum mealType
        {
            None,
            DrinkNChips,
            DrinkNCookies
        }
    }
}