using System;
using FileStorage.Api.Models;

namespace FileStorage.Api.Data.Interfaces
{
	public interface IUserDL
	{
        List<User> GetUsers();
        User GetUser(Guid id);
        Guid CreateUser(User user);
        bool DeleteUser(Guid id);
    }
}

