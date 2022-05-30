using SocialNetwork.Entities;
using SocialNetwork.Mappers.Abstract;
using SocialNetwork.Models;

namespace SocialNetwork.Mappers.Impl
{
    public class UserMapper : IGenericMapper<UserEntity, User>
    {
        public UserEntity ToEntity(User model)
        {
            return new UserEntity()
            {
                Id = model.Id,
                Nickname = model.Nickname,
                Email = model.Email,
                Password = model.Password,
            };
        }

        public User ToModel(UserEntity entity)
        {
            return new User()
            {
                Id = entity.Id,
                Nickname = entity.Nickname,
                Email = entity.Email,
                Password = entity.Password,
            };
        }
    }
}