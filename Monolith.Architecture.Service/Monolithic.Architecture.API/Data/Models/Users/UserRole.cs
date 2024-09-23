using Microsoft.AspNetCore.Identity;
using Monolithic.Architecture.API.Contracts.Common;

namespace Monolithic.Architecture.API.Data.Models.Users
{
    public class UserRole : IdentityUserRole<string>, IAuditTrail
    {
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public string LastUserUpdate { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}