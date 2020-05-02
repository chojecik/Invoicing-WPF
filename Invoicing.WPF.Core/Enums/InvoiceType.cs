using System.ComponentModel;

namespace Invoicing.WPF.Core.Enums
{
    public enum InvoiceType
    {
        [Description("Faktura kosztowa")]
        Cost = 1,

        [Description("Faktura sprzedaży")]
        Sale = 2
    }
}
