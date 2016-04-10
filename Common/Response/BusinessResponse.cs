namespace Common.Response
{
    /// <summary>
    /// response class for business classes
    /// </summary>
    public class BusinessResponse<T> : BaseResponse
    {
        // to do: here goes other properties for BusinessResponse object

        public T ResponseData { get; set; }
    }
}