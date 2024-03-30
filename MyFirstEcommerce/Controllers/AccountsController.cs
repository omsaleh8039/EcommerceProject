﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyFirstEcommerce.Models;
using MyFirstEcommerce.ViewModel;

namespace MyFirstEcommerce.Controllers
{
    public class AccountsController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountsController(SignInManager<ApplicationUser> signInManager,UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if(ModelState.IsValid)
            {
                var result=await _signInManager.PasswordSignInAsync(model.Email,model.Password,true,true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                   return RedirectToAction(nameof(Login));
                }
            }
            return View(model);
        }
        public IActionResult Registers()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registers(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {   Id = model.Id,
                    UserName= model.Email,
                    Email=model.Email,                   
                    Name=model.Name
                };
                user.Id = Guid.NewGuid().ToString();
                var result = await _userManager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                   await _signInManager.SignInAsync(user, true);  
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(model);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
