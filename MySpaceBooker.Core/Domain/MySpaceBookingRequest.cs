﻿using System;

namespace MySpaceBooker.Core.Domain
{
    public class MySpaceBookingRequest

    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}