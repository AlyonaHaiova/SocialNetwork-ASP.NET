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
    public class UserService : IUserService
    {
        private readonly IGenericMapper<UserEntity, User> userMapper;
        private readonly IUserRepository repository;
        private readonly IRelationshipService relationshipService;
        private readonly IRelationshipRepository relationshipRepository;

        public UserService()
        {
            userMapper = new UserMapper();
            repository = new UnitOfWork().Users;
            relationshipService = new RelationshipService();

        }

        public List<User> GetFriends(int userId)
        {
            return repository.GetRelatedUsers(userId)
                               .Where(u => relationshipService.AreFriends(u.Id, userId))
                               .Select(x => userMapper.ToModel(x)).ToList();
        }

        public int AddUserToFriends(int userId, int friendId)
        {
            Relationship relashionship = new Relationship();
            relashionship.User1 = userMapper.ToModel(repository.GetById(userId));
            relashionship.User2 = userMapper.ToModel(repository.GetById(friendId));
            relashionship.RelationshipStatus = RelationshipStatus.Friendship;
            return relationshipService.AddRelationship(relashionship);
        }

        public int DeleteUserFromFriends(int userId, int friendId)
        {
            RelationshipEntity relationship = relationshipRepository.GetByUsersIds(userId, friendId);
            relationship.RelationshipStatus = RelationshipStatus.DeletedFriendship;
            relationshipRepository.Update(relationship);
            return relationship.Id;

        }

        public int Login(string email, string password)
        {
            var user = repository.GetUserByEmail(email);
            if (user.Password == password) {
                return user.Id;
            }
            return 0;
        }

        public int Register(string nickname, string email, string password)
        {
            User user = new User() { Nickname = nickname, Email = email, Password = password };
            repository.Insert(userMapper.ToEntity(user));
            return user.Id;
        }


    }
}