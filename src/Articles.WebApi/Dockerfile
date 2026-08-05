FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Articles.WebApi/Articles.WebApi.csproj", "Articles.WebApi/"]
COPY ["Articles.Infrastructure/Articles.Infrastructure.csproj", "Articles.Infrastructure/"]
COPY ["Articles.Core/Articles.Core.csproj", "Articles.Core/"]
RUN dotnet restore "Articles.WebApi/Articles.WebApi.csproj"
COPY . .
WORKDIR "/src/Articles.WebApi"
RUN dotnet build "Articles.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Articles.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Articles.WebApi.dll"]
