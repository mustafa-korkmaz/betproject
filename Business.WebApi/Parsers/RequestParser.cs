using System.Collections.Generic;
using System.Reflection;

namespace Business.WebApi.Parsers
{
    /// <summary>
    /// parses the given object (request object) as dic <string , string>
    /// </summary>
    public static class RequestParser
    {
        public static Dictionary<string, string> GetRequestParameters<T>(T requestObject)
        {
            Dictionary<string, string> reqDic = new Dictionary<string, string>();
            foreach (PropertyInfo pi in requestObject.GetType().GetProperties())
            {
                string value = pi.GetValue(requestObject, null).ToString();
                reqDic.Add(pi.Name, GetValueWithValidatedChars(value));
            }

            return reqDic;
        }

        /// <summary>
        /// web api do not accept chars=> requestPathInvalidCharacters="<,>,*,%,:,&"
        /// this method replaces invalid chars with the valid ones
        /// </summary>
        /// <param name="apiParameter">parameter we pass to web api</param>
        /// <returns></returns>
        private static string GetValueWithValidatedChars(string apiParameter)
        {
            string validatedText = apiParameter.Replace('<', '(').Replace('>', ')').Replace('*', '-').Replace('%', '-').Replace(':', '-').Replace('&', '-');

            return validatedText;
        }
    }
}