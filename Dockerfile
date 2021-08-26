# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env

ADD . /sources
WORKDIR /sources

# Copy csproj and restore as distinct layers
# COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
# COPY ../engine/examples ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /sources/out .
ENTRYPOINT ["dotnet", "AirLiquide_Test.API.dll"]