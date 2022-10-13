FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app
EXPOSE 80
COPY CompanyService/Business/*.csproj CompanyService/Business/
COPY CompanyService/Core/*.csproj CompanyService/Core/
COPY CompanyService/CompanyService/*.csproj CompanyService/CompanyService/


RUN dotnet restore CompanyService/CompanyService/*.csproj

COPY . .

RUN dotnet publish CompanyService/CompanyService/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","CompanyService.dll" ]