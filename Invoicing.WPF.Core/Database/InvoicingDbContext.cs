namespace Invoicing.WPF.Core.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class InvoicingDbContext : DbContext
    {
        public InvoicingDbContext()
            : base("name=InvoicingDbContext")
        {
        }

        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<Contractor> Contractors { get; set; }
        public virtual DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attachment>()
                .HasMany(e => e.Invoices)
                .WithOptional(e => e.Attachments)
                .HasForeignKey(e => e.AttachmentId);

            modelBuilder.Entity<Contractor>()
                .HasMany(e => e.Invoices)
                .WithRequired(e => e.Contractors)
                .HasForeignKey(e => e.ContractorId);

            modelBuilder.Entity<Invoice>()
                .HasMany(e => e.InvoiceDetails)
                .WithOptional(e => e.Invoices)
                .HasForeignKey(e => e.InvoiceId);
        }
    }
}
