using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckWeb.Models;

namespace VirtualDeckWeb.Assemblers
{
    public class TradeOffAssembler
    {
        public TradeOffViewModel ConvertENToModelUI(TradeOffEN en)
        {
            TradeOffViewModel tradeOff = new TradeOffViewModel();
            tradeOff.Id = en.Id;
            tradeOff.Date = (DateTime)en.Date;
            tradeOff.State = en.State;
            return tradeOff;


        }
        public IList<TradeOffViewModel> ConvertListENToModel(IList<TradeOffEN> ens)
        {
            IList<TradeOffViewModel> tradeOffs = new List<TradeOffViewModel>();
            foreach (TradeOffEN en in ens)
            {
                tradeOffs.Add(ConvertENToModelUI(en));
            }
            return tradeOffs;
        }
    }
}