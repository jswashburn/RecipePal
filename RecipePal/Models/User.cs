﻿using System.Collections.Generic;

namespace RecipePal.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public ICollection<Cookbook> Cookbooks { get; set; }
    }
}