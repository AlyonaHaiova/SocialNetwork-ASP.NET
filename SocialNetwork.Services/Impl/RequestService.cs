using SocialNetwork.Entities;
using SocialNetwork.Mappers.Abstract;
using SocialNetwork.Mappers.Impl;
using SocialNetwork.Models;
using SocialNetwork.UOW.Impl;
using SocialNetwork.Repository.Abstract;
using SocialNetwork.Enums;
using SocialNetwork.Services.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Services.Impl
{
    public class RequestService
    {
        private readonly IGenericMapper<UserEntity, User> userMapper;
        private readonly IUserRepository userRepository;
        private readonly IRelationshipRepository relationshipRepository;
        private readonly IRelationshipService relationshipService;

        public RequestService()
        {
            userMapper = new UserMapper();
            userRepository = new UnitOfWork().Users;
            relationshipRepository = new UnitOfWork().Relationships;
            relationshipService = new RelationshipService();

        }
        public int SendRequestForFriendship(int senderId, int receiverId)
        {
            Relationship relationship = new Relationship();
            relationship.User1 = userMapper.ToModel(userRepository.GetById(senderId));
            relationship.User2 = userMapper.ToModel(userRepository.GetById(receiverId));
            relationship.RelationshipStatus = RelationshipStatus.Waiting;
            relationshipService.AddRelationship(relationship);
            return relationship.Id;

        }

        public int AcceptRequest(int relationshipId)
        {
            var relationship = relationshipRepository.GetById(relationshipId);
            relationship.RelationshipStatus = RelationshipStatus.Friendship;
            relationshipRepository.Update(relationship);
            return relationshipId;
        }

        public int DeclineRequest(int relationshipId)
        {
            var relationship = relationshipRepository.GetById(relationshipId);
            relationship.RelationshipStatus = RelationshipStatus.DeclinedFriendship;
            relationshipRepository.Update(relationship);
            return relationshipId;
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
