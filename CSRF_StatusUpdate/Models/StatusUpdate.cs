using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CSRF_StatusUpdate.Models
{
    public class StatusUpdate
    {
        [Display(Name = "Status date")]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy, HH:mm}")]
        public DateTime StatusDate { get; set; }

        [Required]
        [AllowHtml]
        [StringLength(140)]
        public string Status { get; set; }
    }
}