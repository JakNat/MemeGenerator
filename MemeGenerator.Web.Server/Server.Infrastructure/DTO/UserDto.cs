﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Infrastructure.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}