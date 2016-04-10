using System;
using System.IO;
using System.Net;
using System.Text;
using Common.Enumerations;
using Common.Response;
using Common.Constants;

namespace Business.WebApi.Client
{
    public class WebClient
    {
        public static WebClient Instance { get; } = new WebClient();

        private WebClient()
        {
            //initialize
        }
        /// <summary>
        /// base get html content method via httpClient
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <returns></returns>
        public WebClientResponse<string> GetResponseText(Uri requestUrl)
        {
            var clientResponse = new WebClientResponse<string>();

            WebRequest request = WebRequest.Create(requestUrl);
            var webResponse = request.GetResponse();

            var statusCode = ((HttpWebResponse)webResponse).StatusCode;

            if (statusCode != HttpStatusCode.OK)
            {
                clientResponse.ResponseCode = ResponseCode.Fail;
                return clientResponse; // log response
            }

            clientResponse.ResponseCode = ResponseCode.Success;

            // Get the stream associated with the response.
            Stream receiveStream = webResponse.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            if (receiveStream != null)
            {
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                clientResponse.ResponseData = readStream.ReadToEnd();
                readStream.Close();
            }

            webResponse.Close();

            return clientResponse;
        }

        /// <summary>
        /// base get html content method via httpClient
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <returns></returns>
        public WebClientResponse<string> GetResponseText(string requestUrl)
        {
            var clientResponse = new WebClientResponse<string>();

            WebRequest request = WebRequest.Create(requestUrl);
            var webResponse = request.GetResponse();

            var statusCode = ((HttpWebResponse)webResponse).StatusCode;

            if (statusCode != HttpStatusCode.OK)
            {
                clientResponse.ResponseCode = ResponseCode.Fail;
                return clientResponse; // log response
            }

            clientResponse.ResponseCode = ResponseCode.Success;

            // Get the stream associated with the response.
            Stream receiveStream = webResponse.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            if (receiveStream != null)
            {
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                clientResponse.ResponseData = readStream.ReadToEnd();
                readStream.Close();
            }

            webResponse.Close();

            return clientResponse;
        }

        public WebRequest CreateRequest(Uri requestUrl)
        {
            return WebRequest.Create(requestUrl);
        }

        public WebRequest CreateRequest(Uri requestUrl, RequestOptions requestOptions)
        {

            var request = WebRequest.Create(requestUrl);

            switch (requestOptions.ContentType)
            {
                case ContentType.FormUrlencoded:
                    request.ContentType = ContentTpye.FormUrlencoded;
                    break;
            }

            switch (requestOptions.MethodType)
            {
                case WebMethodType.Get:
                    request.Method = WebMethod.Get;
                    break;
                case WebMethodType.Post:
                    request.Method = WebMethod.Post;
                    break;
                case WebMethodType.Put:
                    request.Method = WebMethod.Put;
                    break;
            }

            return request;
        }

        public WebRequest CreateRequest(string requestUrl)
        {
            return WebRequest.Create(requestUrl);
        }

        public WebRequest CreateRequest(string requestUrl, RequestOptions requestOptions)
        {
            var request = WebRequest.Create(requestUrl);

            switch (requestOptions.ContentType)
            {
                case ContentType.FormUrlencoded:
                    request.ContentType = ContentTpye.FormUrlencoded;
                    break;
            }

            switch (requestOptions.MethodType)
            {
                case WebMethodType.Get:
                    request.Method = WebMethod.Get;
                    break;
                case WebMethodType.Post:
                    request.Method = WebMethod.Post;
                    break;
                case WebMethodType.Put:
                    request.Method = WebMethod.Put;
                    break;
            }

            return request;
        }

        // todo: we will use below code after successful trail version
        //public async Task<WebClientResponse<string>> PostAsync<TReq>(Uri url, TReq requestObject)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        var reqParams = RequestParser.GetRequestParameters(requestObject);

        //        var content = new FormUrlEncodedContent(reqParams);

        //        // Get Token
        //        using (var response = await client.PostAsync(url, content))
        //        {
        //            switch (response.StatusCode)
        //            {
        //                case System.Net.HttpStatusCode.Unauthorized:
        //                    break;
        //                case System.Net.HttpStatusCode.OK:
        //                    break;

        //            }

        //            var data = await response.Content.ReadAsStringAsync();

        //            return new WebClientResponse<string> { HttpStatusCode = response.StatusCode, ResponseData = data };
        //        }
        //    }

        //}

        //public async Task<WebClientResponse<string>> GetAsync<TReq>(Uri url, TReq requestObject)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        //var reqParams = RequestParser.GetRequestParameters(requestObject);

        //        // Get Token
        //        using (var response = await client.GetAsync(url))
        //        {
        //            switch (response.StatusCode)
        //            {
        //                case HttpStatusCode.Unauthorized:
        //                    break;
        //                case HttpStatusCode.OK:
        //                    break;

        //            }

        //            var data = await response.Content.ReadAsStringAsync();

        //            return new WebClientResponse<string> { HttpStatusCode = response.StatusCode, ResponseData = data };
        //        }
        //    }

        //}
    }

    public class RequestOptions
    {
        public ContentType ContentType { get; set; }
        public WebMethodType MethodType { get; set; }
    }

}


