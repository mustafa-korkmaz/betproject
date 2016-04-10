
namespace Business.WebApi.Parsers
{
	/// <summary>
    ///  calss which includes parsing operations for rivalo.com
    /// </summary>
    public class RivaloParser:IBetSite
    {
	    public string GetCurrentEvents()
	    {
		
	        return "";
	    }
    }
}


/*
   var parser = new HtmlParser();
            //Just get the DOM representation
            WebRequest request = WebRequest.Create(txt_rivaloUrl.Text);
            var webResponse = request.GetResponse();

            // Get the stream associated with the response.
            Stream receiveStream = webResponse.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            string webResponseData = readStream.ReadToEnd();

            webResponse.Close();
            readStream.Close();
            //Serialize it back to the console

            var document = parser.Parse(webResponseData);
	 */
