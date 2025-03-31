FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Graduation.Web/Graduation.Web.csproj", "src/Graduation.Web/"]
COPY ["src/Graduation.Application/Graduation.Application.csproj", "src/Graduation.Application/"]
COPY ["src/Graduation.Application.Interfaces/Graduation.Application.Interfaces.csproj", "src/Graduation.Application.Interfaces/"]
COPY ["src/Graduation.Domain/Graduation.Domain.csproj", "src/Graduation.Domain/"]
COPY ["src/Graduation.Infrastructure/Graduation.Infrastructure.csproj", "src/Graduation.Infrastructure/"]
RUN dotnet restore "src/Graduation.Web/Graduation.Web.csproj"
COPY . .
WORKDIR "/src/src/Graduation.Web"
RUN dotnet build "Graduation.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Graduation.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Graduation.Web.dll"]
