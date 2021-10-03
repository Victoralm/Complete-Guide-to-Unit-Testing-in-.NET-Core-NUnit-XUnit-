using Bongo.DataAccess.Repository;
using Bongo.Models.Model;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bongo.DataAccess
{
    [TestFixture]
    public class StudyRoomBookingRepositoryTests
    {
        private StudyRoomBooking _studyRoomBooking_One;
        private StudyRoomBooking _studyRoomBooking_Two;

        public StudyRoomBookingRepositoryTests()
        {
            this._studyRoomBooking_One = new StudyRoomBooking()
            {
                FirstName = "Ben1",
                LastName = "Spark1",
                Date = new DateTime(2023, 1, 1),
                Email = "ben1@gmail.com",
                BookingId = 11,
                StudyRoomId = 1,
            };
            
            this._studyRoomBooking_Two = new StudyRoomBooking()
            {
                FirstName = "Ben2",
                LastName = "Spark2",
                Date = new DateTime(2023, 2, 2),
                Email = "ben2@gmail.com",
                BookingId = 22,
                StudyRoomId = 2,
            };
        }

        [Test]
        public void SaveBooking_BookingOne_CheckTheValuesFromDatabase()
        {
            // arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "temp_Bongo").Options;

            // act
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new StudyRoomBookingRepository(context);
                repository.Book(this._studyRoomBooking_One);
            }

            // assert
            using (var context = new ApplicationDbContext(options))
            {
                var bookingFromDb = context.StudyRoomBookings.FirstOrDefault(u => u.BookingId == 11);
                Assert.AreEqual(_studyRoomBooking_One.BookingId, bookingFromDb.BookingId);
                Assert.AreEqual(_studyRoomBooking_One.FirstName, bookingFromDb.FirstName);
                Assert.AreEqual(_studyRoomBooking_One.LastName, bookingFromDb.LastName);
                Assert.AreEqual(_studyRoomBooking_One.Date, bookingFromDb.Date);
                Assert.AreEqual(_studyRoomBooking_One.Email, bookingFromDb.Email);
                Assert.AreEqual(_studyRoomBooking_One.StudyRoomId, bookingFromDb.StudyRoomId);
            }
        }
    }
}
