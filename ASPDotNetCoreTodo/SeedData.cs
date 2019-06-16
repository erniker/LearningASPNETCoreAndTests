using System;
using System.Linq;
using System.Threading.Tasks;
using ASPDotNetCoreTodo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ASPDotNetCoreTodo
{
    public static class SeedData
    {
        
        //El método InitializeAsync() utiliza un IServiceProvider (la colección de
        //servicios que se configura en el método Startup.ConfigureServices() ) para
        //obtener el RoleManager y el UserManager de ASP.NET Core Identity.
        public static async Task InitializeAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            await EnsureRolesAsync(roleManager);

            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            await EnsureTestAdminAsync(userManager);
        }

        //Este método verifica si existe un rol de Administrador en la base de datos.Si no, crea uno.
        private static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var alreadyExists = await roleManager.RoleExistsAsync(Constants.AdministratorRole);

            if (alreadyExists) return;

            await roleManager.CreateAsync(new IdentityRole(Constants.AdministratorRole));
        }

        //Si no hay un usuario con el nombre de usuario admin@todo.local en la base de datos, este método
        //creará uno y le asignará una contraseña temporal.
        private static async Task EnsureTestAdminAsync(UserManager<ApplicationUser> userManager)
        {
            var testAdmin = await userManager.Users
                .Where(x => x.UserName == "admin@todo.local")
                .SingleOrDefaultAsync();

            if (testAdmin != null) return;

            testAdmin = new ApplicationUser{UserName = "admin@todo.local", Email = "admin@todo.local"};
            await userManager.CreateAsync(testAdmin, "NotSecure123!!");
            await userManager.AddToRoleAsync(testAdmin, Constants.AdministratorRole);
        }
    }
}