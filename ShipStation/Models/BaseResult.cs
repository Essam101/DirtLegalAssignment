namespace DirtLegalAssignment.ShipStation.Models
{
    public class BaseResult
    {

        public BaseResult Error(CustomHttpStatusCode statusCode)
        {
            return new BaseResult(statusCode);
        }
        public BaseResult(CustomHttpStatusCode statusCode, object? model = null)
        {
            StatusCode = statusCode;
            Model = model;
        }

        public CustomHttpStatusCode StatusCode { get; set; }
        public object? Model { get; set; }
        public string? Message
        {
            get
            {
                return GetResponseMessage(StatusCode);
            }
        }

        private string GetResponseMessage(CustomHttpStatusCode statusCode)
        {
            switch (statusCode)
            {
                case CustomHttpStatusCode.OK:
                    return "OK - The request was successful.";
                case CustomHttpStatusCode.Created:
                    return "Created - The request was successful and a resource was created.";
                case CustomHttpStatusCode.NoContent:
                    return "No Content - The request was successful but there is no representation to return.";
                case CustomHttpStatusCode.BadRequest:
                    return "Bad Request - The request could not be understood or was missing required parameters.";
                case CustomHttpStatusCode.Unauthorized:
                    return "Unauthorized - Authentication failed or user does not have permissions for the requested operation.";
                case CustomHttpStatusCode.Forbidden:
                    return "Forbidden - Access denied.";
                case CustomHttpStatusCode.NotFound:
                    return "Not Found - Resource was not found.";
                case CustomHttpStatusCode.MethodNotAllowed:
                    return "Method Not Allowed - Requested method is not supported for the specified resource.";
                case CustomHttpStatusCode.TooManyRequests:
                    return "Too Many Requests - Exceeded ShipStation API limits. Please wait until X-Rate-Limit-Reset seconds have elapsed.";
                case CustomHttpStatusCode.InternalServerError:
                    return "Internal Server Error - ShipStation has encountered an error.";
                case CustomHttpStatusCode.DirtLegalServerError:
                    return "Internal Server Error - Dirt legal has encountered an error.";
                default:
                    return "Unhandled status code.";
            }
        }



    }
    public enum CustomHttpStatusCode
    {
        OK = 200,
        Created = 201,
        NoContent = 204,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,
        TooManyRequests = 429,
        InternalServerError = 500,
        DirtLegalServerError = 5000
    }
}
