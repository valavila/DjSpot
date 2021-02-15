using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DjSpot.Models
{
    public static class IdentityHelper
    {
        public const string Customer = "Customer";
        public const string Dj = "Dj";
        public const string Admin = "Admin";
        public static async Task CreateRoles(IServiceProvider provider, params string[] roles) // 'params allows me to pass a comma sperated list instead of an array
        {
            RoleManager<IdentityRole> roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();

            // create role if it does not exist
            foreach (string role in roles)
            {
                bool doesRoleExist = await roleManager.RoleExistsAsync(role);
                if (!doesRoleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
