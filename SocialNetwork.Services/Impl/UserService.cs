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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;
        private readonly IGenericMapper<UserEntity, User> userMapper;
        private readonly IUserRepository repository;
        private readonly IRelationshipService relationshipService;
        private readonly IRelationshipRepository relationshipRepository;

        public UserService(IUnitOfWork uow, IGenericMapper<UserEntity, User> userMapper, IRelationshipService relationshipService)
        {
            this.uow = uow;
            this.userMapper = userMapper;       
            this.relationshipService = relationshipService;
            repository = uow.Users();
            relationshipRepository = uow.Relationships();

        }

        public User GetById(int id)
        {
            return userMapper.ToModel(repository.GetById(id));
        }

        public List<User> GetAll()
        {
            return repository.GetAll().Select(u => userMapper.ToModel(u)).ToList();
        }

        public List<User> GetFriends(int userId)
        {
            return repository.GetRelatedUsers(userId)
                               .Where(u => relationshipService.AreFriends(u.Id, userId))
                               .Select(x => userMapper.ToModel(x))
                               .ToList();
        }

        public List<User> GetNotFriends(int userId, int limit)
        {
            return repository.GetAll()
                .Where(u => !relationshipService.HasRelationship(u.Id, userId))
                .Select(x => userMapper.ToModel(x))
                .Take(limit)
                .ToList();
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
            relationshipRepository.Remove(relationship);
            return 0;
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
            UserEntity userEntity = userMapper.ToEntity(new User() { Nickname = nickname, Email = email, Password = password });
            repository.Insert(userEntity);
            return userEntity.Id;
        }

    }
}