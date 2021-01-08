FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY . ./
# RUN dotnet restore
RUN dotnet publish FrontEnd/FrontEnd.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .

COPY ca_bundle.crt /usr/local/share/ca-certificates/your_ca.crt
RUN update-ca-certificates

ENTRYPOINT ["dotnet", "FrontEnd.dll"]