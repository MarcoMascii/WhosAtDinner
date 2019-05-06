using System.Data.Entity;
using WhoseAtDinner.Models.Models;

namespace WhosAtDinner.Repository
{
    public class WhoseAtDinnerContext : DbContext
    {
        public WhoseAtDinnerContext() : base("StringDBContext") { }

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Presence> Presences { get; set; }
    }
}
