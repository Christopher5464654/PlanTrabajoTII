namespace PlanTrabajoTII.web.Data
{
    using Microsoft.AspNetCore.Identity;
    using PlanTrabajoTII.web.Data.Entities;
    using PlanTrabajoTII.web.Helpers;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class Seeder
    {
        private readonly DataContext dataContext;
        private readonly IUserHelper userHelper;

        public Seeder(DataContext dataContext, IUserHelper userHelper)
        {
            this.dataContext = dataContext;
            this.userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await dataContext.Database.EnsureCreatedAsync();
            await this.userHelper.CheckRoleAsync("Admin");
            await this.userHelper.CheckRoleAsync("Coordinator");
            await this.userHelper.CheckRoleAsync("Teacher");
            await this.userHelper.CheckRoleAsync("Student");
            if(!this.dataContext.Admins.Any())
            {
                var user = await CheckUserAsync("Doe", "John", "john.doe@gmail.com", "8888888888", "123456", "Admin");
                await CheckAdminAsync(user);
            }
            await CheckUserAsync("Doe", "John", "john.doe@gmail.com", "8888888888", "123456", "Admin");
            await CheckUserAsync("Doe", "Jane", "jane.doe@gmail.com", "54654654", "123456", "Teacher");
            await CheckUserAsync("Doe", "Gus", "gus.doe@gmail.com", "6465454", "123456", "Student");
            await CheckUserAsync("Doe", "Charly", "charly.doe@gmail.com", "77777777", "123456", "Coordinator");
        }

        private async Task<User> CheckUserAsync(string lastName, string firstName, string mail, string phone, string password, string rol)
        {
            var user = await userHelper.GetUserByEmailAsync(mail);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = mail,
                    UserName = mail,
                    PhoneNumber = phone,
                };
                var result = await userHelper.AddUserAsync(user, password);
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("No se puede crear el usuario en la base de datos");
                }
                await userHelper.AddUserToRoleAsync(user, rol);
            }
            return user;
        }

        private async Task CheckAdminAsync(User user)
        {
            this.dataContext.Admins.Add(new Admin { User = user });
            await this.dataContext.SaveChangesAsync();
        }
   }
}