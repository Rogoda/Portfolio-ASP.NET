namespace Portfolio1Repository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comments
    {
        [Key]
        public int CommentID { get; set; }

        public int UserID { get; set; }

        [Required]
        [StringLength(500)]
        public string CommentText { get; set; }

        public DateTime CommentDateTime { get; set; }

        public virtual Users Users { get; set; }
    }
}
