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
        private readonly IMessageRepository repository;
        private readonly IRelationshipService relationshipService;

        public MessageService()
        {
            messageMapper = new MessageMapper();
            repository = new UnitOfWork().Messages;
            relationshipService = new RelationshipService();

        }

        public List<Message> GetChatWithFriend(int userId, int friendId)
        {
            if(relationshipService.AreFriends(userId, friendId)) {
                return repository.GetChatMessages(userId, friendId).Select(m => messageMapper.ToModel(m)).ToList();
            }
            return null;
        }

        public int SendMessageToFriend(Message message)
        {
            if (relationshipService.AreFriends(message.Sender.Id, message.Receiver.Id))
            {
                message.Time = System.DateTime.Now;
                repository.Insert(messageMapper.ToEntity(message));
                return message.Id;
            }
            return 0;
        }
    }
}
