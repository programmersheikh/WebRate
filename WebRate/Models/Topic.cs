using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebRate.Models
{
    public class Topic
    {
        [Key]
        public int TopicID { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }

    }
}