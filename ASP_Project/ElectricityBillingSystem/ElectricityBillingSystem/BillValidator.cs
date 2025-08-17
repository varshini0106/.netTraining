using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectricityBillingSystem
{
    public class BillValidator
    {
        public string ValidateUnitsConsumed(int UnitsConsumed)
        {
            if (UnitsConsumed < 0)
                return "Given units is invalid";
            return string.Empty;
        }
    }
}