FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["FeedCord.csproj", "./"]
COPY ["src", "./src"]
COPY appsettings.json ./appsettings.json

RUN dotnet restore && \
    dotnet build -c Release -o /app/build && \
    dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
COPY --from=build /src/appsettings.json ./config/appsettings.json

EXPOSE 8000

ENTRYPOINT ["dotnet", "FeedCord.dll", "/app/config/appsettings.json"]
