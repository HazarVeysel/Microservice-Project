FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim as build
WORKDIR /app
EXPOSE 80
COPY MGLCORE/MGLCORE/*.csproj MGLCORE/MGLCORE/
COPY MGLCORE/Core/*.csproj MGLCORE/Core/


RUN dotnet restore MGLCORE/MGLCORE/*.csproj

COPY . .

RUN dotnet publish MGLCORE/MGLCORE/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","MGLCORE.dll" ]