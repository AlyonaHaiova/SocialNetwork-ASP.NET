using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.Services.Abstract
{
    public interface IUserService
    {
        public User GetById(int id);

        public List<User> GetAll();

        public List<User> GetFriends(int userId);

        public List<User> GetNotFriends(int userId, int limit);

        public int AddUserToFriends(int userId, int friendId);

        public int DeleteUserFromFriends(int userId, int friendId);

        public int Login(string email, string password);

        public int Register(string nickname, string email, string password);
    }
}
