using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Product
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual double Price { get; set; }
        public virtual IList<Store> StoresStockedIn { get; protected set; }

        public Product()
        {
            StoresStockedIn = new List<Store>();
        }

        public override string ToString()
        {
            return String.Format("ID {0}, Name {1}, Price {2}", Id, Name, Price);
        }

        public override bool Equals(object obj)
        {
            if (obj is Product other)
            {
                return other.Id == this.Id;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return ("Product" + Id).GetHashCode();
        }
    }
}
