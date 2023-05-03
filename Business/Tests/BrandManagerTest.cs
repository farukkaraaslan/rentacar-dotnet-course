using Business.Concrete;
using Business.Rules;
using Business.Rules.Validation.FluentValidation;
using DataAccess.Abstract;
using Entities;
using FluentValidation;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests
{
    [TestFixture]
    public class BrandManagerTest
    {
        private Mock<IBrandDal> _brandDalMock;
        private BrandBusinesRules _brandBusinesRules;
        private BrandManager _brandManager;

        [SetUp]
        public void Setup()
        {
            _brandDalMock = new Mock<IBrandDal>();
            _brandBusinesRules= new BrandBusinesRules(_brandDalMock.Object,new BrandValidator());
            _brandManager= new BrandManager(_brandDalMock.Object,_brandBusinesRules);
        }

        [Test]
        public void ValidateBrand_ShouldThrowExceptionIfBrandIsInvalid()
        {
            //Arrange
            var ınvalidBrand = new Brand { Name=""};

            //Act
            TestDelegate testDelegate = () => _brandBusinesRules.ValidateBrand(ınvalidBrand);

            //Assert
            Assert.Throws<ValidationException>(testDelegate);

            //Act & Assert(birlikte kullanım)
            //Assert.Throws<ValidationException>(()=>_brandBusinesRules.ValidateBrand(ınvalidBrand));
        }
    }
}
