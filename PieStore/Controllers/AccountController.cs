using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PieStore.Models;
using PieStore.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PieStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userInManager;

        public AccountController(SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userInManager)
        {
            _signInManager = signInManager;
            _userInManager = userInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if(!ModelState.IsValid)
                return View(loginViewModel);

            var user = await
            _userInManager.FindByNameAsync(loginViewModel.UserName);

            if(user != null)
            {
                var result = await
                 _signInManager.PasswordSignInAsync(user,loginViewModel.Password,false,false);

                 if(result.Succeeded)
                 return RedirectToAction("Index","Home");
            }

            ModelState.AddModelError("","User name/Password not found");
            return View(loginViewModel);

        }


        public IActionResult Register()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel loginViewModel)
        {
                if(ModelState.IsValid)
                {
                    var user = new IdentityUser {UserName = loginViewModel.UserName};
                    var result =await
                    _userInManager.CreateAsync(user,loginViewModel.Password);
                    if(result.Succeeded)
                    {
                       return RedirectToAction("Index","Home");
                    }   
                }
                return View(loginViewModel);
        }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("index","home");
    }
    }
}

    
    
