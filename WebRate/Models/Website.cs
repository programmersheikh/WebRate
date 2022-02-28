using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebRate.Models
{
    public class Website
    {
        [Key]
        public int WebID { get; set; }
        public string Tittle { get; set; }
        public string Url { get; set; }

        public virtual ICollection<WebComment>WebComments { get; set; }

    }
}