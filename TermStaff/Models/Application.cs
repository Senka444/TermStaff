namespace TermStaff.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Application")]
    public partial class Application
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Decription { get; set; }

        [Required]
        [StringLength(50)]
        public string DateStart { get; set; }

        [Required]
        [StringLength(50)]
        public string DateEnd { get; set; }

        public int? IdGroup { get; set; }

        [Required]
        [StringLength(50)]
        public string Aim { get; set; }

        public int IdStatus { get; set; }

        public virtual Group Group { get; set; }

        public virtual Status Status { get; set; }
    }
}
