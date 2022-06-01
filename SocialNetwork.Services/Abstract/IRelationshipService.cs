using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.Services.Abstract
{
    public interface IRelationshipService
    {
        public bool AreFriends(int relationshipId);

        public bool AreFriends(int user1Id, int user2Id);

        public bool HasRelationship(int user1Id, int user2Id);

        public int AddRelationship(Relationship relashionship);

        List<Relationship> GetRelationshipsOfUser(int userId);
    }
}
