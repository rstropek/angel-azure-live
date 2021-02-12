FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY DemoApp.Api/*.csproj ./DemoApp.Api/
RUN dotnet restore

# copy everything else and build app
COPY DemoApp.Api/. ./DemoApp.Api/
WORKDIR /source/DemoApp.Api
RUN dotnet publish -c release -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "DemoApp.Api.dll"]
