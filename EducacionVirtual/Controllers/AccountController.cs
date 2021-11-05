using EducacionVitual.Helpers;
using EducacionVitual.ViewsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducacionVirtual.Controllers
{
    public class AccountController : Controller
    {
        
        private readonly IUserHelper _userHelper;
        private readonly IImageHelper _imageHelper;
        private readonly ICombosHelper _combosHelper;

        public AccountController(IUserHelper userHelper,
                                 IImageHelper imageHelper,
                                 ICombosHelper combosHelper)
        {
            _userHelper = userHelper;
            _imageHelper = imageHelper;
            _combosHelper = combosHelper;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            AddUserViewModel model = new AddUserViewModel
            {
                UserTypes = _combosHelper.GetComboRoles()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                string path = string.Empty;

                if (model.PictureFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(model.PictureFile, "Users");
                }

                ApplicationUser user = await _userHelper.AddUserAsync(model, path);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "This email is already used.");
                    model.UserTypes = _combosHelper.GetComboRoles();
                    return View(model);
                }

                LoginViewModel loginViewModel = new LoginViewModel
                {
                    Password = model.Password,
                    RememberMe = false,
                    Email = model.Username
                };

                Microsoft.AspNetCore.Identity.SignInResult result2 = await _userHelper.LoginAsync(loginViewModel);

                if (result2.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
            }

            model.UserTypes = _combosHelper.GetComboRoles();
            return View(model);

        }
 
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Failed to login.");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _userHelper.LogoutAsync();
            return RedirectToAction("Login", "Account");
        }
    }


    //[HttpPost]
    //[AllowAnonymous]
    //public async Task<IActionResult> Login(LoginViewModel user)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

    //        if (result.Succeeded)
    //        {
    //            return RedirectToAction("Index", "Home");
    //        }

    //        ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

    //    }
    //    return View(user);
    //}

    //public async Task<IActionResult> Logout()
    //{
    //    await _signInManager.SignOutAsync();

    //    return RedirectToAction("Login");
    //}

    //[HttpPost]
    //public async Task<IActionResult> Register(RegisterViewModel model)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        var user = new ApplicationUser
    //        {
    //            UserName = model.Email,
    //            Email = model.Email,
    //        };

    //       // var result = await _userManager.CreateAsync(user, model.Password);
    //        var result = await _userHelper.AddUserAsync(user, model.Password);

    //        if (result.Succeeded)
    //        {
    //            //await _userHelper.SignInAsync(user, isPersistent: false);

    //            return RedirectToAction("Login", "Account");
    //        }

    //        foreach (var error in result.Errors)
    //        {
    //            ModelState.AddModelError("", error.Description);
    //        }

    //        ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

    //    }
    //    return View(model);
    //}


}
