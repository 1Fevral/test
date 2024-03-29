﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

//TODO:  (получение/создание/проверка роли/добавление роли/аутентификация/авторизация/изменение/удаление user и др.)
namespace Store.DataAccess.Repositories.EFRepository
{
    public class UserRepository : IUserRepository
    {
        private ApplicationContext _db;
        private UserManager<Users> _userManager;
        private RoleManager<Roles> _roleManager;
        private SignInManager<Users> _signInManager;

        public UserRepository(ApplicationContext db,
                              UserManager<Users> userManager,
                              RoleManager<Roles> roleManager,
                              SignInManager<Users> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async void Create(Users user)
        {
            await _userManager.CreateAsync(user);
            await _db.SaveChangesAsync();
        }
        public async void Update(Users user)
        {
            await _userManager.UpdateAsync(user);
            await _db.SaveChangesAsync();
        }

        public async void Remove(Users user)
        {
            await _userManager.DeleteAsync(user);
            await _db.SaveChangesAsync();
        }

        public async Task<Users> FindById(int id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public async Task<Users> FindByEmail(string email)
        {
            return await _userManager.FindByIdAsync(email);
        }

        public async Task<Users> FindByName(string name)
        {
            return await _userManager.FindByIdAsync(name);
        }

        public async Task<IEnumerable<string>> GetUserRoles(Users user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async void CreateRole(Roles role)
        {
            await _roleManager.CreateAsync(role);
            await _db.SaveChangesAsync();
        }

        public async void DeleteRole(Roles role)
        {
            await _roleManager.DeleteAsync(role);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> IsInRole(Users user, string role)
        {
            return await _userManager.IsInRoleAsync(user, role);
        }

        public async void AddToRole(Users user, string role)
        {
            await _userManager.AddToRoleAsync(user,role);
            await _db.SaveChangesAsync();
        }
        public async void RemoveFromRole(Users user, string role)
        {
            await _userManager.RemoveFromRoleAsync(user, role);
            await _db.SaveChangesAsync();
        }

        public async void SignIn(Users user, bool isPersistent)
        {
            await _signInManager.SignInAsync(user, isPersistent);
        }
    }
}
