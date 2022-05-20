using Microsoft.AspNetCore.Identity;

namespace WebApp.Dummy
{
    public class DummyUsers
    {
        public async void FillDummy(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            for (int i = 1; i < 51; i++)
            {
                var user = await userManager.FindByNameAsync("User" + i + "@proOne.de");

                if (user == null)
                {
                    var newUser = new IdentityUser()
                    {
                        UserName = "User" + i,
                        Email = "User" + i + "@proOne.de"
                    };

                    await userManager.CreateAsync(newUser, "Test" + i);

                    user = await userManager.FindByNameAsync("User" + i + "@proOne.de");
                }

                await userManager.AddToRoleAsync(user, "Student");
            }
        }
    }
}
