namespace Common.Response
{
    /// <summary>
    /// response class for http client classes
    /// </summary>
    public class WebClientResponse<T> : BaseResponse
    {
        public T ResponseData { get; set; }
        public System.Net.HttpStatusCode HttpStatusCode { get; set; }
    }
}