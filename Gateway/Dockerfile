FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app
EXPOSE 80

COPY Gateway/Gateway/*.csproj Gateway/Gateway/
# COPY *.sln .

RUN dotnet restore Gateway/Gateway/*.csproj

COPY . .

RUN dotnet publish Gateway/Gateway/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
# ENV ASPNETCORE_URLS="http://*:7231"
# ENV ASPNETCORE_ENVIRONMENT="Development"
ENTRYPOINT [ "dotnet","Gateway.dll" ]