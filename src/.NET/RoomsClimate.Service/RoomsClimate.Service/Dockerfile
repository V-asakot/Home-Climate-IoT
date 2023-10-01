#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

RUN dotnet nuget add source http://host.docker.internal:5555/v3/index.json -n DockerSource

WORKDIR /src
COPY ["RoomsClimate.Service.csproj", "RoomsClimate.Service/"]
RUN dotnet restore "RoomsClimate.Service/RoomsClimate.Service.csproj"
WORKDIR "/src/RoomsClimate.Service"
COPY . .

RUN dotnet build "RoomsClimate.Service.csproj" -c Development -o /app/build

FROM build AS publish
RUN dotnet publish "RoomsClimate.Service.csproj" -c Development -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RoomsClimate.Service.dll"]