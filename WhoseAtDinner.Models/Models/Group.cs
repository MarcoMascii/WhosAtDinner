using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WhoseAtDinner.Models.Models
{
    public class Group : BaseItem
    {
        [Key]
        public Guid UID { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public User CreationUser { get; set; }
        public virtual ICollection<User> GroupUsers { get; set; }
    }
}
