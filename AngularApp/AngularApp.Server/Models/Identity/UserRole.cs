using AngularApp.Server.Enum;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace AngularApp.Server.Models.Identity
{
    public class UserRole : IdentityUserRole<int>
    {
        public Role Role { get; set; }
        public User User { get; set; }
    }
}
