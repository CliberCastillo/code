FROM mcr.microsoft.com/dotnet/aspnet:5.0

WORKDIR /app
#Physical to Container
COPY bin/Debug/net5.0/publish .

ENTRYPOINT ["dotnet","Microservice.Docker.Api.dll"]