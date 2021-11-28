using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckWeb.Models;

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
            //pack.RegistryDate = en.RegistryDate;
            pack.MaxNumCards = en.MaxNumCards;
            pack.MinNumCards = en.MinNumCards;
            //pack.CardTypes = en.CardTypes;
            //pack.Rarity = en.Rarity;
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