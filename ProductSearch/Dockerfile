FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_ENVIRONMENT=Docker

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProductSearch.Api/ProductSearch.Api.csproj", "ProductSearch.Api/"]
COPY ["ProductSearch.Application/ProductSearch.Application.csproj", "ProductSearch.Application/"]
COPY ["ProductSearch.Infrastructure/ProductSearch.Infrastructure.csproj", "ProductSearch.Infrastructure/"]
COPY ["ProductSearch.Domain/ProductSearch.Domain.csproj", "ProductSearch.Domain/"]

RUN dotnet restore "ProductSearch.Api/ProductSearch.Api.csproj"
COPY . .
WORKDIR "/src/ProductSearch.Api"
RUN dotnet build "ProductSearch.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ProductSearch.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProductSearch.Api.dll"]
