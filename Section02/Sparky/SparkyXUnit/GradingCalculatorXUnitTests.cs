using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class GradingCalculatorXUnitTests
    {
        private GradingCalculator _gCalculator;

        [SetUp]
        public void Setup()
        {
            this._gCalculator = new GradingCalculator();
        }

        [Test]
        public void GetGrade_SetScoreAndAttendancePercentage_ReturnGradeA()
        {
            // Arrange
            this._gCalculator.Score = 95;
            this._gCalculator.AttendancePercentage = 90;
            var calcGrading = this._gCalculator.GetGrade();

            // Assert
            Assert.AreEqual("A", calcGrading);
            Assert.That(calcGrading, Is.EqualTo("A"));
        }

        [Test]
        public void GetGrade_SetScoreAndAttendancePercentage_ReturnGradeB()
        {
            // Arrange
            this._gCalculator.Score = 85;
            this._gCalculator.AttendancePercentage = 90;
            var calcGrading = this._gCalculator.GetGrade();

            // Assert
            Assert.AreEqual("B", calcGrading);
            Assert.That(calcGrading, Is.EqualTo("B"));
            this._gCalculator.Score = 95;
            this._gCalculator.AttendancePercentage = 65;
            Assert.AreEqual("B", this._gCalculator.GetGrade());
            Assert.That(this._gCalculator.GetGrade(), Is.EqualTo("B"));
        }

        [Test]
        public void GetGrade_SetScoreAndAttendancePercentage_ReturnGradeC()
        {
            // Arrange
            this._gCalculator.Score = 65;
            this._gCalculator.AttendancePercentage = 90;
            var calcGrading = this._gCalculator.GetGrade();

            // Assert
            Assert.AreEqual("C", calcGrading);
            Assert.That(calcGrading, Is.EqualTo("C"));
        }

        [Test]
        [TestCase(95, 55)]
        [TestCase(65, 55)]
        [TestCase(50, 90)]
        public void GetGrade_SetScoreAndAttendancePercentage_ReturnGradeF(int score, int attendance)
        {
            // Arrange
            this._gCalculator.Score = score;
            this._gCalculator.AttendancePercentage = attendance;
            var calcGrading = this._gCalculator.GetGrade();

            // Assert
            Assert.AreEqual("F", calcGrading);
            Assert.That(calcGrading, Is.EqualTo("F"));
        }

        [Test]
        [TestCase(95, 90, ExpectedResult = "A")]
        [TestCase(85, 90, ExpectedResult = "B")]
        [TestCase(95, 65, ExpectedResult = "B")]
        [TestCase(65, 90, ExpectedResult = "C")]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]
        public string GetGrade_AllGradeLogicalScenarios_ReturnGrade(int score, int attendance)
        {
            // Arrange
            this._gCalculator.Score = score;
            this._gCalculator.AttendancePercentage = attendance;
            return this._gCalculator.GetGrade();
        }
    }
}
