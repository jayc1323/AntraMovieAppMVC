using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models.Response
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsLocked { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
