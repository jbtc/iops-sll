using NUnit.Framework;
using iOps.Core.Model;
using iOps.Data;

namespace iOps.Tests
{
    public class RepoTest : IntegrationTestsBase
    {
        [Test]
        public void TestInsert()
        {
            var repo = new Repo<Country>(new DbContextFactory());
            var country = new Country { Name = "testCountry" };
            country = repo.Insert(country);
            repo.Save();
            var country1 = repo.Get(country.ID);
            Assert.AreEqual(country.Name, country1.Name);
        }

        [Test]
        public static void TestRemove()
        {
            var repo = new Repo<Country>(new DbContextFactory());
            var country = new Country { Name = "testCountry" };
            country = repo.Insert(country);
            repo.Save();

            repo.Delete(country);
            repo.Save();

            var country1 = repo.Get(country.ID);
            Assert.IsTrue(country1.IsDeleted);
        }

        [Test]
        public static void TestUpdate()
        {
            var repo = new Repo<Country>(new DbContextFactory());
            var country = new Country { Name = "testCountry" };
            country = repo.Insert(country);
            repo.Save();

            country.Name = "changedName";
            repo.Save();

            var country1 = repo.Get(country.ID);
            Assert.AreEqual(country.Name, country1.Name);
        }
    }
}