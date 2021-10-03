using Bongo.DataAccess.Repository;
using Bongo.Models.Model;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections;
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
        private DbContextOptions<ApplicationDbContext> _options;

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

        [SetUp]
        public void Setup()
        {
            this._options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "temp_Bongo").Options;
        }

        [Test]
        [Order(1)]
        public void SaveBooking_BookingOne_CheckTheValuesFromDatabase()
        {
            // arrange

            // act
            using (var context = new ApplicationDbContext(this._options))
            {
                var repository = new StudyRoomBookingRepository(context);
                repository.Book(this._studyRoomBooking_One);
            }

            // assert
            using (var context = new ApplicationDbContext(this._options))
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

        [Test]
        [Order(2)]
        public void GetAllBooking_BookingOneAndTwo_CheckBothTheBookeingFromDatabase()
        {
            // arrange
            var expectedResult = new List<StudyRoomBooking> { this._studyRoomBooking_One, this._studyRoomBooking_Two };
            

            using (var context = new ApplicationDbContext(this._options))
            {
                var repository = new StudyRoomBookingRepository(context);
                /**
                 * Added [Order(value)] and EnsureDeleted() so
                 * both tests runs fine together and separately
                 */
                context.Database.EnsureDeleted();
                repository.Book(this._studyRoomBooking_One);
                repository.Book(this._studyRoomBooking_Two);
            }

            // act
            List<StudyRoomBooking> actualList;
            using (var context = new ApplicationDbContext(this._options))
            {
                var repository = new StudyRoomBookingRepository(context);
                actualList = repository.GetAll(null).ToList();
            }

            // assert
            CollectionAssert.AreEqual(expectedResult, actualList, new BookingCompare());
        }

        private class BookingCompare : IComparer
        {
            public int Compare(object x, object y)
            {
                var booking1 = (StudyRoomBooking)x;
                var booking2 = (StudyRoomBooking)y;

                if (booking1.BookingId != booking2.BookingId)
                    return 1;
                else
                    return 0;
            }
        }
    }
}
