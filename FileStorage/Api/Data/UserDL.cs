using System;
using FileStorage.Api.Data.Interfaces;
using FileStorage.Api.Models;

namespace FileStorage.Api.Data
{
	public class UserDL : IUserDL
	{
        public static List<User> usersDb = new List<User>();

        public Guid CreateUser(User user)
        {
            var userId = Guid.NewGuid();
            usersDb.Add(new User
            {
                Id = userId,
                Name = user.Name
            });
            
            return userId;
            
        }

        public bool DeleteUser(Guid id)
        {
            var user = GetUser(id);
            usersDb.Remove(user);
            return true;
        }

        public User GetUser(Guid id)
        {
            return usersDb.Where(w => w.Id == id).FirstOrDefault();
        }

        public List<User> GetUsers()
        {
            return usersDb;
        }
    }
}

