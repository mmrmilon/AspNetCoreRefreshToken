using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Entity
    {
        public long Id { get; set; }
        
        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int LastUpdatedBy { get; set; }

        public DateTime LastUpdatedOn { get; set; }

        public Entity()
        {
            CreatedOn = DateTime.UtcNow;
            LastUpdatedOn = DateTime.UtcNow;
        }
    }
}
