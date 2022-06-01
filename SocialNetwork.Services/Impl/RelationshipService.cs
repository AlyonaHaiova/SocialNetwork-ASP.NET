using SocialNetwork.Entities;
using SocialNetwork.Mappers.Abstract;
using SocialNetwork.Models;
using SocialNetwork.Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Enums;
using SocialNetwork.Services.Abstract;
using SocialNetwork.UOW.Abstract;

namespace SocialNetwork.Services.Impl
{

    public class RelationshipService : IRelationshipService
    {
        private readonly IUnitOfWork uow;
        private readonly IGenericMapper<RelationshipEntity, Relationship> relationshipMapper;
        private readonly IRelationshipRepository repository;

        public RelationshipService(IUnitOfWork uow, IGenericMapper<RelationshipEntity, Relationship> relationshipMapper)
        {
            this.uow = uow;
            this.relationshipMapper = relationshipMapper;
            repository = uow.Relationships(); 
        }

        public bool AreFriends(int relationshipId)
        {
            return repository.GetById(relationshipId).RelationshipStatus == RelationshipStatus.Friendship;
        }

        public bool AreFriends(int user1Id, int user2Id)
        {
            return repository.GetByUsersIds(user1Id, user2Id).RelationshipStatus == RelationshipStatus.Friendship;
        }

        public bool HasRelationship(int user1Id, int user2Id)
        {
            return repository.GetByUsersIds(user1Id, user2Id) == null;
        }

        public int AddRelationship(Relationship relationship)
        {
            RelationshipEntity relationshipEntity = relationshipMapper.ToEntity(relationship);
            repository.Insert(relationshipEntity);
            return relationshipEntity.Id;
        }

        public List<Relationship> GetRelationshipsOfUser(int userId)
        {
            return repository.GetRelationshipsOfUser(userId).Select(r => relationshipMapper.ToModel(r)).ToList();
        }
    }
}