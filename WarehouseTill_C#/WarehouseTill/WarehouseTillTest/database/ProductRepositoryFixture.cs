using NHibernate;
using NHibernate.Cfg;
using WarehouseTill.products;
using WarehouseTill.repository;
using NUnit.Framework;
using System.Reflection;
using System;

using WarehouseTill.database;
using System.Collections.Generic;

namespace WarehouseTillTest.database
{
    [TestFixture]
    public class ProductRepository_Fixture

    {
        private ISessionFactory _sessionFactory;
        private Configuration _configuration;

        [OneTimeSetUp]
        public void TestFixtureSetUp() // done for each 'run'

        {
            _configuration = new Configuration();
            //GetExecutingAssembly gets the part of the assembly that contains the .NET code that will
            //will be executing, so not the metadata.
            //CodeBase gets the location of that part of the executing assembly's code.
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            //creates an object representation of a uri based on the location
            //uri 
            UriBuilder uri = new UriBuilder(codeBase);
            //returns the uri path as string without the escape sequences
            //path without unescape: file%3A///localhost/c%24/Windows/foo.txt
            //path with unescape example: file:///localhost/c$/Windows/foo.txt
            string path = Uri.UnescapeDataString(uri.Path);

            _configuration.Configure(path + "#/WarehouseTill/WarehouseTill/database/hibernate.cfg.xml");
            _configuration.AddAssembly(typeof(Product).Assembly);
            _sessionFactory = _configuration.BuildSessionFactory();
        }
        [SetUp]
        public void TestSetUp()
        { // done for every test
            using (ISession session = _sessionFactory.OpenSession())
            {
                session.CreateQuery("delete from Product where Description='testProduct'").ExecuteUpdate();
            }
        }
        [Test]
        public void TestGetAllProducts()
        {
            //prepare
            IProductRepository repository = new ProductRepository();

            //run
            using (ISession session = _sessionFactory.OpenSession())
            {
                List<IProduct> result = repository.GetAllProducts();
                //var fromDb = session.CreateQuery("from Product").List();
                //validate
                Assert.NotNull(result);
                Assert.IsNotEmpty(result);
                Assert.IsInstanceOf<List<IProduct>>(result);
            }
        }
        [Test]
        public void TestCanAddNewProduct()
        {
            // prepare
            var product = new Product("0000", "testProduct", 2.500m);
            IProductRepository repository = new ProductRepository();

            // run
            repository.Add(product);

            // validate
            // use session to try to load the product

            using (ISession session = _sessionFactory.OpenSession())
            {
                var fromDb = session.Get<Product>(product.Id);

                // Test that the product was successfully inserted

                Assert.IsNotNull(fromDb);
                Assert.AreNotSame(product, fromDb);
                Assert.AreEqual(product.Barcode, fromDb.Barcode);

            }

        }
        [Test]
        public void TestGetByBarcode()
        {
            // prepare
            Product testProduct = new Product("8888", "testProduct", 12.34m);
            using (ISession session = _sessionFactory.OpenSession())
            {
                session.Save(testProduct);
            }
            IProductRepository repository = new ProductRepository();

            // run
            var result1 = repository.GetByBarcode("2222");
            var result2 = repository.GetByBarcode("8888");

            // validate
            Assert.Null(result1);
            Assert.NotNull(result2);
            Assert.AreEqual(testProduct, result2);

        }
        [Test]
        public void TestCanUpdateProduct()
        {
            //Prepare
            Product originalProduct = new Product("1111", "testProduct", 11.110m);
            Product testProduct = new Product("1234", "testProduct", 88.880m);
            IProductRepository repository = new ProductRepository();

            //Run
            using (ISession session = _sessionFactory.OpenSession())
            {
                session.Save(originalProduct);
                testProduct.Id = originalProduct.Id;
                repository.Update(testProduct);
            }
            //Validate
            using (ISession session = _sessionFactory.OpenSession())
            {
                //second session is used so fromDB get to take the changed table entry
                var fromDb = session.Get<Product>(originalProduct.Id);

                Assert.IsNotNull(fromDb);
                Assert.AreEqual(testProduct.Barcode, fromDb.Barcode);
            }
        }
        [Test]
        public void TestCanDeleteProduct()
        {
            //prepare
            Product testProduct = new Product("1111", "testProduct", 11.110m);
            IProductRepository repository = new ProductRepository();

            //run
            using (ISession session = _sessionFactory.OpenSession())
            {
                session.Save(testProduct);
                repository.Remove(testProduct);
            }
            //validate
            using (ISession session = _sessionFactory.OpenSession())
            {
                var fromDb = session.Get<Product>(testProduct.Id);
                Assert.IsNull(fromDb);
            }
        }
    }
}


