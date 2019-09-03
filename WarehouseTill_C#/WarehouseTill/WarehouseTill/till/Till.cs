using System;
using System.Collections.Generic;
using System.Linq;
using WarehouseTill.display;
using WarehouseTill.model;
using WarehouseTill.products;
using WarehouseTill.repository;
using WarehouseTill.warehouse;
using WarehouseTill.printer;

namespace WarehouseTill.till
{
    public class Till : ITill
    {
        public event EventHandler<ItemEventArgs> ItemScanned;
        public event EventHandler<OrdersListEventArgs> ItemPayed;
        public List<IProduct> cart{ get; set; } = new List<IProduct>();
        private IProductCatalog Catalog { get; set; }
        private ICashRegister Register { get; }
        //private ITillDisplay Display { get; set; }
        private SortedDictionary<decimal, int> initialContent { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="catalogus">The product catalogus to supply the products and
        /// search of products</param>
        public Till(IProductCatalog catalogus, ICashRegister cashRegister)
        {
            if (catalogus == null || cashRegister == null)
            {
                throw new ArgumentNullException("The catalog or register does not exist");
            }
                this.Catalog = catalogus;
                this.Register = cashRegister;
        }

        /// <summary>
        /// Handle a scan of a barcode
        /// </summary>
        /// <param name="barcode">The scanned barcode</param>
        /// <returns><c>true</c> if succesfull, <c>false</c> otherwise</returns>
        public bool HandleBarcode(string barcode)
        {

            IProduct product = Catalog.FindProductForBarcode(barcode);
            if (product != null)
            {
                RaiseItemScanned(product);
                return true;
            }
            return false;
        }
        private void RaiseItemScanned(IProduct product)
        {
            EventHandler<ItemEventArgs> handler = ItemScanned;
            if(handler != null)
            {
                handler(this, new ItemEventArgs(product));
            }
        }

        private void RaisePrintItems(Dictionary<string, OrdersProduct> dict)
        {
            EventHandler<OrdersListEventArgs> handler = ItemPayed;
            if(handler != null)
            {
                handler(this, new OrdersListEventArgs(dict));
            }
        }

        /// <summary>
        /// Initiate a payment
        /// </summary>
        /// <param name="amount">The amount paid</param>
        /// <returns>the change to return as a list of (coinvalue => quantity) 
        ///          or <code>null</code> on failure</returns>
        public IDictionary<decimal, int> InitiatePayment(decimal amount)
        {
            decimal sum = CalculateAmountOfItems();
            if (this.cart.Count == 0)
            {
                Console.WriteLine("Shopping cart is empty...");
                return null;
            }
            var result = Register.MakeChange(sum, amount);
            if (result == null)
            {
                return result;
            }
            return result;
        }

        /// <summary>
        /// Installs an interface to be used when displaying
        /// </summary>
        /// <param name="tillDisplay">The interface to use from now on</param>
        //public void SetDisplayInterface(ITillDisplay tillDisplay)
        //{
        //    if(tillDisplay == null)
        //    {

        //        throw new NullReferenceException("Display is null");

        //    }
        //    this.Display = tillDisplay;
        //}

        /// <summary>
        /// Trigger a show all products
        /// </summary>
        public void HandleShowingProducts(object s, EventArgs e)
        {
            string title = "PRODUCTEN:";
            try
            {
                IList<IProduct> items = this.Catalog.GetAllProducts();


                Console.Out.WriteLine("======================== " + title + " =======================");
                foreach (IProduct product in items)
                {
                    Console.Out.WriteLine(String.Format("{0,4} {1,-40} {2:c}",
                        product.Barcode, product.Description, product.Amount));
                }
                Console.Out.WriteLine("=========================================================");
            }
            catch (ArgumentNullException e1)
            {
                Console.WriteLine(e1.ToString());
                throw;
            }
        }

        public void HandleFilledCart(object s, ItemEventArgs e)
        { 
            {
                cart.Add(e.Item);
            }
        }

        public void HandleShowingScanned(object s, EventArgs e)
        {
            if (cart.Count > 0)
            {
                int productIndex = cart.Count - 1;
                decimal sum = CalculateAmountOfItems();
                string line1 = "TOTAAL: \u20ac " + Convert.ToString(Decimal.Round(sum, 2));
                string line2 = cart[productIndex].Description;


                Console.Out.WriteLine("==========================================");
                Console.Out.WriteLine("|{0,-40}|", line1);
                Console.Out.WriteLine("|{0,-40}|", line2);
                Console.Out.WriteLine("==========================================");
            }
        }

        public decimal CalculateAmountOfItems()
        {
            decimal sum = Decimal.Round(cart.Sum(p => p.Amount), 2);
            return sum;
        }

        public Dictionary<string, OrdersProduct> ReturnOrderedCart()
        {
            Dictionary<string, OrdersProduct> ordered = new Dictionary<string, OrdersProduct>();
            foreach (IProduct item in cart)
            {
                if (!ordered.ContainsKey(item.Barcode))
                {
                    ordered.Add(item.Barcode, new OrdersProduct(1, item.Amount));
                }
                else
                {
                    ordered[item.Barcode].Price += item.Amount;
                    ordered[item.Barcode].Amount++;
                }
            }
            return ordered;
        }
        public void AddOrder()
        {
            Dictionary<string, OrdersProduct> dict = ReturnOrderedCart();

            IPurchaseRepository repository0 = new PurchaseRepository();
            IProductRepository repository1 = new ProductRepository();
            IOrdersProductRepository repository2 = new OrdersProductRepository();
            var order = new Purchase();
            repository0.Add(order);
            foreach (string key in dict.Keys)
            {
                var product = repository1.GetByBarcode(key);
                dict[key].Item_id = product.Id;
                dict[key].Order_id = order.Id;
                repository2.Add(dict[key]);
            }
            RaisePrintItems(dict);
            cart.Clear();
        }
    }
}
