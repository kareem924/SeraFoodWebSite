﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SeraFood.Models;

namespace SeraFood.Controllers
{
    public class RolesController : Controller
    {
        //
        // GET: /Roles/
        public ActionResult Index()
        {
            var context = new SeraFoodCtx();

            var allRoles = context.Roles.Select(role => new RoleViewModel
            {
                RoleName = role.Name
            });
            return View(allRoles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RoleViewModel newRole)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new SeraFoodCtx()));

            if (ModelState.IsValid)
            {
                if (!roleManager.RoleExists(newRole.RoleName))
                {
                    IdentityResult result = roleManager.Create(new IdentityRole(newRole.RoleName));

                    if (result.Succeeded)
                    {
                        //ViewBag.Message = "Role created successfully! ";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "This Role alread exists!");
                }
            }
            return View(newRole);
        }

        private IdentityResult AddUserToRole(string userId, string roleName)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new SeraFoodCtx()));
            IdentityResult result;
            if (!userManager.IsInRole(userId, roleName))
            {
                result = userManager.AddToRole(userId, roleName);
            }
            else
            {
                string message = string.Format("User is already existed in {0} Role", roleName);
                result = new IdentityResult(message);
            }
            return result;
        }
	}
}