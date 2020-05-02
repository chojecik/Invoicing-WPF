namespace Invoicing.WPF.Core.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Contractors = new HashSet<Contractor>();
            Invoices = new HashSet<Invoice>();
        }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        [Key]
        public long UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(34)]
        public string BankAccount { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(200)]
        public string CompanyName { get; set; }

        [StringLength(4)]
        public string HouseNumber { get; set; }

        public int? LocalNumber { get; set; }

        [StringLength(10)]
        public string Nip { get; set; }

        [StringLength(100)]
        public string Street { get; set; }

        [StringLength(6)]
        public string ZipCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contractor> Contractors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
