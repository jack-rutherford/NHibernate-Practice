using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NHibernate;
using FluentNHibernate.Testing;
using Model;
using Mappings;

namespace MappingTests
{
    [TestFixture]
    public class TestEmployee : BaseTest
    {
        [Test]
        public void TestEmployeeMapping()
        {
            new PersistenceSpecification<Employee>(_session)
            .CheckProperty(e => e.FirstName, "Joe")
            .CheckProperty(e => e.LastName, "Smith")
            .CheckReference(e => e.Store, new Store() {Name = "Store 1"})
            .VerifyTheMappings();
        }

    }
}
