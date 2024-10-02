FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ScientificWork.Web/ScientificWork.Web.csproj", "ScientificWork.Web/"]
COPY ["ScientificWork.Infrastructure.DataAccess/ScientificWork.Infrastructure.DataAccess.csproj", "ScientificWork.Infrastructure.DataAccess/"]
COPY ["ScientificWork.Infrastructure.Abstractions/ScientificWork.Infrastructure.Abstractions.csproj", "ScientificWork.Infrastructure.Abstractions/"]
COPY ["ScientificWork.Domain/ScientificWork.Domain.csproj", "ScientificWork.Domain/"]
COPY ["ScientificWork.UseCases/ScientificWork.UseCases.csproj", "ScientificWork.UseCases/"]
COPY ["ScientificWork.DomainServices/ScientificWork.DomainServices.csproj", "ScientificWork.DomainServices/"]
COPY ["ScientificWork.UseCases.Common/ScientificWork.UseCases.Common.csproj", "ScientificWork.UseCases.Common/"]
COPY ["ScientificWork.Infrastructure.Common/ScientificWork.Infrastructure.Common.csproj", "ScientificWork.Infrastructure.Common/"]
RUN dotnet restore "ScientificWork.Web/ScientificWork.Web.csproj"
COPY . .
WORKDIR "/src/ScientificWork.Web"
RUN dotnet build "ScientificWork.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ScientificWork.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ScientificWork.Web.dll"]
