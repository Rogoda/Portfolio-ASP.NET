namespace Portfolio1Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContactMe")]
    public partial class ContactMe
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(40)]
        public string EmailAdres { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(40)]
        public string ServerSMTP { get; set; }

        [StringLength(20)]
        public string EmailPassword { get; set; }
    }
}
