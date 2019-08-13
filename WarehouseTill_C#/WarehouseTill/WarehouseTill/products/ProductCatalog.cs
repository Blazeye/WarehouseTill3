using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WarehouseTill.products
{
    public class ProductCatalog : IProductCatalog
    {
        public List<IProduct> ProductList { get; }
        //public IList<Product> list { get; set; }

        /// <summary>
        /// Constructor which initializes 4 products
        /// </summary>
        public ProductCatalog()
        {
            // Add 4 example products to the internal data structure of this catalog here

            //list.Add(new Product("hak34s", "Bonko-boter, gemaakt van echte room.", 2.19m));
            //list.Add(new Product("9a9sd0", "St. Jantje: De beste komijnenkaas!", 8.45m));
            //list.Add(new Product("ufr3hd", "Berensterke botten met Borbonje...", 1.23m));
            //list.Add(new Product("73eh2e", "Van vrijlopende scharrelkippen!", 1.75m));

            //this.ProductList = new List<Product>();
            //ProductList.Add(new Product("hak34s", "Bonko-boter, gemaakt van echte room.", 2.19m));
            //ProductList.Add(new Product("9a9sd0", "St. Jantje: De beste komijnenkaas!", 8.45m));
            //ProductList.Add(new Product("ufr3hd", "Berensterke botten met Borbonje...", 1.23m));
            //ProductList.Add(new Product("73eh2e", "Van vrijlopende scharrelkippen!", 1.75m));


            ProductList = new List<IProduct>{
                new Product("1234", "Bonko-boter, weer 'ns echte roomboter...", 2.19m) { },
                new Product("9902", "St. Jantje: De beste komijnenkaas!", 8.45m) { },
                new Product("3568", "Berensterke botten met Borbonje!", 1.23m) { },
                new Product("7324", "Eieren, van vrijlopende scharrelkippen.", 1.75m) { },
            };


        



            //            Product Boter = new Product("hak34s", "Bonko-boter, gemaakt van echte room.", 2.19m) { };
            //            Product Kaas = new Product("9a9sd0", "St. Jantje: De beste komijnenkaas!", 8.45m) { };
            //            Product Melk = new Product("ufr3hd", "Berensterke botten met Borbonje...", 1.23m) { };
            //            Product Eieren = new Product("73eh2e", "Van vrijlopende scharrelkippen!", 1.75m) { };
            //            List<Product> ProductList = new List<Product>(4) { Boter, Kaas, Melk, Eieren };



            GetAllProducts();
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
        public IList<IProduct> GetAllProducts()
        {

            IList<IProduct> listProducts;
            listProducts = (IList<IProduct>)this.ProductList;


            //foreach(IProduct item in this.ProductList)
            //{
            //    listProducts.Add(item);
            //}







            //IEnumerable<Product> listProducts = from product in this.ProductList
            //                                    select product;



            //return this.ProductList;
            return listProducts;





        //    // IList<IProduct> list = (IList<IProduct>)listProducts;




        //    //Type T = Type.GetType("ProductCatalog.ProductList");

        //    IList<IProduct> list = null;

        //    //list = IList<IProduct>.class.cast(listProducts);

        //    foreach(Product product in listProducts)
        //    {
        //        IProduct item = Product.cast(product);
        //    }

        //    return list;


        //    //foreach(IProduct item in listProducts)
        //    //{
        //    //    list.Add( item);
        //    //}
        //    //return list;
        //    //IList<IProduct> list = IList < IProduct > listProducts;



        ////    return list;
            //throw new NotImplementedException();
        }
    }
}
