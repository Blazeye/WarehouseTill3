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
            this.Barcode = barcode;
            this.Description = description;
            this.Amount = amount; 
        }
        
    }
}
