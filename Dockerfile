# Get dotnet sdk
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Build app
COPY . ./
RUN ls
RUN dotnet build WebApi -a arm64 --self-contained true --configuration Release --output out

# Generate image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet","WebApi.dll"]