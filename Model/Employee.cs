using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Employee
    {
        public virtual int Id { get; protected set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual Store Store { get; set; }

        public override string ToString()
        {
            return String.Format("ID {0}, FirstName {1}, LastName {2}, Store {3}", Id, FirstName, LastName, Store);
        }

        public override bool Equals(object obj)
        {
            if (obj is Employee other)
            {
                return other.Id == this.Id;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return ("Employee" + Id).GetHashCode();
        }
    }
}
