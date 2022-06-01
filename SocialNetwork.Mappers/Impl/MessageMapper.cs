using SocialNetwork.Entities;
using SocialNetwork.Mappers.Abstract;
using SocialNetwork.Models;

namespace SocialNetwork.Mappers.Impl
{
    public class MessageMapper : IGenericMapper<MessageEntity, Message>
    {
        private readonly IGenericMapper<UserEntity, User> userMapper;

        public MessageMapper(IGenericMapper<UserEntity, User> userMapper)
        {
            this.userMapper = userMapper;
        }

        public Message ToModel(MessageEntity entity)
        {
            return new Message()
            {
                Id = entity.Id,
                Text = entity.Text,
                Time = entity.Time,
                Sender = userMapper.ToModel(entity.Sender),
                Receiver = userMapper.ToModel(entity.Receiver),
            };
        }

        public MessageEntity ToEntity(Message model)
        {
            return new MessageEntity()
            {
                Id = model.Id,
                Text = model.Text,
                Time = model.Time,
                SenderId = model.Sender.Id,
                ReceiverId = model.Receiver.Id,
            };
        }

    }
}