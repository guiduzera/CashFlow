# Estágio base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Verifique a estrutura do diretório antes do restore
RUN ls -la /src
COPY ["src/CashFlow.API/CashFlow.API.csproj", "src/CashFlow.API/"]
COPY ["src/CashFlow.Application/CashFlow.Application.csproj", "src/CashFlow.Application/"]
COPY ["src/CashFlow.Communication/CashFlow.Communication.csproj", "src/CashFlow.Communication/"]
COPY ["src/CashFlow.Domain/CashFlow.Domain.csproj", "src/CashFlow.Domain/"]
COPY ["src/CashFlow.Exception/CashFlow.Exception.csproj", "src/CashFlow.Exception/"]
COPY ["src/CashFlow.Infrastructure/CashFlow.Infrastructure.csproj", "src/CashFlow.Infrastructure/"]

# Verifique a estrutura do diretório após copiar os arquivos .csproj
RUN ls -la /src
RUN ls -la /src/CashFlow.Infrastructure

RUN dotnet restore "./src/CashFlow.API/CashFlow.API.csproj"
COPY . .
WORKDIR "/src/src/CashFlow.API"
RUN dotnet build "./CashFlow.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Estágio de publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CashFlow.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Estágio final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CashFlow.API.dll"]