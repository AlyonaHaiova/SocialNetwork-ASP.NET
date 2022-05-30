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
            return context.Relationships
                .Where(r => HasRelationship(userId, r.User1Id, r.User2Id))
                .Include(r => r.User1)
                .Include(r => r.User2)
                .Select(r => GetRelatedUser(userId, r))
                .ToList();
        }

     /*   public IEnumerable<UserEntity> GetFriendsOfUser(int userId)
        {
            return context.Relationships
                .Where(r => HasRelationship(userId, r.User1Id, r.User2Id))
                .Include(r => r.User1)
                .Include(r => r.User2)
                .Select(r => GetFriend(userId, r))
                .ToList();
        }*/

        private bool HasRelationship(int userId, int user1Id, int user2Id)
        {
            return user1Id == userId || user2Id == userId;
        }

        private UserEntity GetRelatedUser(int userId, RelationshipEntity relationship)
        {
            return relationship.User1Id == userId ? relationship.User2 : relationship.User1;
        }



        /*private UserEntity GetFriend(int userId, RelationshipEntity relationship)
        {
            return relationship.User1Id == userId ? relationship.User2 : relationship.User1;
        }
*/

        public UserEntity GetUserByEmail(string email)
        {
            return context.Users.Where(u => u.Email == email).FirstOrDefault();
        }
    }
}