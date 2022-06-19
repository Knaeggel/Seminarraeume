using Microsoft.AspNetCore.Identity;

namespace WebApp.Dummy
{
    public class DummyRoles
    {
        string[] roles;

        public DummyRoles(RoleManager<IdentityRole> roleManager)
        {
            roles = new string[]
            {
                "Student",
                "Prof",
                "Timetable",
                "Tutor"
            };

            FillDummy(roleManager).Wait();
        }

        public async Task FillDummy(RoleManager<IdentityRole> roleManager)
        {

            foreach (var roleName in roles)
            {
                var roleExists = await roleManager.RoleExistsAsync(roleName);

                if (roleExists == false)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }

            }
        }
    }
}
