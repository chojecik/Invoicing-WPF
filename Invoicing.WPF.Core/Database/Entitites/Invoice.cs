namespace Invoicing.WPF.Core.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Invoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Invoice()
        {
            InvoiceDetails = new HashSet<InvoiceDetails>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Number { get; set; }

        public int Type { get; set; }

        public int? AttachmentId { get; set; }

        public long? UserId { get; set; }

        public int ContractorId { get; set; }

        public bool IsPaid { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateOfIssue { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateOfService { get; set; }

        public decimal GrossValue { get; set; }

        public decimal NetValue { get; set; }

        public decimal VatAmount { get; set; }

        public int VatRate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateOfPayment { get; set; }

        public virtual Attachment Attachments { get; set; }

        public virtual Contractor Contractors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }

        public virtual User Users { get; set; }
    }
}
