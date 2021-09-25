using System;

namespace GamblingGame.Domain.Models
{
    public class Account
    {
        public Account()
        {
            CreationDate = DateTime.Now;
            LastModified = CreationDate;
        }

        public Guid Id { get; set; }
        public int Points { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModified { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
