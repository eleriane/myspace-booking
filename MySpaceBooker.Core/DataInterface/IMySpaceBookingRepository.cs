using MySpaceBooker.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySpaceBooker.Core.DataInterface
{
    public interface IMySpaceBookingRepository
    {
        void Save(MySpaceBooker.Core.Domain.MySpaceBooking deskBooking);
    }
}
