# Get dotnet sdk
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine-arm64v8 AS build-env
WORKDIR /api

# Build app
COPY . ./
RUN dotnet publish WebApi -r linux-musl-arm64 -p:PublishSingleFile=true -c Release -o ./deploy

# Generate image
FROM mcr.microsoft.com/dotnet/runtime-deps:6.0-alpine-arm64v8
WORKDIR /api
COPY --from=build-env /api/deploy/WebApi .
EXPOSE 80
ENTRYPOINT ["./WebApi"]