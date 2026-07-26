FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY ["src/CloudCRM.Web/CloudCRM.Web.csproj", "src/CloudCRM.Web/"]
COPY ["src/CloudCRM.Application/CloudCRM.Application.csproj", "src/CloudCRM.Application/"]
COPY ["src/CloudCRM.Core/CloudCRM.Core.csproj", "src/CloudCRM.Core/"]
COPY ["src/CloudCRM.Infrastructure/CloudCRM.Infrastructure.csproj", "src/CloudCRM.Infrastructure/"]

RUN dotnet restore "src/CloudCRM.Web/CloudCRM.Web.csproj"

COPY . .

WORKDIR "/src/src/CloudCRM.Web"

RUN dotnet publish "CloudCRM.Web.csproj" \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENV ASPNETCORE_HTTP_PORTS=8080

ENTRYPOINT ["dotnet", "CloudCRM.Web.dll"]