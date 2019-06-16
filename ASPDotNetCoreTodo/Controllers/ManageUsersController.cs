using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ASPDotNetCoreTodo.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPDotNetCoreTodo.Controllers
{
    //La configuración de la propiedad Roles en el atributo
    //[Authorize] garantizará que el usuario tenga que iniciar sesión y se le
    //asigne el rol de Administrador para poder ver la página.
    [Authorize(Roles = Constants.AdministratorRole)]
    public class ManageUsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ManageUsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var admins = (await _userManager
                .GetUsersInRoleAsync(Constants.AdministratorRole))
                .ToArray();

            var everyone = await _userManager.Users
                .ToArrayAsync();

            var model = new ManageUsersViewModel
            {
                Administrators = admins,
                Everyone = everyone
            };
            return View(model);
        }
    }
}