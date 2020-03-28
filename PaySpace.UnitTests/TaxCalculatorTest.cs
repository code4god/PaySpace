using NUnit.Framework;
using PaySpace.TaxCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaySpace.UnitTests
{
    [TestFixture]
    public class TaxCalculatorTest
    {
        private ICalculator _calculator;
        public TaxCalculatorTest(ICalculator calculator)
        {
            _calculator = calculator;
        }
        [Test]
        public void Test_Get_Flat_Rate_Tax_()
        {
            var tax = _calculator.GetFlatRateTaxAsync(1000);
            Assert.AreEqual(175.0m, tax.Result.Amount);
        }
    }

}
