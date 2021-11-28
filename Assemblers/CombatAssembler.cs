using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckWeb.Models;

namespace VirtualDeckWeb.Assemblers
{
    public class CombatAssembler
    {
        public CombatViewModel ConvertENToModelUI(CombatEN en)
        {
            CombatViewModel combat = new CombatViewModel();
            combat.Id = en.Id;
            combat.Date = (DateTime)en.Date;
            return combat;


        }
        public IList<CombatViewModel> ConvertListENToModel(IList<CombatEN> ens)
        {
            IList<CombatViewModel> combats = new List<CombatViewModel>();
            foreach (CombatEN en in ens)
            {
                combats.Add(ConvertENToModelUI(en));
            }
            return combats;
        }
    }
}