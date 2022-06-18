using Microsoft.AspNetCore.Identity;
using WebApp.Models;

namespace WebApp.Manager
{
    public class RoleManagerP
    {

        public static async Task<UserRoles> getRole(UserManager<IdentityUser> userManager, IdentityUser user)
        {
            var role = UserRoles.empty;
            if (await userManager.IsInRoleAsync(user, "Prof"))
            {
                role = UserRoles.Prof;
            }
            if (await userManager.IsInRoleAsync(user, "Tutor"))
            {
                role = UserRoles.Tutor;
            }
            if (await userManager.IsInRoleAsync(user, "Timetable"))
            {
                role = UserRoles.TimeTable;
            }
            if (await userManager.IsInRoleAsync(user, "Student"))
            {
                role = UserRoles.Student;
            }

            return role;
        }
    }
}
