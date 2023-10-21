using AuthSimulator.Business.CustomExceptions;
using AuthSimulator.Business.Data;
using AuthSimulator.Business.Dto.Auth;
using AuthSimulator.Business.Dto.Enums;
using AuthSimulator.Business.Utility;
using Microsoft.EntityFrameworkCore;

namespace AuthSimulator.Business.Manager
{
    /// <summary>
    /// Auth Storage Manager
    /// </summary>
    public class AuthManager : BaseManager
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Database Context</param>
        public AuthManager(DB context) : base(context)
        {

        }

        /// <summary>
        /// Generate Token
        /// </summary>
        /// <param name="request">Token request</param>
        /// <returns></returns>
        public async Task<TokenOutput> GenerateToken(TokenInput request)
        {
            var response = int.Parse(await GetParameterValue(ParameterEnum.TokenResponse));
            switch ((TokenResponses)response)
            {
                case TokenResponses.InvalidRequest:
                    throw new AuthException(AuthExceptionReasons.InvalidRequest);
                case TokenResponses.InvalidClient:
                    throw new AuthException(AuthExceptionReasons.InvalidClient);
                case TokenResponses.InvalidGrant:
                    throw new AuthException(AuthExceptionReasons.InvalidGrant);
                case TokenResponses.UnauthorizedClient:
                    throw new AuthException(AuthExceptionReasons.UnauthorizedClient);
                case TokenResponses.UnsupportedGrantType:
                    throw new AuthException(AuthExceptionReasons.UnsupportedGrantType);
                case TokenResponses.InvalidScope:
                    throw new AuthException(AuthExceptionReasons.InvalidScope);
                case TokenResponses.None:
                default:
                    break;
            }



            var auth = await Context
                .Auths
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.Code == request.Code && a.Valid) ?? throw new Exception();


            auth.RefreshToken = Utility.Utility.GenerateCode(Constants.CodeSize);
            auth.AccessToken = Utility.Utility.GenerateCode(Constants.CodeSize);

            await Context.SaveChangesAsync();

            return new TokenOutput()
            {
                TokenType = Constants.TokenType,
                AccessToken = auth.AccessToken,
                RefreshToken = auth.RefreshToken,
                ExpiresIn = (auth.Expires - DateTime.Now).TotalSeconds.ToString()
            };
        }

        /// <summary>
        /// Do Authorization by email and password
        /// </summary>
        /// <returns>Auth Id</returns>
        public async Task<string> DoAuth(string email, string password)
        {
            var user = await Context
                .Users
                .FirstOrDefaultAsync(u => u.Active && u.Email == email && u.Password == password) ?? throw new AuthException(AuthExceptionReasons.UnauthorizedClient);

            //remove current auth
            var current = await Context.Auths.FirstOrDefaultAsync(a => a.User == user);
            if (current != null)
            {
                Context.Auths.Remove(current);
            }

            var expires = await GetParameterValue(ParameterEnum.Expires);

            //save current auth
            var auth = Context.Auths.Add(new()
            {
                UserId = user.Id,
                Valid = true,
                Code = Utility.Utility.GenerateCode(Constants.CodeSize),
                Expires = DateTime.Now.AddSeconds(int.Parse(expires))
            }); ;

            await Context.SaveChangesAsync();

            return auth.Entity.Code;
        }

        /// <summary>
        /// Do Authorization by user Id
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns></returns>
        public async Task<string> DoAuth(int userId)
        {
            var user = await Context
                .Users
                .FirstOrDefaultAsync(u => u.Id == userId) ?? throw new AuthException(AuthExceptionReasons.UnauthorizedClient);

            var expires = int.Parse(await GetParameterValue(ParameterEnum.Expires));

            var auth = Context.Auths.Add(new()
            {
                UserId = user.Id,
                Valid = true,
                Code = Utility.Utility.GenerateCode(Constants.CodeSize),
                Expires = DateTime.Now.AddSeconds(expires)
            });

            await Context.SaveChangesAsync();

            return auth.Entity.Code;
        }

        /// <summary>
        /// Check if a Client is valid
        /// </summary>
        /// <param name="ClientId">Client Id</param>
        /// <param name="clientSecret">Client Secret</param>
        /// <returns>Result</returns>
        public async Task<bool> ValidateClient(string ClientId, string clientSecret)
        {
            var parameter = await this.GetParameterValue(ParameterEnum.ClientActive);
            if (parameter != "1")
                return true;

            return await Context
                .Client
                .AnyAsync(a =>
                a.ClientId == ClientId
                && (a.ClientSecret == null || a.ClientSecret == clientSecret)
                && a.Active
            );
        }

        /// <summary>
        /// Check if a Client is valid
        /// </summary>
        /// <param name="ClientId">Client Id</param>
        /// <returns>Result</returns>
        public async Task<bool> ValidateAuthCall(string ClientId)
        {

            //check for auto response active
            var response = int.Parse(await GetParameterValue(ParameterEnum.AuthResponse));
            switch ((AuthResponses)response)
            {
                case AuthResponses.InvalidRequest:
                    throw new AuthException(AuthExceptionReasons.InvalidRequest);
                case AuthResponses.UnauthorizedClient:
                    throw new AuthException(AuthExceptionReasons.UnauthorizedClient);
                case AuthResponses.UnsupportedResponceType:
                    throw new AuthException(AuthExceptionReasons.UnsupportedResponseType);
                case AuthResponses.InvalidScope:
                    throw new AuthException(AuthExceptionReasons.InvalidScope);
                case AuthResponses.None:
                default:
                    break;
            }

            //check if valid credential
            var clientActive = await GetParameterValue(ParameterEnum.ClientActive);
            if (clientActive != "1")
                return true;

            return await Context.Client
                .AnyAsync(a => a.ClientId == ClientId && a.Active
            );
        }

        /// <summary>
        /// Return User Info
        /// </summary>
        /// <param name="authorization"></param>
        /// <returns>User Data</returns>
        public async Task<string> GetUserInfo(string authorization)
        {
            //get token
            var code = authorization.Split(" ").Last();

            var user = await Context.Auths
                .Include(a => a.User)
                .Where(a => a.Valid && a.AccessToken == code)
                .Select(a => a.User)
                .FirstOrDefaultAsync() ?? throw new AuthException(AuthExceptionReasons.AccessDenied);

            return user.JsonData;
        }


    }
}
