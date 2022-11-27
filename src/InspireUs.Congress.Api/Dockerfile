FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["InspireUs.Congress.Api/InspireUs.Congress.Api.csproj", "InspireUs.Congress.Api/"]
COPY ["InspireUs.Congress.Domain/InspireUs.Congress.Domain.csproj", "InspireUs.Congress.Domain/"]
COPY ["InspireUs.Congress.Infrastructure/InspireUs.Congress.Infrastructure.csproj", "InspireUs.Congress.Infrastructure/"]
RUN dotnet restore "InspireUs.Congress.Api/InspireUs.Congress.Api.csproj"
COPY . .

WORKDIR "/src/InspireUs.Congress.Api"
RUN dotnet build "InspireUs.Congress.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InspireUs.Congress.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InspireUs.Congress.Api.dll"]
