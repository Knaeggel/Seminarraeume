using Microsoft.AspNetCore.Identity;
using WebApp.Models;

namespace WebApp.Manager
{
    public class RoleManagerP
    {

        public static async Task<UserRoles> getRole(UserManager<IdentityUser> userManager, IdentityUser user)
        {
            var role = UserRoles.empty;
            var userRoles = await userManager.GetRolesAsync(user);

            if (userRoles.Count > 0)
            {
                switch(userRoles.ElementAt(0))
                {
                    case "Timetable":
                        role = UserRoles.TimeTable;
                        break;

                    case "Prof":
                        role = UserRoles.Prof;
                        break;

                    case "Tutor":
                        role = UserRoles.Tutor;
                        break;

                    case "Student":
                        role = UserRoles.Student;
                        break;
                }
            }

            return role;
        }
    }
}
