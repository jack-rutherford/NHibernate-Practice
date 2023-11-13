using Mappings;
using NHibernate;
using NUnit.Framework;
using System;

namespace MappingTests
{
    [TestFixture]
    public class BaseTest
    {
        protected ISessionFactory _factory;
        protected ISession _session;

        [SetUp]
        public void CreateSession()
        {
            // Replace "stu.dent" with your user name in the 2 calls below
            Environment.SetEnvironmentVariable("RetailStore.DB", "jack.rutherford");
            Environment.SetEnvironmentVariable("RetailStore.UID", "jack.rutherford");
            // Replace "########" with your 9-digit student number
            Environment.SetEnvironmentVariable("RetailStore.PW", "000427252");
            Environment.SetEnvironmentVariable("RetailStore.Server", "localhost");

            _factory = SessionFactory.CreateSessionFactory();
            _session = _factory.GetCurrentSession();
            _session.CreateSQLQuery("delete from RetailStore.Employee")
                .ExecuteUpdate();
            _session.CreateSQLQuery("delete from RetailStore.Store")
                .ExecuteUpdate();

        }
    }
}