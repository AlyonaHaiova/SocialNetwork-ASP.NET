using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.Services.Abstract
{   
    
    public interface IRequestService
    {
        public int SendRequestForFriendship(int senderId, int receiverId);

        public int AcceptRequest(int relationshipId);

        public int DeclineRequest(int relationshipId);

        public List<Relationship> GetRequestsToUser(int userId);

        public List<Relationship> GetRequestsFromUser(int userId);

        public void CancelUsersRequest(int relationshipId);
    }
}
