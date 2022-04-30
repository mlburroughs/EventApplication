﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Messenging
{
    public class OrderCompletedEvent
    {
        public string BuyerId { get; set; }
        public OrderCompletedEvent(string buyerId)
        {
            BuyerId = buyerId;
        }
    }
}
