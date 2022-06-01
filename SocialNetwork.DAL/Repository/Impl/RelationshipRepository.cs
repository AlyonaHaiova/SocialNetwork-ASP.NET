using SocialNetwork.Repository.Abstract;
using SocialNetwork.Entities;
using SocialNetwork.Context;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Enums;

namespace SocialNetwork.Repository.Impl
{

    public class RelationshipRepository : GenericRepository<RelationshipEntity>, IRelationshipRepository
    {
        public RelationshipRepository(SocialNetworkContext context) : base(context) { }

        public RelationshipEntity GetByUsersIds(int user1Id, int user2Id)
        {
            return context.Relationships.Where(r => r.User1Id == user1Id && r.User2Id == user2Id || r.User2Id == user1Id && r.User1Id == user2Id).FirstOrDefault();
        }

        public List<RelationshipEntity> GetRelationshipsOfUser(int userId)
        {
            return context.Relationships
                .Where(r => r.User1Id == userId || r.User2Id == userId)
                .Include(r => r.User1)
                .Include(r => r.User2)
                .ToList();
        }

        public int ChangeRelationshipStatus(int id, RelationshipStatus status)
        {
            RelationshipEntity entity = GetById(id);
            entity.RelationshipStatus = status;
            Update(entity);
            return entity.Id;
        }
    }
}