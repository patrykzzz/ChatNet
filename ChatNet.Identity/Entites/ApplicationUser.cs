using Microsoft.AspNetCore.Identity;
using System;

namespace ChatNet.Identity.Entites
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
