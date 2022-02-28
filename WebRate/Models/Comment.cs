using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebRate.Models
{
    public class Comment
    {
        [Key]
        public int CommntID { get; set; }

        [Display(Name ="Comment")]
        public string CommentDesc { get; set; }

        public int? TopicID { get; set; }

        public int? WebID { get; set; }
        public string UserID { get; set; }

    }
}