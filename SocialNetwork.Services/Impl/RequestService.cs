using SocialNetwork.Entities;
using SocialNetwork.Mappers.Abstract;
using SocialNetwork.Models;
using SocialNetwork.Repository.Abstract;
using SocialNetwork.Enums;
using SocialNetwork.Services.Abstract;
using System.Collections.Generic;
using System.Linq;
using SocialNetwork.UOW.Abstract;

namespace SocialNetwork.Services.Impl
{
    public class RequestService : IRequestService
    {
        private readonly IUnitOfWork uow;
        private readonly IGenericMapper<UserEntity, User> userMapper;
        private readonly IUserRepository userRepository;
        private readonly IRelationshipRepository relationshipRepository;
        private readonly IRelationshipService relationshipService;

        public RequestService(IUnitOfWork uow, IGenericMapper<UserEntity, User> userMapper, IRelationshipService relationshipService)
        {
            this.uow = uow;
            this.userMapper = userMapper;
            this.relationshipService = relationshipService;
            userRepository = uow.Users();
            relationshipRepository = uow.Relationships();
        }
        public int SendRequestForFriendship(int senderId, int receiverId)
        {
            Relationship relationship = new Relationship();
            relationship.User1 = userMapper.ToModel(userRepository.GetById(senderId));
            relationship.User2 = userMapper.ToModel(userRepository.GetById(receiverId));
            relationship.RelationshipStatus = RelationshipStatus.Waiting;
            int id = relationshipService.AddRelationship(relationship);
            return id;
        }

        public int AcceptRequest(int relationshipId)
        {
            return relationshipRepository.ChangeRelationshipStatus(relationshipId, RelationshipStatus.Friendship);
        }

        public int DeclineRequest(int relationshipId)
        {
            return relationshipRepository.ChangeRelationshipStatus(relationshipId, RelationshipStatus.DeclinedFriendship);
        }

        public void CancelUsersRequest(int relationshipId)
        {
            relationshipRepository.Remove(relationshipId);
        }

        public List<Relationship> GetRequestsToUser(int userId)
        {
            return relationshipService.GetRelationshipsOfUser(userId)
                                       .Where(r => r.RelationshipStatus == RelationshipStatus.Waiting && r.User2.Id == userId)
                                       .ToList();
        }

        public List<Relationship> GetRequestsFromUser(int userId)
        {
            return relationshipService.GetRelationshipsOfUser(userId)
                                       .Where(r => r.RelationshipStatus == RelationshipStatus.Waiting && r.User1.Id == userId)
                                       .ToList();
        }
    }
}
