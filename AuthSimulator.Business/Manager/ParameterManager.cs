using AuthSimulator.Business.CustomExceptions;
using AuthSimulator.Business.Data;
using AuthSimulator.Business.Dto;
using AuthSimulator.Business.Dto.Enums;
using AuthSimulator.Business.Dto.Parameter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AuthSimulator.Business.Manager
{
    /// <summary>
    /// Parameters Storage Manager
    /// </summary>
    public class ParameterManager : BaseManager
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Database Context</param>
        public ParameterManager(DB context) : base(context)
        {
        }

        /// <summary>
        /// Return list of parameters
        /// </summary>
        /// <returns>List of parameters</returns>
        public async Task<List<ParameterOutput>> GetList()
        {
            var result = await Context
                .Parameters.Include(p => p.ParameterType)
                .OrderBy(p => p.Id)
                .ToListAsync();

            List<ParameterOutput> list = new();

            foreach (var param in result)
            {
                string value = "";
                switch ((ParameterTypes)param.ParameterTypeId)
                {
                    case ParameterTypes.Number:
                    case ParameterTypes.Text:
                        value = param.Value;
                        break;
                    case ParameterTypes.Boolean:
                        value = param.Value == "1" ? true.ToString() : false.ToString();
                        break;
                    case ParameterTypes.List:
                        {
                            var options = JsonSerializer.Deserialize<List<EnumData>>(param.Options) ?? new List<EnumData>();
                            value = options.FirstOrDefault(o => o.Id.ToString() == param.Value)?.Text ?? "-";
                        }
                        break;
                }
                list.Add(new ParameterOutput
                {
                    Id = param.Id,
                    Name = param.Name,
                    ParameterType = param.ParameterType.Name,
                    Value = value
                });
            }

            return list;
        }

        /// <summary>
        /// Get parameter detail
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Parameter detail</returns>
        public async Task<ParameterDetailOutput> GetDetail(int id)
        {
            return await Context
                .Parameters
                .Where(p => p.Id == id)
                .Select(s => new ParameterDetailOutput()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Value = s.Value,
                    Description = s.Description,
                    ParameterTypeId = s.ParameterTypeId,
                    Options = s.Options
                }).FirstOrDefaultAsync() ?? throw new ItemNotFoundException(ItemNotFoundTypes.Parameter, id);
        }

        /// <summary>
        /// Update a parameter
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="value">Value</param>
        /// <returns>Result</returns>
        public async Task<bool> UpdateParameter(int id, string value)
        {
            var current = await Context
                .Parameters
                .FirstOrDefaultAsync(p => p.Id == id) ?? throw new ItemNotFoundException(ItemNotFoundTypes.Parameter, id);
            current.Value = value;
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
