# Etapa base para runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar os arquivos .csproj e restaurar as dependências
COPY common/Vidsnap.Common/Vidsnap.Common.csproj common/Vidsnap.Common/
COPY core/Vidsnap.Core/Vidsnap.Core.csproj core/Vidsnap.Core/
COPY infra.persistence/Vidsnap.Database/Vidsnap.Database.csproj infra.persistence/Vidsnap.Database/
COPY infra.web-api/Vidsnap.API/Vidsnap.API.csproj infra.web-api/Vidsnap.API/
RUN dotnet restore infra.web-api/Vidsnap.API/Vidsnap.API.csproj

# Copiar o restante do código e compilar
COPY . ./
WORKDIR "/src/infra.web-api/Vidsnap.API"
RUN dotnet build "./Vidsnap.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Etapa de publicação
FROM build AS publish
RUN dotnet publish "./Vidsnap.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa final para execução
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish ./
ENTRYPOINT ["dotnet", "Vidsnap.API.dll"]
