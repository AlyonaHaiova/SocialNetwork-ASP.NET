using SocialNetwork.Context;
using SocialNetwork.UOW.Abstract;
using System;
using SocialNetwork.Repository.Abstract;

namespace SocialNetwork.UOW.Impl
{

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SocialNetworkContext db;

        private readonly IUserRepository userRepository;
        private readonly IMessageRepository messageRepository;
        private readonly IRelationshipRepository relationshipRepository;

        public UnitOfWork(SocialNetworkContext db, IUserRepository userRepository, IMessageRepository messageRepository, 
                          IRelationshipRepository relationshipRepository)
        {
            this.db = db;
            this.userRepository = userRepository;
            this.messageRepository = messageRepository;
            this.relationshipRepository = relationshipRepository;
        }

        public IUserRepository Users()
        {
            return userRepository;
        }

        public IRelationshipRepository Relationships()
        {
            return relationshipRepository;
        }

        public IMessageRepository Messages()
        {
            return messageRepository;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}