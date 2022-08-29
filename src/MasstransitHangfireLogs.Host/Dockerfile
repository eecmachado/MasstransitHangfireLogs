FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/MasstransitHangfireLogs.Host/MasstransitHangfireLogs.Host.csproj", "MasstransitHangfireLogs.Host/"]
RUN dotnet restore "src/MasstransitHangfireLogs.Host/MasstransitHangfireLogs.Host.csproj"
COPY . .
WORKDIR "/src/MasstransitHangfireLogs.Host"
RUN dotnet build "MasstransitHangfireLogs.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MasstransitHangfireLogs.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MasstransitHangfireLogs.Host.dll"]
