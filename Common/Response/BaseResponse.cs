using Common.Enumerations;

namespace Common.Response
{
    /// <summary>
    /// abstract response class
    /// </summary>
    public abstract class BaseResponse
    {
        public ResponseCode ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }

    public static class ResponseMessage
    {
        public const string IntegrationNotFound = "Integration not found";
        public const string ExportTypeNotFound = "Export type not found";
    }
}