namespace Clm_Booking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdminClm")]
    public partial class AdminClm
    {
        [Key]
        public int AdminID { get; set; }

        [Required]
        [Display(Name ="First Name")]
        [StringLength(100)]
        public string firstname { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(100)]
        public string lastname { get; set; }

        [Required]
        [Display(Name = "Email")]
        [StringLength(100)]
        public string email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(22)]
        public string phonenumber { get; set; }
        

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(400)]
        public string securedpassword { get; set; }

    }
}
