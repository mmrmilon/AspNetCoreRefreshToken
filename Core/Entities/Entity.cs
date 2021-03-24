using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
