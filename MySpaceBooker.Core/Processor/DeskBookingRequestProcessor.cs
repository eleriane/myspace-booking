using MySpaceBooker.Core.DataInterface;
using MySpaceBooker.Core.Domain;
using System;

namespace MySpaceBooker.Core
{
    public class DeskBookingRequestProcessor
    {
        private readonly IMySpaceBookingRepository _mySpaceRepository;

        public DeskBookingRequestProcessor(IMySpaceBookingRepository mySpaceRepository)
        {
            _mySpaceRepository = mySpaceRepository;
        }

        public IMySpaceBookingRepository MySpaceRepository { get; }

        public MySpaceBookingResult BookMySpace(MySpaceBookingRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            _mySpaceRepository.Save(CreateMySpace(request));

            return new MySpaceBookingResult
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Date = request.Date
            };
        }

        private static MySpaceBooking CreateMySpace(MySpaceBookingRequest request)
        {
            return new MySpaceBooking
            {

                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Date = request.Date
            };
        }
    }
}