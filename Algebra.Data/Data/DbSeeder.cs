﻿using Algebra.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Algebra.Data
{
    public static class DbSeeder
    {
        #region Public Methods
        public static void Seed(
            ApplicationDbContext dbContext,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager
            )
        {
            // Create default Users (if there are none)
            if (!dbContext.Users.Any())
            {
                CreateUsers(dbContext, roleManager, userManager)
                    .GetAwaiter()
                    .GetResult();
            }

            if (!dbContext.Referrers.Any())
            {
                CreateReferrer(dbContext)
                    .GetAwaiter()
                    .GetResult();
            }

            if (!dbContext.PaymentModes.Any())
            {
                AddPaymentModes(dbContext)
                    .GetAwaiter()
                    .GetResult();
            }

            if(!dbContext.Locations.Any())
            {
                AddLocations(dbContext)
                    .GetAwaiter()
                    .GetResult();
            }

            if (!dbContext.Categories.Any())
            {
                AddMembershipTypes(dbContext)
                    .GetAwaiter()
                    .GetResult();
            }

        }

        
        #endregion

        #region Seed Methods
        private static async Task CreateUsers(
            ApplicationDbContext dbContext,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            // local variables
            DateTime createdDate = DateTime.Now; 
            DateTime lastModifiedDate = DateTime.Now;

            //Create Roles (if they doesn't exist yet)
            CreateRoles(roleManager).GetAwaiter().GetResult();

            // Create the "Admin" ApplicationUser account
            var user_Admin = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "Admin",
                DisplayName = "Administrator",
                Email = "admin@algebra.com",
                Location = Enums.Location.Gurgaon.ToString(),
                CreatedDate = createdDate,
                LastModifiedDate = lastModifiedDate
            };
            // Insert "Admin" into the Database and assign the "Administrator" and "Registered" roles to him.
            if (await userManager.FindByIdAsync(user_Admin.Id) == null)
            {
                await userManager.CreateAsync(user_Admin, "P@ssw0rd");
                await userManager.AddToRoleAsync(user_Admin, Enums.Role.RegisteredUser.ToString());
                await userManager.AddToRoleAsync(user_Admin, Enums.Role.Administrator.ToString());
                user_Admin.EmailConfirmed = true;
                user_Admin.LockoutEnabled = false;
            }

            // Create some more user accounts
            var gurgaonAdmin = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "GGAdmin",
                DisplayName = "Gurgaon Admin",
                Email = "GurgaonAdmin@algebra.com",
                Location = Enums.Location.Gurgaon.ToString(),
                CreatedDate = createdDate,
                LastModifiedDate = lastModifiedDate
            };

            if (await userManager.FindByIdAsync(gurgaonAdmin.Id) == null)
            {
                await userManager.CreateAsync(gurgaonAdmin, "P@ssw0rd");
                await userManager.AddToRoleAsync(gurgaonAdmin, Enums.Role.RegisteredUser.ToString());
                await userManager.AddToRoleAsync(gurgaonAdmin, Enums.Role.GurgaonAdmin.ToString());
                gurgaonAdmin.EmailConfirmed = true;
                gurgaonAdmin.LockoutEnabled = false;
            }

            var bangaloreAdmin = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "BlrAdmin",
                DisplayName = "Bangalore Admin",
                Email = "BangaloreAdmin@algebra.com",
                Location = Enums.Location.Bangalore.ToString(),
                CreatedDate = createdDate,
                LastModifiedDate = lastModifiedDate
            };

            if (await userManager.FindByIdAsync(bangaloreAdmin.Id) == null)
            {
                await userManager.CreateAsync(bangaloreAdmin, "P@ssw0rd");
                await userManager.AddToRoleAsync(bangaloreAdmin, Enums.Role.RegisteredUser.ToString());
                await userManager.AddToRoleAsync(bangaloreAdmin, Enums.Role.BangaloreAdmin.ToString());
                bangaloreAdmin.EmailConfirmed = true;
                bangaloreAdmin.LockoutEnabled = false;
            }

            var user = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "User",
                DisplayName = "Registered User",
                Email = "User@algebra.com",
                Location = Enums.Location.Bangalore.ToString(),
                CreatedDate = createdDate,
                LastModifiedDate = lastModifiedDate
            };

            if (await userManager.FindByIdAsync(user.Id) == null)
            {
                await userManager.CreateAsync(user, "P@ssw0rd");
                await userManager.AddToRoleAsync(user, Enums.Role.RegisteredUser.ToString());
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
            }

            await dbContext.SaveChangesAsync();
        }

        private static async Task CreateRoles(RoleManager<IdentityRole> roleManager)
        {

            if (!await roleManager.RoleExistsAsync(Enums.Role.Administrator.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(Enums.Role.Administrator.ToString()));
            }

            if (!await roleManager.RoleExistsAsync(Enums.Role.RegisteredUser.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(Enums.Role.RegisteredUser.ToString()));
            }

            if (!await roleManager.RoleExistsAsync(Enums.Role.GurgaonAdmin.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(Enums.Role.GurgaonAdmin.ToString()));
            }

            if (!await roleManager.RoleExistsAsync(Enums.Role.BangaloreAdmin.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(Enums.Role.BangaloreAdmin.ToString()));
            }

        }

        private static async Task CreateReferrer(ApplicationDbContext dbContext)
        {
            var refShoma = new Referrer()
            {
                Name = "Shoma Chaudhury",
                Code = "SC"
            };

            var refSheuli = new Referrer()
            {
                Name = "Sheuli Sethi",
                Code = "SS"
            };
            var refPayal = new Referrer()
            {
                Name = "Payal Puri",
                Code = "PP"
            };
            var refAngali = new Referrer()
            {
                Name = "Angali Gulati",
                Code = "AG"
            };

            dbContext.Referrers.AddRange(refShoma, refSheuli, refAngali, refPayal);
            await dbContext.SaveChangesAsync();
        }

        private static async Task AddPaymentModes(ApplicationDbContext dbContext)
        {

            var cc = new Mode()
            {
                Text = "Credit Card",
                Description = "Credit Card"
            };
            var dc = new Mode()
            {
                Text = "Debit Card",
                Description = "Debit Card"
            };
            var nb = new Mode()
            {
                Text = "Net Banking",
                Description = "Net Banking"
            };
            var cash = new Mode()
            {
                Text = "Cash",
                Description = "Cash"
            };
            var draft = new Mode()
            {
                Text = "Draft",
                Description = "Draft"
            };
            var cheque = new Mode()
            {
                Text = "Cheque",
                Description = "Cheque"
            };
            var mixMode = new Mode()
            {
                Text = "Mix Mode",
                Description = "Mix Mode (more then one mode of payment)"
            };

            dbContext.PaymentModes.AddRange(cc, dc, nb, cash, draft, cheque, mixMode);
            await dbContext.SaveChangesAsync();

        }

        private static async Task AddLocations(ApplicationDbContext dbContext)
        {
            var blore = new Location() {
                Name = "Bangalore",
                Code = "ALB",
                Address= "Bangalore",
                PhoneNumber="N.A.",
                Digits= "2000"
            };

            var dhli = new Location() {
                Name= "Delhi",
                Code = "ALD",
                Address= "Delhi",
                PhoneNumber = "N.A.",
                Digits= "4000"
            };

            var ggon = new Location()
            {
                Name = "Gurgaon",
                Code = "ALG",
                Address = "Gurgaon",
                PhoneNumber = "N.A.",
                Digits = "0000"
            };

            dbContext.Locations.AddRange(blore, dhli, ggon);
            await dbContext.SaveChangesAsync();
        }

        private static async Task AddMembershipTypes(ApplicationDbContext dbContext)
        {
            var induvidual = new Category() {
                Type = "Individual",
                Description= "Individual",
                Created = "Admin"
            };

            var couple = new Category()
            {
                Type = "Couple",
                Description= "Couple",
                Created="Admin"
            };

            var coupleWithDependent = new Category()
            {
                Type = "Couple With Dependent",
                Description = "Couple With Dependent",
                Created = "Admin"
            };

            var individualWithDependent = new Category() {
                Type = "Individual With Dependent",
                Description = "Individual With Dependent",
                Created="Admin"
            };

            var complimentary = new Category()
            {
                Type = "Complimentary",
                Description= "Complimentary",
                Created = "Admin"
            };

            dbContext.Categories.AddRange(induvidual, 
                couple, 
                coupleWithDependent, 
                individualWithDependent, 
                complimentary);

            await dbContext.SaveChangesAsync();
        }

        #endregion

        #region Utility Methods

        #endregion
    }
}
