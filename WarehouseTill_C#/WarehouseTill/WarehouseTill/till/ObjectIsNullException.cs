using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseTill.till
{
    public class ObjectIsNullException : Exception
    {
        public ObjectIsNullException() : base(){}

        public ObjectIsNullException(string message) : base(message){}

        public ObjectIsNullException(string message, System.Exception inner) : base(message, inner){}

        protected ObjectIsNullException(System.Runtime.Serialization.SerializationInfo info,
    System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
