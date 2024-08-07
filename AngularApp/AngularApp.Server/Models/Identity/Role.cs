using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace AngularApp.Server.Models.Identity
{
    public class Role : IdentityRole<int>
    {
        public IEnumerable<UserRole> userRoles { get; set; }
    }
}
