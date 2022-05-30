//using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Context;
using SocialNetwork.Repository.Abstract;
using SocialNetwork.Repository.Impl;
using SocialNetwork.UOW.Abstract;
using SocialNetwork.UOW.Impl;

namespace SocialNetwork.DI
{

    public static class DependencyInjection
    {
        /*public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IMessageRepository, MessageRepository>();
            services.AddSingleton<IRelationshipRepository, RelationshipRepository>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            // services.AddDbContext<SocialNetworkContext>(opt => opt
            //     .UseSqlServer("Server=DESKTOP-UUBJ14C\\SQLEXPRESS; Database=SocialNetworkDb;Trusted_Connection=True;")); // TODO
            return services;
        }*/
    }
}