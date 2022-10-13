FROM mcr.microsoft.com/dotnet/sdk:6.0-focal as build 
# Hangi sdk ile geliştirildiyse onu hub.docker'dan sdk image'ını aldık ve build olarak kullandık.
WORKDIR /app
# app adında bir çalışma klasörü oluşturduk.
EXPOSE 80
# birbirleriyle haberleşmeleri için servisimizi 80 portuna açtık.

COPY AuthenticateService/Business/*.csproj AuthenticateService/Business/
COPY AuthenticateService/Core/*.csproj AuthenticateService/Core/
COPY AuthenticateService/WebAPI/*.csproj AuthenticateService/WebAPI/
#Buralarda herbir katmanın csprojunu bi üst katmanına kopyaladık.

RUN dotnet restore AuthenticateService/WebAPI/*.csproj
#Projenin çalışma dosyasını restore ederek en son güncel çalışır hale getirdik. Burada proje katmanlı olduğu için Api katmanının csproj'u ile restore yapıyoruz.Yoksa run hatası veriyor.

COPY . .
#Geriye kalan sistem dosyalarının da hepsini kopyaladık

RUN dotnet publish AuthenticateService/WebAPI/*.csproj -c Release -o out
#Api katmanının release modda publishini aldık ve out diye bir klasör oluşturup oraya kopyaladık.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal as runtime
#Projenin runtime'da çalışması gerektiğinden aspnet'in runtime image'ını hub.docker'dan bulup çektik.
WORKDIR /app
#Bu sefer runtime için bir app klasörü oluşturdu.
COPY --from=build /app/out .
#En yukarda build'dekini de çekip out klasörüne attı.
ENTRYPOINT [ "dotnet","WebAPI.dll" ]
#Api katmanı içindeki dll'in adını başlangıç noktası olarak belirledik. Bunu yanlış verince SDK is not installed hatası veriyor.
#Eğer gateway ile bağlanırken 502 bad request hatası dönüyorsa http olarak değil https olarak gidiyor olabilir.