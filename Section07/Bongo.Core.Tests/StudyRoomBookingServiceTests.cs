using Bongo.Core.Services;
using Bongo.DataAccess.Repository.IRepository;
using Bongo.Models.Model;
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
    }
}
