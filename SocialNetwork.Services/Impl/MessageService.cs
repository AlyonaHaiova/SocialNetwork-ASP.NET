using SocialNetwork.Entities;
using SocialNetwork.Models;
using SocialNetwork.UOW.Abstract;
using SocialNetwork.Services.Abstract;
using SocialNetwork.Mappers.Abstract;
using SocialNetwork.Repository.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Services.Impl
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork uow;
        private readonly IGenericMapper<MessageEntity, Message> messageMapper;
        private readonly IGenericMapper<UserEntity, User> userMapper;
        private readonly IMessageRepository messageRepository;
        private readonly IUserRepository userRepository;
        private readonly IRelationshipService relationshipService;


        public MessageService(IUnitOfWork uow, IGenericMapper<MessageEntity, Message> messageMapper, 
                              IGenericMapper<UserEntity, User> userMapper, IRelationshipService relationshipService)
        {
            this.uow = uow;
            this.messageMapper = messageMapper;
            this.userMapper = userMapper;
            this.relationshipService = relationshipService;
            messageRepository = uow.Messages();
            userRepository = uow.Users();
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
