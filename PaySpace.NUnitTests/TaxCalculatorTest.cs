using Moq;
using NuGet;
using NUnit.Framework;
using PaySpace.DataLayer.Model;
using PaySpace.DataLayer.Repository;
using PaySpace.TaxCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PaySpace.NUnitTests
{
    [TestFixture]
    public class TaxCalculatorTest
    {
        public TaxCalculatorTest()
        {
        }

        [Test]
        public async Task Test_Get_Flat_Rate_Tax_Async()
        {
            var mock = new Mock<ICalculator>();
            var result = mock.Setup(x => x.GetFlatRateTaxAsync(It.IsAny<decimal>())).Returns(()=> Task.FromResult(new TaxCalculator.Tax { Amount = 175.0m, Income = 1000 }));
            var tax = await mock.Object.GetFlatRateTaxAsync(1000);
            
            Assert.AreEqual(175.0m, tax.Amount);
        }

        [Test]
        public async Task Test_Get_Postal_Codes_Async()
        {
            var mock = new Mock<IPostalCodeRepository>();
            var result = mock.Setup(x => x.Get(It.IsAny<PostalCode>())).Returns(() => Task.FromResult(new PostalCode {Id =1, Code = "7441" }));
            var postalCode = await mock.Object.Get(new PostalCode { Id = 1, Code = "7441" });

            Assert.AreEqual(1, postalCode.Id);
        }

        //public void Test_Get_Flat_Rate_Tax_Async()
        //{
        //    var mockClient = new Mock<IHttpClient>();
        //    mockClient.Setup(c => c.PostAsync(
        //        It.IsAny<Uri>(),
        //        It.IsAny<HttpContent>()
        //        )).Returns(() => new Task<HttpResponseMessage>(() => new HttpResponseMessage(System.Net.HttpStatusCode.OK)));

        //}

    }

}
