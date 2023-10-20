using AuthSimulator.Business.Data;
using AuthSimulator.Business.Dto.User;
using AuthSimulator.Business.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthSimulator.Business.CustomExceptions;

namespace AuthSimulator.Business.Manager
{
    /// <summary>
    /// Users Storage Manager
    /// </summary>
    public class UserManager : BaseManager
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Database Context</param>
        public UserManager(DB context) : base(context)
        {
        }


        /// <summary>
        /// Generate all users list
        /// </summary>
        /// <returns>List of users</returns>
        public async Task<List<EnumData>> UserList()
        {
            return await Context
                .Users
                .Select(u => new EnumData()
                {
                    Id = u.Id,
                    Text = u.Email
                })
                .OrderBy(u => u.Text)
                .ToListAsync();
        }

        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="input">User Information</param>
        /// <returns>Primary Key</returns>
        public async Task<int> CreateUser(UserInfoInput input)
        {
            var user = Context.Users.Add(new User()
            {
                Email = input.Email,
                JsonData = input.JsonData,
                Password = input.Password,
                Active = true
            });

            await Context.SaveChangesAsync();

            return user.Entity.Id;
        }

        /// <summary>
        /// Edit User
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="input">User Information</param>
        /// <returns>Primary Key</returns>
        public async Task<int> EditUser(int id, UserInfoInput input)
        {
            var user = await Context
                .Users
                .FirstOrDefaultAsync(u => u.Id == id) ?? throw new ItemNotFoundException(ItemNotFoundTypes.User, id);

            user.Email = input.Email;
            user.Password = input.Password;
            user.JsonData = input.JsonData;
            user.Active = true;
            await Context.SaveChangesAsync();

            return user.Id;
        }

        /// <summary>
        /// Edit User
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Result</returns>
        public async Task<bool> DeleteUser(int id)
        {
            //remove all range associated
            Context.Auths.RemoveRange(Context.Auths.Where(a => a.UserId == id));

            var user = await Context.Users.FirstOrDefaultAsync(u => u.Id == id) ?? throw new Exception();
            Context.Remove(user);

            await Context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Change Activation
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Result</returns>
        public async Task<bool> ChangeActivation(int id)
        {
            var user = await Context
                .Users
                .FirstOrDefaultAsync(u => u.Id == id) ?? throw new ItemNotFoundException(ItemNotFoundTypes.User, id);
            user.Active = !user.Active;
            await Context.SaveChangesAsync();
            return user.Active;
        }

        /// <summary>
        /// Search for users
        /// </summary>
        /// <param name="text">Search text</param>
        /// <returns>Result</returns>
        public async Task<List<UserInfoOutput>> Search(string text)
        {
            return await Context
                .Users
                .Where(u => u.Email.Contains(text))
                .Select(u => new UserInfoOutput()
                {
                    Email = u.Email,
                    Id = u.Id,
                    JsonData = u.JsonData,
                    Password = u.Password,
                    Active = u.Active
                }).ToListAsync();
        }

        /// <summary>
        /// Get user detail
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>User Detail</returns>
        public async Task<UserInfoOutput> GetDetail(int id)
        {
            var user = await Context
                .Users
                .Where(u => u.Id == id)
                .Select(u => new UserInfoOutput()
                {
                    Email = u.Email,
                    Id = u.Id,
                    JsonData = u.JsonData,
                    Password = u.Password,
                    Active = u.Active
                })
                .FirstOrDefaultAsync() ?? throw new ItemNotFoundException(ItemNotFoundTypes.User, id);

            return user;
        }
    }
}
