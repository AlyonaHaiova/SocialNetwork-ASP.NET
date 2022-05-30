using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Services.Abstract
{
    public interface IRelationshipService
    {
        public bool AreFriends(int relationshipId);
        public bool AreFriends(int user1Id, int user2Id);
        public int AddRelationship(Relationship relashionship);
    }
}
