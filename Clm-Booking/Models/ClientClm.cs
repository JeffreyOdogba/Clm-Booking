namespace Clm_Booking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClientClm")]
    public partial class ClientClm
    {
        [Key]
        public int ClientID { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name ="First Name")]
        public string firstname { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Last Name")]
        public string lastname { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [Display(Name = "Date")]
        public DateTime? bookdate { get; set; }

        [Required]
        [Display(Name = "Time")]
        public DateTime? booktime { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [StringLength(22)]
        [Display(Name = "Phone Number")]
        public string phonenumber { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Comment/Reason")]
        public string comments { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Status")]
        public string status { get; set; }
    }
}
