FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY . ./
# RUN dotnet restore
RUN dotnet publish BackEnd/BackEnd.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .

# Create non-root user and set permissions
RUN (which useradd || (apt-get update && apt-get install -y useradd)) && \
    (useradd -u 1000 appuser || true) && \
    (chown -R 1000:1000 /app)

USER 1000

ENTRYPOINT ["dotnet", "BackEnd.dll"]