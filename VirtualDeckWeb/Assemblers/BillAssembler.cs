using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckWeb.Models;

namespace VirtualDeckWeb.Assemblers
{
    public class BillAssembler
    {
        public BillViewModel ConvertENToModelUI(BillEN en)
        {
            BillViewModel bill = new BillViewModel();
            bill.Id = en.Id;
            bill.Date = (DateTime)en.Date;
            bill.Amount = en.Amount;
            return bill;


        }
        public IList<BillViewModel> ConvertListENToModel(IList<BillEN> ens)
        {
            IList<BillViewModel> bills = new List<BillViewModel>();
            foreach (BillEN en in ens)
            {
                bills.Add(ConvertENToModelUI(en));
            }
            return bills;
        }
    }
}