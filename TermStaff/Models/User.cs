namespace TermStaff.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Group = new HashSet<Group>();
            Group1 = new HashSet<Group>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FIO { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string E_mail { get; set; }

        public DateTime Birthday { get; set; }

        [Required]
        [StringLength(50)]
        public string Passport { get; set; }

        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public int? IdRole { get; set; }

        public int? IdUnit { get; set; }

        public int? IdDepartament { get; set; }

        [StringLength(50)]
        public string Photo { get; set; }

        [StringLength(50)]
        public string SkanPassport { get; set; }

        [StringLength(50)]
        public string Orshagization { get; set; }

        [StringLength(50)]
        public string Note { get; set; }

        public bool? Black_list { get; set; }

        public virtual Departamen Departamen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Group> Group { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Group> Group1 { get; set; }

        public virtual Role Role { get; set; }

        public virtual Unit Unit { get; set; }
    }
}
