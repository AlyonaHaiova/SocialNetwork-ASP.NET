using SocialNetwork.Entities;

namespace SocialNetwork.Repository.Abstract
{

    public interface IRelationshipRepository : IGenericRepository<RelationshipEntity>
    {
        public RelationshipEntity GetByUsersIds(int user1Id, int user2Id);

    }
}