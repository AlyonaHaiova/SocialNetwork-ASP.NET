using SocialNetwork.Entities;
using System.Collections.Generic;

namespace SocialNetwork.Repository.Abstract
{

    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        public IEnumerable<UserEntity> GetRelatedUsers(int userId);
        public UserEntity GetUserByEmail(string email);

    }
}