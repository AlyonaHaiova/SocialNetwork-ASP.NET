using SocialNetwork.Context;
using SocialNetwork.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Network.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SocialNetworkContext())
            {
                db.Database.EnsureCreated();
                db.Users.Add(new SocialNetwork.Entities.UserEntity() { Id = 1, Nickname = "Alyona", Email = "a@gmail.com" });
                db.SaveChanges();
            }

        }
    }
}
