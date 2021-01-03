using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyGear.Something
{
    class Utilities
    {
        static public bool isValid_forNumbertext(char c)
        {
            int i;
            if (int.TryParse(c.ToString(), out i))
            {
                return true;
            }
            if (c == Convert.ToChar(8))
            {
                return true;
            }
            return false;
        }
    }
}
