# Etapa 1: Compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copia el archivo del proyecto (.csproj) y restaura las dependencias
COPY ["Aponus Web API/Aponus Web API.csproj", "./"]
RUN dotnet restore "./Aponus Web API.csproj"

# Copia todo el código fuente y compila la aplicación
COPY ["Aponus Web API/", "./"]
WORKDIR "/src/"
RUN dotnet build "Aponus Web API.csproj" -c Release -o /app/build

# Publica la aplicación en un directorio de salida
RUN dotnet publish "Aponus Web API.csproj" -c Release -o /app/publish

# Etapa 2: Ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expone el puerto 80 para el tráfico HTTP
EXPOSE 80

# Comando de inicio
ENTRYPOINT ["dotnet", "Aponus Web API.dll"]