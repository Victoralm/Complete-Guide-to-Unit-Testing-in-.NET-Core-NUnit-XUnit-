using Bongo.Core.Services;
using Bongo.DataAccess.Repository.IRepository;
using Bongo.Models.Model;
using Bongo.Models.Model.VM;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bongo.Core
{
    [TestFixture]
    public class StudyRoomBookingServiceTests
    {
        private StudyRoomBooking _request;
        private List<StudyRoom> _aviableStudyRoom;
        private Mock<IStudyRoomBookingRepository> _studyRoomBookingRepoMock;
        private Mock<IStudyRoomRepository> _studyRoomRepoMock;
        private StudyRoomBookingService _bookingService;

        [SetUp]
        public void Setup()
        {
            this._request = new StudyRoomBooking
            {
                FirstName = "Ben",
                LastName = "Spark",
                Email = "ben@gmail.com",
                Date = new DateTime(2022, 1, 1),
            };

            this._aviableStudyRoom = new List<StudyRoom>
            {
                new StudyRoom
                {
                    Id = 10,
                    RoomName = "Michigan",
                    RoomNumber = "A202",
                }
            };

            this._studyRoomBookingRepoMock = new Mock<IStudyRoomBookingRepository>();
            this._studyRoomRepoMock = new Mock<IStudyRoomRepository>();

            this._studyRoomRepoMock.Setup(x => x.GetAll()).Returns(this._aviableStudyRoom);

            this._bookingService = new StudyRoomBookingService(
                this._studyRoomBookingRepoMock.Object,
                this._studyRoomRepoMock.Object
                );
        }

        [Test]
        public void GelAllBooking_InvokeMethod_CheckIfRepoIsCalled()
        {
            this._bookingService.GetAllBooking();
            this._studyRoomBookingRepoMock.Verify(x => x.GetAll(null), Times.Once);
        }

        [Test]
        public void BookingException_NullRequest_ThrowsException()
        {
            var exception = Assert.Throws<ArgumentNullException>(
                () => this._bookingService.BookStudyRoom(null));

            Assert.AreEqual("Value cannot be null. (Parameter 'request')", exception.Message);
            Assert.AreEqual("request", exception.ParamName);
        }

        [Test]
        public void StudyRoomBooking_SaveBookingWithAviableRoom_ReturnResultWithAllValues()
        {
            // Arrange
            StudyRoomBooking savedStudyRoomBooking = null;
            this._studyRoomBookingRepoMock.Setup(x => x.Book(It.IsAny<StudyRoomBooking>()))
                .Callback<StudyRoomBooking>(booking =>
                {
                    savedStudyRoomBooking = booking;
                });

            // Act
            this._bookingService.BookStudyRoom(this._request);

            // Assert
            this._studyRoomBookingRepoMock.Verify(x => x.Book(It.IsAny<StudyRoomBooking>()), Times.Once);
            Assert.NotNull(savedStudyRoomBooking);
            Assert.AreEqual(this._request.FirstName, savedStudyRoomBooking.FirstName);
            Assert.AreEqual(this._request.LastName, savedStudyRoomBooking.LastName);
            Assert.AreEqual(this._request.Email, savedStudyRoomBooking.Email);
            Assert.AreEqual(this._request.Date, savedStudyRoomBooking.Date);
            Assert.AreEqual(this._aviableStudyRoom.First().Id, savedStudyRoomBooking.StudyRoomId);
        }

        [Test]
        public void StudyRoomBookingCheck_InputRequest_ValuesMatchInResult()
        {
            StudyRoomBookingResult result = this._bookingService.BookStudyRoom(this._request);

            Assert.NotNull(result);
            Assert.AreEqual(this._request.FirstName, result.FirstName);
            Assert.AreEqual(this._request.LastName, result.LastName);
            Assert.AreEqual(this._request.Email, result.Email);
            Assert.AreEqual(this._request.Date, result.Date);
        }

        [TestCase(true, ExpectedResult = StudyRoomBookingCode.Success)]
        [TestCase(false, ExpectedResult = StudyRoomBookingCode.NoRoomAvailable)]
        //public void ResultCodeSuccess_RoomAviability_ReturnSuccessResultCode()
        public StudyRoomBookingCode ResultCodeSuccess_RoomAviability_ReturnSuccessResultCode(bool roomAviability)
        {
            //var result = this._bookingService.BookStudyRoom(this._request);

            //Assert.AreEqual(StudyRoomBookingCode.Success, result.Code);

            if (!roomAviability)
                this._aviableStudyRoom.Clear();

            return this._bookingService.BookStudyRoom(this._request).Code;
        }
    }
}
