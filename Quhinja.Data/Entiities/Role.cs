using Microsoft.AspNetCore.Identity;

namespace Quhinja.Data.Entities
{
    public class Role : IdentityRole<int>
    {
        public string RoleDescription { get; set; }

    }
}
