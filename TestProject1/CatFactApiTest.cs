using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using App1.Models;
using NUnit.Framework;
using Moq;
using Moq.Protected;

namespace TestProject1
{
    
    public class CatFactApiTest
    {

        [Test]
        public async Task GetRandomCatFactReturnsFactWithText()
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
                .Protected()
                // Setup the PROTECTED method to mock
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                // prepare the expected response of the mocked http call
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{'Text':'This is a fact!'}"),
                })
                .Verifiable();
            
            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/"),
            };
            
            var unit =  new CatFactApi(httpClient);

            var fact = await unit.GetRandomCatFact();

            Assert.AreEqual("This is a fact!",fact.Text);
        }
        
    }
}