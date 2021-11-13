FROM mcr.microsoft.com/dotnet/sdk:5.0

WORKDIR /api
COPY . .

RUN dotnet dev-certs https

RUN dotnet restore

RUN dotnet publish -o /publish

WORKDIR /publish

ENTRYPOINT ["dotnet","/publish/Microservice.Docker.Api.dll","--urls", "http://+:80;https://+:443"]