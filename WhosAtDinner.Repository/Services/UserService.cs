using System;
using System.Linq;
using WhoseAtDinner.Models.Models;

namespace WhosAtDinner.Repository.Services
{
    public class UserService
    {
        public static User GetUser(Guid uid)
        {
            User user = null;
            using (WhoseAtDinnerContext context = new WhoseAtDinnerContext())
            {
                user = context.Users.Find(uid);
            }

            return user;
        }

        public static IQueryable<User> GetAllUsers()
        {
            IQueryable<User> users = null;
            using (WhoseAtDinnerContext context = new WhoseAtDinnerContext())
            {
                users = context.Users;
            }

            return users;
        }
        public static void AddUser(User user)
        {
            using (WhoseAtDinnerContext context = new WhoseAtDinnerContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public static void UpdateUser(User user)
        {
            using (WhoseAtDinnerContext context = new WhoseAtDinnerContext())
            {
                User existingUser = context.Users.Where(s => s.UID == user.UID)
                                                        .FirstOrDefault<User>();

                if (existingUser != null)
                {
                    context.SaveChanges();
                }
            }
        }

    }
}
