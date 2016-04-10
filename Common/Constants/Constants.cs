namespace Common.Constants
{
    public class ExportTypeText
    {
        public const string Category = "category";
        public const string Product = "product";
    }

    public class SettingKey
    {
        public const string ImagePath = "imagePath";
        public const string FullPath = "{fullPath}";
        public const string Extension = "{extension}";
    }

    public static class App
    {
        public const string IntegrationKeyHeaderName = "IntegrationKey";
        public const string IntegrationKeyValue = "MustafaTaylanAlican";
        public static string IntegrationKeyHash = Helper.IntegrationKey.Instance.GetHashValue(IntegrationKeyValue);
    }

    public static class ErrorMessage
    {
        public const string IntegrationKeyError = "Application Integration key error.";
        public const string ApplicationExceptionMessage = "Something went wrong, please try again later.";
    }

    public static class ResponseMessage
    {
        public const string IntegrationNotFound = "Integration not found";
        public const string ExportTypeNotFound = "Export type not found";
    }

    public static class ContentTpye
    {
        public const string FormUrlencoded = "application/x-www-form-urlencoded";
    }
    public static class WebMethod
    {
        public const string Get = "Get";
        public const string Post = "Post";
        public const string Put = "Put";
    }
}