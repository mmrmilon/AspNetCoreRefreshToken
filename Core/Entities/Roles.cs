using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Roles : Entity
    {
        public string RoleName { get; set; }

        public bool IsActive { get; set; }
    }
}
