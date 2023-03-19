using System;
using FileStorage.Api.Models;

namespace FileStorage.Api.Business.Interfaces
{
	public interface IUserBL
	{
		List<User> GetUsers();
		User GetUser(Guid id);
		Guid CreateUser(User user);
		bool DeleteUser(Guid id);

	}
}

