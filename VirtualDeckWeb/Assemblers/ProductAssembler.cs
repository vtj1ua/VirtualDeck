using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualDeckGenNHibernate.EN.VirtualDeck;
using VirtualDeckWeb.Models;

namespace VirtualDeckWeb.Assemblers
{
    public class ProductAssembler
    {
        public ProductViewModel ConvertENToModelUI(ProductEN en)
        {
            ProductViewModel prod = new ProductViewModel();
            prod.Id = en.Id;
            prod.Name = en.Name;
            prod.Description = en.Description;
            prod.Price = en.Price;
            prod.Img = en.Img;
            //prod.RegistryDate = en.RegistryDate;
            return prod;


        }
        public IList<ProductViewModel> ConvertListENToModel(IList<ProductEN> ens)
        {
            IList<ProductViewModel> prods = new List<ProductViewModel>();
            foreach (ProductEN en in ens)
            {
                prods.Add(ConvertENToModelUI(en));
            }
            return prods;
        }
    }
}