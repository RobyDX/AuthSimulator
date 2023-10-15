using AuthSimulator.Business.CustomExceptions;
using AuthSimulator.Business.Data;
using AuthSimulator.Business.Dto.Client;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSimulator.Business.Manager
{
    /// <summary>
    /// Client Manager
    /// </summary>
    public class ClientManager : BaseManager
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Database Context</param>
        public ClientManager(DB context) : base(context)
        {
        }

        


        /// <summary>
        /// Create new Client
        /// </summary>
        /// <param name="input">App Client Information</param>
        /// <returns>App Client Key</returns>
        public async Task<int> CreateClient(ClientInput input)
        {
            var result = Context.Client.Add(new Client
            {
                ClientId = input.ClientId,
                ClientSecret = input.ClientSecret,
                Active = true,
                Name = input.Name
            });

            await Context.SaveChangesAsync();

            return result.Entity.Id;
        }

        /// <summary>
        /// Edit a Client
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="input">Client Information</param>
        /// <returns>Client Id</returns>
        public async Task<int> EditCredential(int id, ClientInput input)
        {
            var current = await Context
                .Client
                .FirstOrDefaultAsync(a => a.Id == id) ?? throw new ItemNotFoundException(ItemNotFoundTypes.Client, id);

            current.Name = input.Name;
            current.ClientSecret = input.ClientSecret;
            current.ClientId = input.ClientId;

            await Context.SaveChangesAsync();

            return current.Id;
        }

        /// <summary>
        /// Delete an Existing Client
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Result</returns>
        public async Task<bool> DeleteCredential(int id)
        {
            var current = await Context
                .Client
                .FirstOrDefaultAsync(a => a.Id == id) ?? throw new ItemNotFoundException(ItemNotFoundTypes.Client, id);

            Context.Client.Remove(current);

            await Context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Change activation state
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Result</returns>
        public async Task<bool> ChangeActivationCredential(int id)
        {
            var current = await Context
                .Client
                .FirstOrDefaultAsync(a => a.Id == id) ?? throw new ItemNotFoundException(ItemNotFoundTypes.Client, id);

            current.Active = !current.Active;

            await Context.SaveChangesAsync();
            return current.Active;
        }

        /// <summary>
        /// Get Client List
        /// </summary>
        /// <returns>Client List</returns>
        public async Task<List<ClientOutput>> GetList()
        {
            return await Context
                .Client
                .Select(a => new ClientOutput()
                {
                    Name = a.Name,
                    ClientId = a.ClientId,
                    ClientSecret = a.ClientSecret,
                    Id = a.Id,
                    Active = a.Active
                })
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        /// <summary>
        /// Get Client Detail
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Client detail</returns>
        public async Task<ClientOutput> GetDetail(int id)
        {
            var current = await Context
                .Client
                .Where(a => a.Id == id)
                .Select(a => new ClientOutput()
                {
                    Id = a.Id,
                    ClientId = a.ClientId,
                    ClientSecret = a.ClientSecret,
                    Name = a.Name,
                    Active = a.Active
                }).FirstOrDefaultAsync() ?? throw new ItemNotFoundException(ItemNotFoundTypes.Client, id);

            return current;

        }
    }
}
