using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckWeb.Models;

namespace VirtualDeckWeb.Assemblers
{
    public class AttackMoveAssembler
    {
        public AttackMoveViewModel ConvertENToModelUI(AttackMoveEN en)
        {
            AttackMoveViewModel attack = new AttackMoveViewModel();
            attack.Id = en.Id;
            attack.Name = en.Name;
            attack.Type = en.Type;
            attack.Description = en.Description;
            return attack;


        }
        public IList<AttackMoveViewModel> ConvertListENToModel(IList<AttackMoveEN> ens)
        {
            IList<AttackMoveViewModel> attacks = new List<AttackMoveViewModel>();
            foreach (AttackMoveEN en in ens)
            {
                attacks.Add(ConvertENToModelUI(en));
            }
            return attacks;
        }
    }
}