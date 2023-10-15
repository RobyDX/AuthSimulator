using AuthSimulator.Business.CustomExceptions;
using AuthSimulator.Business.Dto.Auth;

namespace AuthSimulator.Middleware
{
    /// <summary>
    /// Exception Middleware
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="next">Request delegate</param>
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invoke Method
        /// </summary>
        /// <param name="context">Context</param>
        /// <returns>Task</returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ItemNotFoundException ex)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsJsonAsync(new ErrorMessage()
                {
                    Error = ex.Message
                });
            }
            catch (AuthException ex)
            {
                switch (ex.Reason)
                {
                    case AuthExceptionReasons.InvalidRequest:
                        await SetStatus(context, 400, "invalid_request");
                        break;
                    case AuthExceptionReasons.InvalidScope:
                        await SetStatus(context, 400, "invalid_scope");
                        break;
                    case AuthExceptionReasons.InvalidClient:
                        await SetStatus(context, 401, "invalid_client");
                        break;
                    case AuthExceptionReasons.RequiresValidation:
                        await SetStatus(context, 401, "requires_validation");
                        break;
                    case AuthExceptionReasons.UnauthorizedClient:
                        await SetStatus(context, 403, "unauthorized_client");
                        break;
                    case AuthExceptionReasons.AccessDenied:
                        await SetStatus(context, 403, "access_denied");
                        break;
                    case AuthExceptionReasons.InvalidGrant:
                        await SetStatus(context, 403, "invalid_grant");
                        break;
                    case AuthExceptionReasons.EndpointDisabled:
                        await SetStatus(context, 404, "endpoint_disabled");
                        break;
                    case AuthExceptionReasons.MethodNotAllowed:
                        await SetStatus(context, 405, "method_not_allowed");
                        break;
                    case AuthExceptionReasons.TooManyRequests:
                        await SetStatus(context, 429, "too_many_requests");
                        break;
                    case AuthExceptionReasons.UnsupportedResponseType:
                        await SetStatus(context, 501, "unsupported_response_type");
                        break;
                    case AuthExceptionReasons.UnsupportedGrantType:
                        await SetStatus(context, 501, "unsupported_grant_type");
                        break;
                    case AuthExceptionReasons.TemporarilyUnavailable:
                        await SetStatus(context, 503, "temporarily_unavailable");
                        break;
                    default:
                        break;
                }


            }
        }

        private static async Task SetStatus(HttpContext context, int code, string error, string description = "...")
        {
            context.Response.StatusCode = code;
            await context.Response.WriteAsJsonAsync(new ErrorMessage()
            {
                Error = error,
                ErrorDescription = description
            });
        }
    }
}
