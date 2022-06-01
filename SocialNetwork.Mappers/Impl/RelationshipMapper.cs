using SocialNetwork.Entities;
using SocialNetwork.Mappers.Abstract;
using SocialNetwork.Models;

namespace SocialNetwork.Mappers.Impl
{
    public class RelationshipMapper : IGenericMapper<RelationshipEntity, Relationship>
    {
        private readonly IGenericMapper<UserEntity, User> userMapper;

        public RelationshipMapper(IGenericMapper<UserEntity, User> userMapper)
        {
            this.userMapper = userMapper;
        }


        public Relationship ToModel(RelationshipEntity entity)
        {
            return new Relationship()
            {
                Id = entity.Id,
                User1 = userMapper.ToModel(entity.User1),
                User2 = userMapper.ToModel(entity.User2),
                RelationshipStatus = entity.RelationshipStatus,
            };
        }

        public RelationshipEntity ToEntity(Relationship model)
        {
            return new RelationshipEntity()
            {
                Id = model.Id,
                User1Id = model.User1.Id,
                User2Id = model.User2.Id,
                RelationshipStatus = model.RelationshipStatus,
            };
        }

    }
}