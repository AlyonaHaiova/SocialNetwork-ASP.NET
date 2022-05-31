using SocialNetwork.Repository.Abstract;
using SocialNetwork.Entities;
using SocialNetwork.Context;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.Repository.Impl
{

    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(SocialNetworkContext context) : base(context)
        {
        }

        public IEnumerable<UserEntity> GetRelatedUsers(int userId)
        {
            List<int> userIds = context.Relationships
                .Where(r => r.User1Id == userId || r.User2Id == userId)
                .Select(r => r.User1Id == userId ? r.User2Id : r.User1Id)
                .ToList();
 
            return userIds.Select(id => GetById(id)).ToList();
        }

        public UserEntity GetUserByEmail(string email)
        {
            return context.Users.Where(u => u.Email == email).FirstOrDefault();
        }
    }
}