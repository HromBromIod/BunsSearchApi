FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 9090
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["*.sln", "."]
COPY ["BunsSearchApi.BusinessLogic/BunsSearchApi.BusinessLogic.csproj", "BunsSearchApi.BusinessLogic/"]
COPY ["BunsSearchApi.Core/BunsSearchApi.Core.csproj", "BunsSearchApi.Core/"]
COPY ["BunsSearchApi.Integration/BunsSearchApi.Integration.csproj", "BunsSearchApi.Integration/"]
COPY ["BunsSearchApi.Web/BunsSearchApi.Web.csproj", "BunsSearchApi.Web/"]

RUN dotnet restore "BunsSearchApi.sln"

COPY . .
WORKDIR "/src"
RUN dotnet build "BunsSearchApi.sln" -c Release -o /app/build

FROM build AS publisher
WORKDIR "/src/BunsSearchApi.Web"
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publisher /app/publish .
ENTRYPOINT ["dotnet", "BunsSearchApi.Web.dll"]