using System;

namespace GamblingGame.Domain.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public int Points { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
