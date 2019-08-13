using System;

namespace WarehouseTill.products
{
    /// <summary>
    /// Implementation of IProduct interface
    /// </summary>
    //    public class Product : IProduct
    //    {
    // TODO implement
    //    }

    /// <summary>
    /// Implementation of IProduct interface
    /// </summary>
    public class Product : IProduct
    {
        public string Barcode { get; }
        public string Description { get; }
        public decimal Amount { get; }

        public Product(string barcode, string description, decimal amount)
        {
            if(!(barcode.Length == 4) || description.Length > 28)
            {
                return;
            }
            string Barcode = barcode;
            string Description = description;
            decimal Amount = amount;

        }
        
    }
}
