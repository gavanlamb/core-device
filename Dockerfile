FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

COPY ./Core.Devices.sln ./
COPY ./src/Core.Devices.Api/Core.Devices.Api.csproj ./src/Core.Devices.Api/
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

# RUNTIME
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "Core.Devices.Api.dll"]
