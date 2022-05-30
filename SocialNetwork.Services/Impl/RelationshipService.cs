using SocialNetwork.Entities;
using SocialNetwork.Mappers.Abstract;
using SocialNetwork.Mappers.Impl;
using SocialNetwork.Models;
using SocialNetwork.UOW.Impl;
using SocialNetwork.Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Enums;
using SocialNetwork.Services.Abstract;

namespace SocialNetwork.Services.Impl
{

    public class RelationshipService : IRelationshipService
    {
        private readonly IGenericMapper<RelationshipEntity, Relationship> relationshipMapper;
        private readonly IRelationshipRepository repository;

        public RelationshipService()
        {
            relationshipMapper = new RelationshipMapper();
            repository = new UnitOfWork().Relationships;

        }


        public bool AreFriends(int relationshipId)
        {
            return repository.GetById(relationshipId).RelationshipStatus == RelationshipStatus.Friendship;
        }

        public bool AreFriends(int user1Id, int user2Id)
        {
            return repository.GetByUsersIds(user1Id, user2Id).RelationshipStatus == RelationshipStatus.Friendship;
        }

        public int AddRelationship(Relationship relationship)
        {
            repository.Insert(relationshipMapper.ToEntity(relationship));
            return relationship.Id;

        }
        // Add user to relationship

        // Ask for friendship

        // Invite user to friendship
    }
}