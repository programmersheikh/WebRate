using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebRate.Models;

namespace WebRate.ViewModels
{
    public class WebViewModel
    {

        public IEnumerable<WebComment> Comments { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
        public string UID { get; set; }
        public string UserNam { get; set; }
        public string TopicName { get; set; }



    }
}