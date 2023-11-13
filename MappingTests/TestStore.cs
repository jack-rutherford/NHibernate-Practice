using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NHibernate;
using FluentNHibernate.Testing;
using Mappings;
using Model;


namespace MappingTests
{
    public class TestStore : BaseTest
    {
        [Test]
        public void TestStoreMapping()
        {
            new PersistenceSpecification<Store>(_session)
                // ask about the two lambda functions in the CheckList method
                .CheckProperty(x => x.Name, "Store 2")
                .CheckList(s => s.Staff,
                    new List<Employee>() {
                        new Employee() {
                            FirstName = "First1", LastName = "Last1"
                        },
                        new Employee() {
                            FirstName = "First2", LastName = "Last2"
                        }
                    },
                    (store, employee) => store.AddEmployee(employee)
                )
                .VerifyTheMappings();
        }

        [Test]
        public void TestProductMapping()
        {
            new PersistenceSpecification<Store>(_session)
                .CheckProperty(x => x.Name, "Store 3")
                .CheckList(s => s.Products,
                    new List<Product>() {
                        new Product() {
                            Name = "Product 1",
                            Price = 10.0
                        },
                        new Product() {
                            Name = "Product 2",
                            Price = 12.5
                        }
                    },
                    (store, product) => store.AddProduct(product)
                )
                .VerifyTheMappings();
        }

    }
}
