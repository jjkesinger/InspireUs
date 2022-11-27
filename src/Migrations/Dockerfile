FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

RUN dotnet tool install --global dotnet-ef --version 7.0.0
ENV PATH="${PATH}:/root/.dotnet/tools"

WORKDIR /source
COPY ["InspireUs.Congress.Api/InspireUs.Congress.Api.csproj", "InspireUs.Congress.Api/"]
COPY ["InspireUs.Congress.Domain/InspireUs.Congress.Domain.csproj", "InspireUs.Congress.Domain/"]
COPY ["InspireUs.Congress.Infrastructure/InspireUs.Congress.Infrastructure.csproj", "InspireUs.Congress.Infrastructure/"]
COPY ["InspireUs.Congress.Shared/InspireUs.Congress.Shared.csproj", "InspireUs.Congress.Shared/"]

RUN dotnet restore "InspireUs.Congress.Api/InspireUs.Congress.Api.csproj"
COPY . .
RUN dotnet build "InspireUs.Congress.Api/InspireUs.Congress.Api.csproj" -c Release -v diagnostic

# for build only
ENV CONGRESS_ADMIN_CONNECTIONSTRING="Server=db;Database=Congress;User Id=sa;Password=notused;TrustServerCertificate=True;"

RUN dotnet ef migrations bundle -p "InspireUs.Congress.Infrastructure/InspireUs.Congress.Infrastructure.csproj" -s "InspireUs.Congress.Api/InspireUs.Congress.Api.csproj" --configuration Release --no-build --self-contained

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS run

WORKDIR /home

COPY --from=build /source/efbundle .

COPY InspireUs.Congress.Api/appsettings.json .

#used for migrations
ENV CONGRESS_ADMIN_CONNECTIONSTRING="Server=db;Database=Congress;User Id=sa;Password=Pass@word;TrustServerCertificate=True;"

CMD ./efbundle