using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckWeb.Models;

namespace VirtualDeckWeb.Assemblers
{
    public class CommentAssembler
    {
        public CommentViewModel ConvertENToModelUI(CommentEN en)
        {
            CommentViewModel comment = new CommentViewModel();
            comment.Id = en.Id;
            comment.Text = en.Text;
            comment.PublishDate = (DateTime)en.PublishDate;
            return comment;


        }
        public IList<CommentViewModel> ConvertListENToModel(IList<CommentEN> ens)
        {
            IList<CommentViewModel> comments = new List<CommentViewModel>();
            foreach (CommentEN en in ens)
            {
                comments.Add(ConvertENToModelUI(en));
            }
            return comments;
        }
    }
}