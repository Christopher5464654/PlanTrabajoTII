namespace PlanTrabajoTII.web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PlanTrabajoTII.web.Helpers;
    using PlanTrabajoTII.web.Models;
    using System.Linq;
    using System.Threading.Tasks;

    public class AccountController : Controller
    {
        private readonly IUserHelper userHelper;

        public AccountController(IUserHelper userHelper)
        {
            this.userHelper = userHelper;
        }

        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Index", "Home");
            }
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var result = await this.userHelper.LoginAsync(loginViewModel.UserName, loginViewModel.Password, loginViewModel.RememberMe);

            if (result.Succeeded)
            {
                if(this.Request.Query.Keys.Contains("ReturnUrl"))
                {
                    return this.Redirect(this.Request.Query["ReturnUrl"].First());
                }
                return this.RedirectToAction("Index", "Home");
            }
            this.ModelState.AddModelError(string.Empty, "Falló tu Login");
            return this.View(loginViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await this.userHelper.LogoutAsync();
            return this.RedirectToAction("Index", "Home");
        }
    }
}