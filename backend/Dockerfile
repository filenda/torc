# Use the latest version of ASP.NET Core runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
# EXPOSE 5000

# Use the latest version of the SDK for building the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BookLibraryApi.csproj", "."]
RUN dotnet restore "./BookLibraryApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "BookLibraryApi.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "BookLibraryApi.csproj" -c Release -o /app/publish

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookLibraryApi.dll"]
