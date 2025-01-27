﻿using System;

namespace WebApplication.Models
{
    public class UserAccount
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Interest { get; set; }

        public string Notification { get; set; }
    }
}