using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckWeb.Models;

namespace VirtualDeckWeb.Assemblers
{
    public class TokenPackAssembler
    {
        public TokenPackViewModel ConvertENToModelUI(TokenPackEN en)
        {
            TokenPackViewModel tokenpack = new TokenPackViewModel();
            tokenpack.Id = en.Id;
            tokenpack.Name = en.Name;
            tokenpack.Price = en.Price;
            tokenpack.Tokens = en.Tokens;
            return tokenpack;
        }
        public IList<TokenPackViewModel> ConvertListENToModel(IList<TokenPackEN> ens)
        {
            IList<TokenPackViewModel> tokenpacks = new List<TokenPackViewModel>();
            foreach (TokenPackEN en in ens)
            {
                tokenpacks.Add(ConvertENToModelUI(en));
            }
            return tokenpacks;
        }
    }
}