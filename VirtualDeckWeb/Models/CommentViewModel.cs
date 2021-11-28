using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualDeckWeb.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
    }
}