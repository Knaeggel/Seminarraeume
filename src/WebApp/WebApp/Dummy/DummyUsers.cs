using Microsoft.AspNetCore.Identity;

namespace WebApp.Dummy
{
    public class DummyUsers
    {
        public DummyUsers(UserManager<IdentityUser> userManager)
        {
            FillDummy(userManager).Wait();
        }

        public async Task FillDummy(UserManager<IdentityUser> userManager)
        { 

            for (int i = 1; i < 51; i++)
            {
                var user = await userManager.FindByNameAsync("User" + i);

                if (user == null)
                {
                    var newUser = new IdentityUser()
                    {
                        UserName = "User" + i,
                        Email = "User" + i + "@proOne.de"
                    };

                    await userManager.CreateAsync(newUser, "Test" + i + ".");

                    user = await userManager.FindByNameAsync("User" + i);
                }

                try
                {
                    await userManager.AddToRoleAsync(user, "Student");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
