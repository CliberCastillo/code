#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["app/Domain/Microservice.Demo.Report.Api/Microservices.Demo.Report.API.csproj", "app/Domain/Microservice.Demo.Report.Api/"]
RUN dotnet restore "app/Domain/Microservice.Demo.Report.Api/Microservices.Demo.Report.API.csproj"
COPY . .
WORKDIR "/src/app/Domain/Microservice.Demo.Report.Api"
RUN dotnet build "Microservices.Demo.Report.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microservices.Demo.Report.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservices.Demo.Report.API.dll"]