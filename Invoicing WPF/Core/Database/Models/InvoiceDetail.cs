namespace Invoicing_WPF.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class InvoiceDetail
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string ProductName { get; set; }

        [StringLength(100)]
        public string PKWiU { get; set; }

        public decimal NetPrice { get; set; }

        public int Quantity { get; set; }

        public string Unit { get; set; }

        public decimal NetValue { get; set; }

        public int VatRate { get; set; }

        public decimal VatAmount { get; set; }

        public decimal GrossValue { get; set; }

        public int? InvoiceId { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}
