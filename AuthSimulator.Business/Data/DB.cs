using AuthSimulator.Business.Dto;
using AuthSimulator.Business.Dto.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AuthSimulator.Business.Data
{
    /// <summary>
    /// App DB Context
    /// </summary>
    public class DB : DbContext
    {
        /// <summary>
        /// Users
        /// </summary>
        public DbSet<User> Users { get; set; } = null!;

        /// <summary>
        /// Client
        /// </summary>
        public DbSet<Client> Client { get; set; } = null!;

        /// <summary>
        /// Auths
        /// </summary>
        public DbSet<Auth> Auths { get; set; } = null!;

        /// <summary>
        /// Parameters
        /// </summary>
        public DbSet<Parameter> Parameters { get; set; } = null!;

        /// <summary>
        /// Parameter Types
        /// </summary>
        public DbSet<ParameterType> ParameterTypes { get; set; } = null!;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options">Options</param>
        public DB(DbContextOptions<DB> options) : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// On model creating
        /// </summary>
        /// <param name="modelBuilder">Model Builder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //unique constraint on email
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<Client>().HasIndex(a => a.ClientId).IsUnique();
            modelBuilder.Entity<Client>().HasIndex(a => a.Name).IsUnique();

            var testUser = new
            {
                email = "johndoe@test.com",
                family_name = "Doe",
                given_name = "John",
                id = "12345",
                link = "http://test.com/profile/12345",
                name = "John Doe",
                verified_email = "true"
            };

            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                Email = "admin@admin.it",
                Password = "0000",
                JsonData = JsonSerializer.Serialize(testUser),
                Active = true,
            });

            modelBuilder.Entity<ParameterType>().HasData(
                new ParameterType() { Id = (int)Dto.Enums.ParameterTypes.Number, Name = "Number" },
                new ParameterType() { Id = (int)Dto.Enums.ParameterTypes.Text, Name = "Text" },
                new ParameterType() { Id = (int)Dto.Enums.ParameterTypes.Boolean, Name = "Boolean" },
                new ParameterType() { Id = (int)Dto.Enums.ParameterTypes.List, Name = "List" }
                );

            modelBuilder.Entity<Parameter>().HasData(
                new Parameter()
                {
                    Id = (int)ParameterEnum.ClientActive,
                    Name = "Client Active",
                    Description = "Turn on to set client validation active. If setting is off then no client validation will be performed",
                    ParameterTypeId = (int)Dto.Enums.ParameterTypes.Boolean,
                    Options = "[]",
                    Value = "0"
                },
                new Parameter()
                {
                    Id = (int)ParameterEnum.Expires,
                    Name = "Token Expires Time",
                    Description = "Set Token Expire Timeout. Set to 0 for infinitive token time",
                    ParameterTypeId = (int)Dto.Enums.ParameterTypes.Number,
                    Options = "[]",
                    Value = "3600"
                },
                new Parameter()
                {
                    Id = (int)ParameterEnum.AuthResponse,
                    Name = "Auth Default Response",
                    Description = "Set how will be override standard auth endpoint response",
                    ParameterTypeId = (int)Dto.Enums.ParameterTypes.List,
                    Options = JsonSerializer.Serialize(new List<EnumData>()
                    {
                         new EnumData(){ Id=(int)AuthResponses.None, Text="No Override"},
                         new EnumData(){ Id=(int)AuthResponses.InvalidRequest, Text="invalid_request"},
                         new EnumData(){ Id=(int)AuthResponses.UnauthorizedClient, Text="unauthorized_client"},
                         new EnumData(){ Id=(int)AuthResponses.UnsupportedResponceType, Text="unsupported_responce_type"},
                         new EnumData(){ Id=(int)AuthResponses.InvalidScope, Text="invalid_scope"}
                    }),
                    Value = "1"
                },
                new Parameter()
                {
                    Id = (int)ParameterEnum.TokenResponse,
                    Name = "Token Default Response",
                    Description = "Set how will be override standard token endpoint response",
                    ParameterTypeId = (int)Dto.Enums.ParameterTypes.List,
                    Options = JsonSerializer.Serialize(new List<EnumData>()
                    {
                         new EnumData(){ Id=(int)TokenResponses.None, Text="No Override"},
                         new EnumData(){ Id=(int)TokenResponses.InvalidRequest, Text="invalid_request"},
                         new EnumData(){ Id=(int)TokenResponses.InvalidClient, Text="invalid_client"},
                         new EnumData(){ Id=(int)TokenResponses.InvalidGrant, Text="invalid_grant"},
                         new EnumData(){ Id=(int)TokenResponses.UnauthorizedClient, Text="unauthorized_client"},
                         new EnumData(){ Id=(int)TokenResponses.UnsupportedGrantType, Text="unsupported_grant_type"},
                         new EnumData(){ Id=(int)TokenResponses.InvalidScope, Text="invalid_scope"},
                    }),
                    Value = "1"
                });
        }
    }
}
