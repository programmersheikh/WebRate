using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebRate.Models
{
    public class WebComment
    {
        [Key]
        public int WebComntId { get; set; }
        public int WebID { get; set; }

        [Display(Name = "Comment")]
        public string DetailComment { get; set; }

        public string UserID { get; set; }
        public virtual Website Website { get; set; }

    }
}