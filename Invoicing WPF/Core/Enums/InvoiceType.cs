using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing_WPF.Enums
{
    public enum InvoiceType
    {
        [Description("Faktura kosztowa")]
        Cost = 1,

        [Description("Faktura sprzedaży")]
        Sale = 2
    }
}
