using System;
using FakeItEasy;
using NUnit.Framework;
using iOps.Core;
using iOps.Core.Model;
using iOps.Core.Service;
using iOps.Website.Mappers;
using iOps.Website.Controllers;
using iOps.Website.Dto;

namespace iOps.Tests
{
    public class CruderControllerTests
    {
        public Guid testGuid
        {
            get { return new Guid("20140801-1858-3158-B8DD-AB27FC6333E8"); }
        }
        
        CountryController c;

        [Fake]
        IMapper<Country, CountryInput> v;
        [Fake]
        ICrudService<Country> s;

        [SetUp]
        public void SetUp()
        {
            Fake.InitializeFixture(this);
            c = new CountryController(s, v);
        }

        [Test]
        public void Testcs()
        {
            var s = "123.1231231239872371973832";
            var d = Convert.ToDouble(s);
            var i = (int)d;
            Assert.AreEqual(123, i);
        }

        [Test]
        public void CreateShouldBuildNewInput()
        {
            c.Create();
            A.CallTo(() => v.MapToInput(A<Country>.Ignored)).MustHaveHappened();
        }

        [Test]
        public void CreateShouldReturnViewForInvalidModelstate()
        {
            c.ModelState.AddModelError("", "");
            c.Create(A.Fake<CountryInput>()).ShouldBeViewResult();
        }

        [Test]
        public void EditShouldReturnCreateView()
        {
            A.CallTo(() => s.Get(testGuid)).Returns(A.Fake<Country>());
            c.Edit(testGuid).ShouldBeViewResult().ShouldBeCreate();
            A.CallTo(() => s.Get(testGuid)).MustHaveHappened();
        }

        [Test]
        public void EditShouldThrowException()
        {
            A.CallTo(() => s.Get(testGuid)).Returns(null);
            Assert.Throws<iOpsException>(() => c.Edit(testGuid));
            A.CallTo(() => v.MapToInput(A<Country>.Ignored)).MustNotHaveHappened();
        }

        [Test]
        public void EditShouldReturnViewForInvalidModelstate()
        {
            c.ModelState.AddModelError("", "");
            c.Edit(A.Fake<CountryInput>()).ShouldBeViewResult().ShouldBeCreate();
        }

        [Test]
        public void EditShouldReturnContentOnError()
        {
            A.CallTo(() => v.MapToEntity(A<CountryInput>.Ignored, A<Country>.Ignored)).Throws(new iOpsException("aa"));
            c.Edit(A.Fake<CountryInput>()).ShouldBeContent().Content.ShouldEqual("aa");
        }

        [Test]
        public void DeleteShouldRedirectToIndex()
        {
            c.Delete(testGuid).ShouldBeJson();
            A.CallTo(() => s.Delete(testGuid)).MustHaveHappened();
        }
    }
}