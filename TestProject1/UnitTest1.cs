using App1.Services;
using App1.Utils;
using App1.ViewModels;
using App1.Views;
using NUnit.Framework;
using Moq;
using Xamarin.Forms;

namespace TestProject1
{
    public class FirstPageViewModelTests
    {
        [SetUp]
        public void Setup()
        {
            
        }


        [Test]
        public void BatteryLevelIsReadWhenInitializingViewModel()
        {
            var nav = Mock.Of<INavigationService>();
            var mock = new Mock<IXamarinEssentials>();
            mock.Setup(e => e.BatteryLevel).Returns(0.8);
            var unit = new FirstPageViewModel( nav, mock.Object);

            Assert.AreEqual(0.8, unit.BatteryLevel);
        }
        
        
        [Test]
        public void DoNavigationNavigatesToSecondPageUsingMoq()
        {
            //Arrange
            var mock = new Mock<INavigationService>();
            INavigationService navService = mock.Object;
            IXamarinEssentials essentials = Mock.Of<IXamarinEssentials>();
            
            var unit = new FirstPageViewModel( navService, essentials);
            //Act
            unit.DoNavigation.Execute(null);
            //Assert
            mock.Verify(s => s.PushAsync(It.IsAny<Page>()));
        }
        
        
        [Test]
        public void DoNavigationNavigatesToSecondPage()
        {
            //Arrange
            NavigationServiceSpy navService = new NavigationServiceSpy();
            IXamarinEssentials essentials = new XamarinEssentialsStub();
            var unit = new FirstPageViewModel( navService, essentials);
            //Act
            unit.DoNavigation.Execute(null);
            //Assert
            Assert.IsTrue(navService.PushAsyncCalled);
            Assert.IsInstanceOf(typeof(SecondPage), navService.page);
        }

        [Test]
        public void SimpleAddTest()
        {
            //Arrange
            var unit = new FirstPageViewModel(null, null);
            //Act
            var actual = unit.Add(1, 2);

            //Assert
            Assert.AreEqual(3, actual);
        }
    }
}