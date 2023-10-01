using HomeIoT.Contracts.Enums;
using MediatR;

namespace RoomsClimate.Service.Features.AddDevice;

public record AddDeviceCommand(string DeviceName, Guid DeviceGuid, Guid RoomGuid, DeviceType DeviceType) : IRequest<bool>;