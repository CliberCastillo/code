# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env

WORKDIR /api

#Se genera por capas y se almacena en cache
COPY Microservice.Docker.Api.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -o /publish

#Runtime Image Stage
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /publish
# Copia del contenedor de compilacion al contenedor de runtime
COPY --from=build-env /publish .
ENTRYPOINT ["dotnet","/publish/Microservice.Docker.Api.dll","--urls", "http://+:80"]