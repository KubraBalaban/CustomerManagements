** Api Gateway **
Ocelot.json kullanılmaktadır.
Ocelot, .Net uygulamalarında kullanabileceğimiz, mikro servisler odaklı bir api gateway kütüphanesidir.
Client lardan gelen Request Modelini, Ocelot Route lara tanımlanmış API lere HttpRequestMessage olarak yönlendiren bir teknolojidir.
Ocelot API leri belirli bir sırada çalıştıran ve yöneten ara katman yazılımıdır.

Bu katmanda CustomerManagementApi de yazılmış olan servislerimizden dışarıya açılacak olanları ocelot.json üzerinden tanımlayarak erişim sağlanılması için eklenmiştir. 

Api gateway url: http://localhost:81/swagger/index.html
