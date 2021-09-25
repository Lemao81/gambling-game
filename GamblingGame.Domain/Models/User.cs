using System;

namespace GamblingGame.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
    }
}
