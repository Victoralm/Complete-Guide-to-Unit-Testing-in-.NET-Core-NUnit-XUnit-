﻿using Bongo.Core.Services.IServices;
using Bongo.Models.Model;
using Bongo.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bongo.Web
{
    [TestFixture]
    public class RoomBookingControllerTests
    {
        private Mock<IStudyRoomBookingService> _studyRoomBookingService;
        private RoomBookingController _bookingController;

        [SetUp]
        public void Setup()
        {
            this._studyRoomBookingService = new Mock<IStudyRoomBookingService>();
            this._bookingController = new RoomBookingController(this._studyRoomBookingService.Object);
        }

        [Test]
        public void IndexPage_CallRequest_VerifyGetAllInvoked()
        {
            this._bookingController.Index();
            this._studyRoomBookingService.Verify(x => x.GetAllBooking(), Times.Once);
        }

        [Test]
        public void BookRoomCheck_ModelStateInvalid_ReturnView()
        {
            this._bookingController.ModelState.AddModelError("test", "test");
            var result = this._bookingController.Book(new StudyRoomBooking());

            ViewResult viewResult = result as ViewResult;

            Assert.AreEqual("Book", viewResult.ViewName);
        }
    }
}
