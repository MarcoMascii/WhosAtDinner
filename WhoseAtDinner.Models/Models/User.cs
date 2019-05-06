using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WhoseAtDinner.Models.Models
{
    public class User : BaseItem
    {
        [Key]
        public Guid UID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Group> UserGroups { get; set; }
    }
}
