using System;

namespace SocialNetwork.Models
{

    public class Message
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime Time { get; set; }

        public User Sender { get; set; }

        public User Receiver { get; set; }

    }
}