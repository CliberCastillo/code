﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Resilient.Polly.API.Infrastructure.Data.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public String Description { get; set; }
    }
}
