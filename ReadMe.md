Docker Compose

İlk DockerCompose nedir diye başlarsak;
Docker Compose, Docker tarafından sağlanan bir araçtır ve birden fazla Docker konteynerını bir arada koordine etmek için kullanılmaktadır.Docker Compose, bir Docker projesinde bulunan farklı servisleri tek bir komutla çalıştırabilmenizi sağlamaktadır.

Tanımı sonrasında çalıştırılması için, solution kısmından set as startup project diyerek veya package manageer console kısmından "docker-compose up" komutu çalıştırılarak ilerlenebilir. Aynı zamanda uygulamalarımızın durumlarını da görmek için Docker Desktop uygulaması kurulması fayda sağlayacaktır.
Desktop uygulamamız üzerinden ayağa kalktığında imagelerımızın durumlarını ve hata aldıklarında mesaj detaylarını gözlemleyebilmektedir.

Docker Compose dosyamızda;
-postgre
-CustomerManagementApi
-ApiGateway
-WebUI
kısımları ayağa kalkmaktadır.

İlgili dosyamızda yapılandırma ayarları yapılarak ilerlenmiştir.
