FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TestApi.Presentation/TestApi.Presentation.csproj", "TestApi.Presentation/"]
COPY ["TestApi.Application/TestApi.Application.csproj", "TestApi.Application/"]
COPY ["TestApi.Infrastructure/TestApi.Infrastructure.csproj", "TestApi.Infrastructure/"]
COPY ["TestApi.Domain/TestApi.Domain.csproj", "TestApi.Domain/"]
COPY ["TestApi.Persistence/TestApi.Persistence.csproj", "TestApi.Persistence/"]
RUN dotnet restore "TestApi.Presentation/TestApi.Presentation.csproj"
COPY . .
WORKDIR "/src/TestApi.Presentation"
RUN dotnet build "TestApi.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestApi.Presentation.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestApi.Presentation.dll"]