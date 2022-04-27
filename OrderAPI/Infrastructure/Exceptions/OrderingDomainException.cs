﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAPI.Infrastructure.Exceptions
{
    public class OrderingDomainException : Exception
    {
        public OrderingDomainException() : base() { }

        public OrderingDomainException(string message) : base(message) { }

        public OrderingDomainException(string message, Exception innerException) :
            base(message, innerException)
        { }
    }
}
