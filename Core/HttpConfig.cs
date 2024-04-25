using System.Text.Json;

using System.Net.Http.Headers;
namespace DirtLegalAssignment.Core
{
    public class HttpConfig
    {
        public Dictionary<string, string> _headerValues { get; set; }

        public string _baseUri { get; set; }


        public HttpConfig(Dictionary<string, string> headerValues, string baseUri)
        {
            _headerValues = headerValues;
            _baseUri = baseUri;
        }


        /// <param name="endPoint"> exclude the base uri and don't start with / if your base url starts with / </param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage?> Get(string endPoint)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, _baseUri + endPoint);
                SetHeaders(requestHeader: request.Headers);
                var response = await client.SendAsync(request);
                return response;
            }
            catch (Exception ex)
            {
                RequestErrorHandling(new
                {
                    endPoint,
                    exp = ex.Message,
                    time = DateTime.Now
                });
                return null;
            }

        }

        /// <param name="endPoint"> exclude the base uri and don't start with / if your base url starts with /</param>
        /// <param name="payload"> Order payload</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage?> Post(string endPoint, object payload)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, _baseUri + endPoint);
                string payloadString = JsonSerializer.Serialize(payload);
                request.Content = new StringContent(payloadString, null, "application/json");

                SetHeaders(requestHeader: request.Headers);
                var response = await client.SendAsync(request);
                return response;
            }
            catch (Exception ex)
            {
                RequestErrorHandling(new
                {
                    endPoint,
                    exp = ex.Message,
                    time = DateTime.Now
                });
                return null;
            }
        }


        private void SetHeaders(HttpRequestHeaders requestHeader)
        {
            if (_headerValues != null)
                foreach (var header in _headerValues)
                    requestHeader.Add(header.Key, header.Value);
        }
        /// <summary>
        ///  Should be used to store the logs in seq or database or any other logs system for further analysis and review.
        /// </summary>
        /// <param name="model"></param>
        private void RequestErrorHandling(object model)
        {

        }

    }
}
