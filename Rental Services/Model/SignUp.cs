﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Services.Model
{
    public class SignUpRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
    }

    public enum Roles
    {
        ADMIN, CUSTOMER
    }
}
