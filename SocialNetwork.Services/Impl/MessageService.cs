using SocialNetwork.Entities;
using SocialNetwork.Mappers.Abstract;
using SocialNetwork.Mappers.Impl;
using SocialNetwork.Models;
using SocialNetwork.UOW.Impl;
using SocialNetwork.Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using SocialNetwork.Services.Abstract;

namespace SocialNetwork.Services.Impl
{
    public class MessageService : IMessageService
    {
        private readonly IGenericMapper<MessageEntity, Message> messageMapper;
        private readonly IGenericMapper<UserEntity, User> userMapper;
        private readonly IMessageRepository messageRepository;
        private readonly IUserRepository userRepository;
        private readonly IRelationshipService relationshipService;

        public MessageService()
        {
            messageMapper = new MessageMapper();
            userMapper = new UserMapper();
            messageRepository = new UnitOfWork().Messages;
            userRepository = new UnitOfWork().Users;
            relationshipService = new RelationshipService();

        }

        public List<Message> GetChatWithFriend(int userId, int friendId)
        {
            if(relationshipService.AreFriends(userId, friendId)) {
                return messageRepository.GetChatMessages(userId, friendId).Select(m => messageMapper.ToModel(m)).ToList();
            }
            return null;
        }

        public int SendMessageToFriend(string text, int senderId, int receiverId)
        {
            if (relationshipService.AreFriends(senderId, receiverId))
            {
                Message message = new Message();
                message.Text = text;
                message.Sender = userMapper.ToModel(userRepository.GetById(senderId));
                message.Receiver = userMapper.ToModel(userRepository.GetById(receiverId));
                message.Time = System.DateTime.Now;
                MessageEntity messageEntity = messageMapper.ToEntity(message);
                messageRepository.Insert(messageEntity);
                return messageEntity.Id;
            }
            return 0;
        }
    }
}
