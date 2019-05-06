using System;
using System.ComponentModel.DataAnnotations;

namespace WhoseAtDinner.Models.Models
{
    public class Presence : BaseItem
    {
        [Key]
        public Guid UID { get; set; }        
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
        public User User { get; set; }
        public Group Group { get; set; }
    }
}
