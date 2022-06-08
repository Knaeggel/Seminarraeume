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
                var user = await userManager.FindByNameAsync("User" + i + "@proOne.de");

                if (user == null)
                {
                    var newUser = new IdentityUser()
                    {
                        UserName = "User" + i + "@proOne.de",
                        Email = "User" + i + "@proOne.de"
                    };

                    await userManager.CreateAsync(newUser, "User" + i + "@proOne.de");

                    user = await userManager.FindByNameAsync("User" + i + "@proOne.de");
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

            for (int i = 1; i < 11; i++)
            {
                var user = await userManager.FindByNameAsync("Prof" + i + "@proOne.de");

                if (user == null)
                {
                    var newUser = new IdentityUser()
                    {
                        UserName = "Prof" + i + "@proOne.de",
                        Email = "Prof" + i + "@proOne.de"
                    };

                    await userManager.CreateAsync(newUser, "Prof" + i + "@proOne.de");

                    user = await userManager.FindByNameAsync("Prof" + i + "@proOne.de");
                }

                try
                {
                    await userManager.AddToRoleAsync(user, "Prof");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }


        }
    }
}
