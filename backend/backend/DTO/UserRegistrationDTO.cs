﻿using System;

namespace backend.DTO
{
    public class UserRegistrationDTO
    {
        public String FirstName{ get; set; }
        public String LastName { get; set; }
        public String Username { get; set; }

        public String Password { get; set; }

        public UserRegistrationDTO() {}
    }
}
