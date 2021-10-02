using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sparky
{
    
    public class GradingCalculatorXUnitTests
    {
        private GradingCalculator _gCalculator;

        public GradingCalculatorXUnitTests()
        {
            this._gCalculator = new GradingCalculator();
        }

        [Fact]
        public void GetGrade_SetScoreAndAttendancePercentage_ReturnGradeA()
        {
            // Arrange
            this._gCalculator.Score = 95;
            this._gCalculator.AttendancePercentage = 90;
            var calcGrading = this._gCalculator.GetGrade();

            // Assert
            Assert.Equal("A", calcGrading);
        }

        [Fact]
        public void GetGrade_SetScoreAndAttendancePercentage_ReturnGradeB()
        {
            // Arrange
            this._gCalculator.Score = 85;
            this._gCalculator.AttendancePercentage = 90;
            var calcGrading = this._gCalculator.GetGrade();

            // Assert
            Assert.Equal("B", calcGrading);
            this._gCalculator.Score = 95;
            this._gCalculator.AttendancePercentage = 65;
            Assert.Equal("B", this._gCalculator.GetGrade());
        }

        [Fact]
        public void GetGrade_SetScoreAndAttendancePercentage_ReturnGradeC()
        {
            // Arrange
            this._gCalculator.Score = 65;
            this._gCalculator.AttendancePercentage = 90;
            var calcGrading = this._gCalculator.GetGrade();

            // Assert
            Assert.Equal("C", calcGrading);
        }

        [Theory]
        [InlineData(95, 55)]
        [InlineData(65, 55)]
        [InlineData(50, 90)]
        public void GetGrade_SetScoreAndAttendancePercentage_ReturnGradeF(int score, int attendance)
        {
            // Arrange
            this._gCalculator.Score = score;
            this._gCalculator.AttendancePercentage = attendance;
            var calcGrading = this._gCalculator.GetGrade();

            // Assert
            Assert.Equal("F", calcGrading);
        }

        [Theory]
        [InlineData(95, 90, "A")]
        [InlineData(85, 90, "B")]
        [InlineData(65, 90, "C")]
        [InlineData(95, 55, "F")]
        [InlineData(95, 65, "B")]
        [InlineData(65, 55, "F")]
        [InlineData(50, 90, "F")]
        public void GetGrade_AllGradeLogicalScenarios_ReturnGrade(int score, int attendance, string eResult)
        {
            // Arrange
            this._gCalculator.Score = score;
            this._gCalculator.AttendancePercentage = attendance;
            
            Assert.Equal(eResult, this._gCalculator.GetGrade());
        }
    }
}
