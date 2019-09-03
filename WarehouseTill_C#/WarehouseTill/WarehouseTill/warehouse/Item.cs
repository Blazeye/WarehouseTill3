using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseTill.warehouse
{
    public class Item
    {
        //public event EventHandler AddProduct;

        //protected virtual void Raise_AddProduct(ItemEventArgs e)
        //{
        //    EventHandler handler = AddProduct;

        //    if (handler != null)
        //    {
        //        handler(this, e);
        //    }

            //can also use:
            //handler?.Invoke(this, e);

            //if event is triggered, and you want to pass the reference with no additional data over to Warehouse:
            //if (handler != null)
            //{
            //    handler(this, EventArgs.Empty);
            //}
        //}
    }
}
