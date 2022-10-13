FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY /bin/Release/net6.0/Publish /app
ENV ASPNETCORE_URLS="http://*:2001"
ENTRYPOINT ["dotnet", "Gateway.dll"]