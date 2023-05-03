using Business.Concrete;
using DataAccess.Abstract;
using Entities;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests
{
    [TestFixture]// test clası oldugunu belirtir
    public class ColorManagerTests
    {
        private Mock<IColorDal> _colorDalMock;
        private ColorManager _colorManager;
        [SetUp]
        public void Setup()
        {
            _colorDalMock= new Mock<IColorDal>();
            _colorManager =new ColorManager(_colorDalMock.Object);

        }

        [Test]
        public void Add_ShouldAddNewColor()
        {
            // Arrance (Test verilerinn hazırlanması)
            var newColor = new Color { Name = "Red" };
            _colorDalMock.Setup(m=> m.Add(newColor));

            //Act (Test senaryosunun gerçekleştirilmesi)
            _colorManager.Add(newColor);

            //Assert(Test sonuçlarınn doğrulanması)
            _colorDalMock.Verify(m=> m.Add(newColor),Times.Once);
        }

        [Test]
        public void GetAll_ShouldReturnAllColor()
        {
            //Arange
            var colors = new List<Color>
            {
                new Color{Id=1,Name="Red"},
                new Color{Id=2,Name="Blue"}
            };
            _colorDalMock.Setup(m=> m.GetAll(null)).Returns(colors);

            //Act
            var result = _colorManager.GetAll();

            //Asert
            Assert.AreEqual(colors.Count, result.Count);
            Assert.AreEqual(colors.First().Name, result.First().Name);
            Assert.AreEqual(colors.Last().Name, result.Last().Name);

        }
    }
}
