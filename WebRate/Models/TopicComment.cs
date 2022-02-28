using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebRate.Models
{
    public class TopicComment
    {
        [Key]
        public int TopcComntId { get; set; }
        public int TopicID { get; set; }


        [Display(Name ="Comment")]
        public string DetailComment { get; set; }

        public string UserID { get; set; }

        public virtual Topic Topic { get; set; }


    }
}