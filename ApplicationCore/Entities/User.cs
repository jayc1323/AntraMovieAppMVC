using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(128)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(256)]
        public string Email { get; set; }
        public string? HashedPassword { get; set; }
        public bool IsLocked { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Salt { get; set; }
        public string? PhoneNumber { get; set; }
        public string? TwoFactorEnabled { get; set; }
        public string? LockoutEndDate { get; set; }
        public int AccessFailedCount { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
