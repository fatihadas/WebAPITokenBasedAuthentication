﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiOAuth.Models
{
    public class User
    {
        public User()
        {
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
