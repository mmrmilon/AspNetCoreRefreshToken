using Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Users : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public UserStatus Status { get; set; }
    }
}
