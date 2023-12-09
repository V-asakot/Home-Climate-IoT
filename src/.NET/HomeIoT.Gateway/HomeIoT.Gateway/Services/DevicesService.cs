using IoT.Contracts.RequestResponse.Climate.RoomsController;
using IoT.Contracts.RequestResponse.Devices.DevicesController;

public class DevicesService
{
    private readonly IHttpClientFactory _httpClientFactory;
    public DevicesService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<GetDevicesResponse?> GetRoomDevices(Guid roomGuid){
        var client = _httpClientFactory.CreateClient("homeIoTDevices");
        var res = await client.GetFromJsonAsync<GetDevicesResponse>($"api/devices/{roomGuid}");
        return res;
    }

    public async Task<GetRoomsResponse?> GetRooms(){
        var client = _httpClientFactory.CreateClient("homeIoTDevices");
        var res = await client.GetFromJsonAsync<GetRoomsResponse>($"api/rooms");
        return res;
    }
}