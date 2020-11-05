using App1.Services;
using App1.Utils;
using App1.ViewModels;
using App1.Views;
using NUnit.Framework;

namespace TestProject1
{
    public class FirstPageViewModelTests
    {
        [SetUp]
        public void Setup()
        {
            
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