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
                CreateReferrer(dbContext, roleManager, userManager);
            }

            if (!dbContext.PaymentModes.Any())
            {
                AddPaymentModes(dbContext);
            }

            if(!dbContext.Locations.Any())
            {
                AddLocations(dbContext);
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

        private static void CreateReferrer(
            ApplicationDbContext dbContext,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
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
            dbContext.SaveChanges();
        }

        private static void AddPaymentModes(ApplicationDbContext dbContext)
        {

            var cc = new PaymentMode()
            {
                Mode = "CC",
                Description = "Credit Card"
            };

            var dc = new PaymentMode()
            {
                Mode = "DC",
                Description = "Debit Card"
            };
            var nb = new PaymentMode()
            {
                Mode = "NB",
                Description = "Net Banking"
            };

            var cash = new PaymentMode()
            {
                Mode = "CS",
                Description = "Cash"
            };

            var draft = new PaymentMode()
            {
                Mode = "DT",
                Description = "Draft"
            };

            var cheque = new PaymentMode()
            {
                Mode = "CQ",
                Description = "Cheque"
            };

            dbContext.PaymentModes.AddRange(cc, dc, nb, cash, draft, cheque);
            dbContext.SaveChanges();

        }

        private static void AddLocations(ApplicationDbContext dbContext)
        {
            var blore = new Location() {
                Name = "Bangalore",
                Initials='B',
                Address= "Bangalore",
                PhoneNumber="N.A."
            };

            var chni = new Location() {
                Name= "Chennai",
                Initials='C',
                Address= "Chennai",
                PhoneNumber = "N.A."
            };

            var dhli = new Location() {
                Name= "Delhi",
                Initials='D',
                Address= "Delhi",
                PhoneNumber = "N.A."
            };

            var ggon = new Location()
            {
                Name = "Gurgaon",
                Initials = 'G',
                Address = "Gurgaon",
                PhoneNumber = "N.A."
            };

            var kolkta = new Location()
            {
                Name = "Kolkata",
                Initials = 'K',
                Address = "Kolkata",
                PhoneNumber = "N.A."
            };
            
            var mbai = new Location()
            {
                Name = "Mumbai",
                Initials = 'M',
                Address = "Mumbai",
                PhoneNumber = "N.A."
            };

            dbContext.Locations.AddRange(blore, chni, dhli, ggon, kolkta, mbai);
            dbContext.SaveChanges();
        }

        #endregion

        #region Utility Methods

        #endregion
    }
}