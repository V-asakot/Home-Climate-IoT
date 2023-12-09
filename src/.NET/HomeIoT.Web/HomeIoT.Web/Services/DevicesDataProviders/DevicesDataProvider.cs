using System.Net.Http.Json;
using HomeIoT.Web.Shared.Component;

namespace HomeIoT.Web.Services.DevicesDataProviders
{
    public abstract class DevicesDataProvider
    {
        protected readonly IHttpClientFactory _httpClientFactory;
        public DevicesDataProvider(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public abstract Task<List<CardMetadata>> GetRoomDevices(Guid roomGuid);

        protected async Task<T?> GetDevicesStates<T>(string url)
        {
            var client = _httpClientFactory.CreateClient("gateway");

            return await client.GetFromJsonAsync<T>(url);
        }

    }
}