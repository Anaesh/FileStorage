using System;
using System.Net;
using FileStorage.Api.Business.Interfaces;
using FileStorage.Api.Data;
using FileStorage.Api.Models;
using Microsoft.AspNetCore.Mvc.Core;

namespace FileStorage.Api.Business
{
    public class UserBL : IUserBL
    {
        public UserBL()
        {

        }
        private readonly UserDL _userDL = new UserDL();

        public Guid CreateUser(User user)
        {
            return _userDL.CreateUser(user);
        }

        public bool DeleteUser(Guid id)
        {
            var user = GetUser(id);
            return _userDL.DeleteUser(user.Id);
        }

        public User GetUser(Guid id)
        {
            var user = _userDL.GetUser(id);
            if(user is null)
            {
            }
            return user;
        }

        public List<User> GetUsers()
        {
            return _userDL.GetUsers();
        }
    }
}

