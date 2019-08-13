using System;
using System.Collections.Generic;
using System.Linq;

namespace WarehouseTill.products
{
    public class ProductCatalog : IProductCatalog
    {
        public List<Product> ProductList { get; set; }
        /// <summary>
        /// Constructor which initializes 4 products
        /// </summary>
        public ProductCatalog() {
            // Add 4 example products to the internal data structure of this catalog here


            //List<Product> ProductList = new List<Product>();
            //ProductList.Add(new Product("hak34s", "Bonko-boter, gemaakt van echte room.", 2.19m));
            //ProductList.Add(new Product("9a9sd0", "St. Jantje: De beste komijnenkaas!", 8.45m));
            //ProductList.Add(new Product("ufr3hd", "Berensterke botten met Borbonje...", 1.23m));
            //ProductList.Add(new Product("73eh2e", "Van vrijlopende scharrelkippen!", 1.75m));




            Product Boter = new Product("hak34s", "Bonko-boter, gemaakt van echte room.", 2.19m) { };
            Product Kaas = new Product("9a9sd0", "St. Jantje: De beste komijnenkaas!", 8.45m) { };
            Product Melk = new Product("ufr3hd", "Berensterke botten met Borbonje...", 1.23m) { };
            Product Eieren = new Product("73eh2e", "Van vrijlopende scharrelkippen!", 1.75m) { };
            List<Product> ProductList = new List<Product>(4) { Boter, Kaas, Melk, Eieren };




            // throw new NotImplementedException();
        }

        /// <summary>
        /// Find a product for a barcode
        /// </summary>
        /// <returns>the product or <c>null</c> if not found</returns>
        public IProduct FindProductForBarcode(string barcode)
        {
            Product rightProduct = null;

            foreach (Product item in ProductList)
            {
                if (item.Barcode == barcode)
                {
                    rightProduct = item;
                    break;
                }
            }
            // throw new NotImplementedException();
            return rightProduct;
        }

        /// <returns>a list of all products</returns>
        public IList<IProduct> GetAllProducts() {
            
        //    throw new NotImplementedException();
        }
    }
}
