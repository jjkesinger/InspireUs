FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["../InspireUs.Congress.WebScraper/InspireUs.Congress.WebScraper.csproj", "../InspireUs.Congress.WebScraper/"]
COPY ["InspireUs.Congress.Domain/InspireUs.Congress.Domain.csproj", "InspireUs.Congress.Domain/"]
COPY ["InspireUs.Congress.Shared/InspireUs.Congress.Shared.csproj", "InspireUs.Congress.Shared/"]
COPY ["InspireUs.Congress.Infrastructure/InspireUs.Congress.Infrastructure.csproj", "InspireUs.Congress.Infrastructure/"]
RUN dotnet restore "../InspireUs.Congress.WebScraper/InspireUs.Congress.WebScraper.csproj"
COPY . .
WORKDIR "/src/../InspireUs.Congress.WebScraper"
RUN dotnet build "InspireUs.Congress.WebScraper.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InspireUs.Congress.WebScraper.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InspireUs.Congress.WebScraper.dll"]
