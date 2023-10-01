FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
RUN dotnet nuget add source http://host.docker.internal:5555/v3/index.json -n DockerSource
COPY HomeIoT.Web.csproj .
RUN dotnet restore HomeIoT.Web.csproj

COPY . .
RUN dotnet build HomeIoT.Web.csproj -c Development -o /app/build

FROM build AS publish
RUN dotnet publish HomeIoT.Web.csproj -c Development -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf