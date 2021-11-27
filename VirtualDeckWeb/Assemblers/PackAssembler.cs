using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.EN.VirtualDeck;

namespace VirtualDeckWeb.Assemblers
{
    public class PackAssembler
    {
        public PackViewModel ConvertENToModelUI(PackEN en)
        {
            PackViewModel pack = new PackViewModel();
            pack.Id = en.Id;
            pack.Name = en.Name;
            pack.Description = en.Description;
            pack.Price = en.Price;
            pack.Img = en.Img;
            pack.Type = en.Type;
            pack.MaxNumCards = en.MaxNumCards;
            pack.MinNumCards = en.MinNumCards;
            return pack;


        }
        public IList<PackViewModel> ConvertListENToModel(IList<PackEN> ens)
        {
            IList<PackViewModel> packs = new List<PackViewModel>();
            foreach (PackEN en in ens)
            {
                packs.Add(ConvertENToModelUI(en));
            }
            return packs;
        }
    }
}