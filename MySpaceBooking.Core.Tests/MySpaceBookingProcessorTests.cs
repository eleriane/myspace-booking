using Moq;
using MySpaceBooker.Core.DataInterface;
using MySpaceBooker.Core.Domain;
using System;
using Xunit;

namespace MySpaceBooker.Core
{
    public class MySpaceBookingProcessorTests
    {
        private MySpaceBookingRequest _request;
        private Mock<IMySpaceBookingRepository> _mySpaceBookingRepositoryMock;
        private DeskBookingRequestProcessor _processor;

        public MySpaceBookingProcessorTests()
        {
            _request = new MySpaceBookingRequest
            {
                FirstName = "Marilia",
                LastName = "Costa",
                Email = "marialia.costa@ig.com.br",
                Date = new DateTime(2020, 4, 25)
            };

            _mySpaceBookingRepositoryMock = new Mock<IMySpaceBookingRepository>();

            _processor = new DeskBookingRequestProcessor(_mySpaceBookingRepositoryMock.Object);
        }

        [Fact]
        public void ShouldReturnDeskBookingResultWithRequestValues()
        {
            //Act
            MySpaceBookingResult result = _processor.BookMySpace(_request);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(_request.FirstName, result.FirstName);
            Assert.Equal(_request.LastName, result.LastName);
            Assert.Equal(_request.Email, result.Email);
            Assert.Equal(_request.Date, result.Date);

        }

        [Fact]
        public void ShouldThrowExceptionIfRequestNull()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => _processor.BookMySpace(null));
            Assert.Equal("request", exception.ParamName);
        }

        [Fact]
        public void ShouldSaveMySpaceBooking()
        {
            MySpaceBooking savedMySpaceBooking = null;

            _mySpaceBookingRepositoryMock.Setup(x => x.Save(It.IsAny<MySpaceBooking>()))
                .Callback<MySpaceBooking>(mySpaceBooking =>
               {
                   savedMySpaceBooking = mySpaceBooking;
               });
            _processor.BookMySpace(_request);

            _mySpaceBookingRepositoryMock.Verify(x => x.Save(It.IsAny<MySpaceBooking>()), Times.Once);

            Assert.NotNull(savedMySpaceBooking);
            Assert.Equal(_request.FirstName, savedMySpaceBooking.FirstName);
            Assert.Equal(_request.LastName, savedMySpaceBooking.LastName );
            Assert.Equal(_request.Email, savedMySpaceBooking.Email);
            Assert.Equal(_request.Date, savedMySpaceBooking.Date);
        }
    }
}
