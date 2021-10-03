using Bongo.Core.Services;
using Bongo.DataAccess.Repository.IRepository;
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
        private Mock<IStudyRoomBookingRepository> _studyRoomBookingRepoMock;
        private Mock<IStudyRoomRepository> _studyRoomRepoMock;
        private StudyRoomBookingService _bookingService;

        [SetUp]
        public void Setup()
        {
            this._studyRoomBookingRepoMock = new Mock<IStudyRoomBookingRepository>();
            this._studyRoomRepoMock = new Mock<IStudyRoomRepository>();
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
    }
}
