using Microsoft.AspNetCore.Identity;

namespace WebApp.Dummy
{
    public class DummyRoles
    {
        string[] roles;

        public DummyRoles()
        {
            roles = new string[]
            {
                "Student",
                "Prof"
            };
        }

        public async void FillDummy(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            var roleExists = await roleManager.RoleExistsAsync("Student");
        }
    }
}
