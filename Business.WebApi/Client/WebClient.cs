using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Common.Enumerations;
using Common.Response;
using Common.Constants;
using DTO;

namespace Business.WebApi.Client
{
    public class WebClient
    {
        public static WebClient Instance { get; } = new WebClient();

        public int BetSiteId { get; set; }

        private WebClient()
        {
            //initialize
        }

        /// <summary>
        /// base get html content method via httpClient
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <returns></returns>
        public WebClientResponse<string> GetResponseText(string requestUrl)
        {
            var clientResponse = new WebClientResponse<string>();

            var webResponse = GetResponseFromRequest(requestUrl);

            clientResponse.HttpStatusCode = ((HttpWebResponse)webResponse).StatusCode;

            if (clientResponse.HttpStatusCode != HttpStatusCode.OK)
            {
                clientResponse.ResponseCode = ResponseCode.Fail;

                LogRequestAndResponse(requestUrl, "Bot web exception!", (int)clientResponse.HttpStatusCode);

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

            LogRequestAndResponse(requestUrl, clientResponse.ResponseData, (int)clientResponse.HttpStatusCode);

            return clientResponse;
        }

        /// <summary>
        ///  get html content method via httpClient
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="requestOptions"></param>
        /// <returns></returns>
        public WebClientResponse<string> GetResponseText(string requestUrl, RequestOptions requestOptions)
        {
            var clientResponse = new WebClientResponse<string>();

            var webResponse = GetResponseFromRequest(requestUrl, requestOptions);

            clientResponse.HttpStatusCode = ((HttpWebResponse)webResponse).StatusCode;

            if (clientResponse.HttpStatusCode != HttpStatusCode.OK)
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

        private WebResponse GetResponseFromRequest(string requestUrl)
        {
            var req = WebRequest.Create(requestUrl);

            try
            {
                return req.GetResponse();
            }
            catch (WebException ex)
            {
                var response = ex.Response as HttpWebResponse;
                if (response != null)
                {
                    Console.WriteLine("Bot got an error with HTTP Status Code: " + (int)response.StatusCode);
                }
                return response;
            }
        }

        private WebResponse GetResponseFromRequest(string requestUrl, RequestOptions requestOptions)
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

            return request.GetResponse();
        }

        public async Task<WebClientResponse<string>> PostAsync(Uri url, Dictionary<string, string> requestDic)
        {
            string responseData = string.Empty;
            HttpStatusCode statusCode = HttpStatusCode.OK;

            using (HttpClient client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(requestDic);

                try
                {
                    using (var response = await client.PostAsync(url, content))
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            responseData = await response.Content.ReadAsStringAsync();
                            statusCode = response.StatusCode;
                        }

                    }
                }
                catch (WebException ex)
                {
                    var response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        Console.WriteLine("Bot got an error with HTTP Status Code: " + (int)response.StatusCode);
                        statusCode = response.StatusCode;
                        responseData = ex.Message;
                    }
                }
                // log req & resp
                LogRequestAndResponse(url.AbsoluteUri, responseData, (int)statusCode);
            }

            return new WebClientResponse<string> { HttpStatusCode = statusCode, ResponseData = responseData };
        }

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

        private void LogRequestAndResponse(string requestUrl, string responseData, int statusCode)
        {
            var statics = new BotStatics
            {
                BetSiteId = BetSiteId,
                CreatedAt = DateTime.Now,
                RequestUrl = requestUrl,
                ResponseText = responseData,
                ResponseCode = statusCode
            };

            var logger = Logger.Instance;
            logger.Log(statics);
        }
    }

    public class RequestOptions
    {
        public ContentType ContentType { get; set; }
        public WebMethodType MethodType { get; set; }
        public Dictionary<string, string> Paramaters { get; set; }
    }

}


