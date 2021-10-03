using Bongo.Models.ModelValidations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bongo.Models
{
    [TestFixture]
    public class DateFutureAttributeTests
    {
        [Test]
        [TestCase(100, ExpectedResult = true)]
        [TestCase(-100, ExpectedResult = false)]
        [TestCase(0, ExpectedResult = false)]
        public bool DateValidator_InputExpectedDateRange_DateValidity(int seconds)
        {
            DateInFutureAttribute dateInFutureAttribute = new(() => DateTime.Now);

            var result = dateInFutureAttribute.IsValid(DateTime.Now.AddSeconds(seconds));

            return result;
        }

        [Test]
        public void DateValidator_AnyDate_ReturnErrorMessage()
        {
            var result = new DateInFutureAttribute();

           Assert.AreEqual("Date must be in the future", result.ErrorMessage);
        }
    }
}
