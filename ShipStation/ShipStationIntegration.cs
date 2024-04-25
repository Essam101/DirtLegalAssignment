using DirtLegalAssignment.Core;
using DirtLegalAssignment.ShipStation.Models;

namespace DirtLegalAssignment.ShipStation
{
    public class ShipStationIntegration
    {
        private HttpConfig _httpConfig { get; set; }
        public ShipStationIntegration()
        {
            _httpConfig = new(new Dictionary<string, string>()
            {
               { "Authorization", "_" },
            }, "https://ssapi.shipstation.com/");
        }

        /// <param name="query">Url query</param>
        /// <returns>BaseResult</returns>
        public async Task<object> GetOrdersAsync(string? query)
        {
            var httpResponse = await _httpConfig.Get($"orders?{query}");

            if (httpResponse == null)
                return new BaseResult(statusCode: CustomHttpStatusCode.DirtLegalServerError);

            return new BaseResult(statusCode: (CustomHttpStatusCode)httpResponse.StatusCode, await httpResponse.Content.ReadAsStringAsync());
        }


        /// <param name="payload">order payload</param>
        /// <returns>BaseResult</returns>
        public async Task<object> CreateOrUpdateOrderAsync(object payload)
        {

            var httpResponse = await _httpConfig.Post("orders/createorder", payload);

            if (httpResponse == null)
                return new BaseResult(statusCode: CustomHttpStatusCode.DirtLegalServerError);

            return new BaseResult(statusCode: (CustomHttpStatusCode)httpResponse.StatusCode, await httpResponse.Content.ReadAsStringAsync());
        }
    }
}
