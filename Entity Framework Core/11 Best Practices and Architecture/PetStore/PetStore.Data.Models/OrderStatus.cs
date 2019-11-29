using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Data.Models
{
    public enum OrderStatus
    {
        Pending = 0,
        Received = 1,
        Paid = 2,
        Closed = 3
    }
}
