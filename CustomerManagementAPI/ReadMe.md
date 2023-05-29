**Customer Management Api **
Url:http://localhost:82/swagger/index.html
Db: Postgre
.Net 6.0
C#
Entity Framework
PostgreSql

Customer Management Api postgre ayağa kalkmadan kalkmamaktadır.Bu da docker compose dosyamızda tanımlı bulunmaktadır.
Ayağa kaldırabilmek için docker desktop yüklenmesi ile birlikte docker-compose kısmının Set as startup project olarak setlenmesi gerekmektedir. Package manager console kısmından "docker-compose up "komutu çalıştırılarak da ilerlenebilir.

Customer Management Api Servislerimizin yazıldığı kısımdır. Bu kısımda;
Authentication olunmadan servislere erişim mümkün değildir. 

Bu sebeple ilk adımda;
Customer Management Api Url: http://localhost:82/swagger/index.html eriştikten sonra açılan swagger ön yüzümüz ile birlikte /Authentication/Authenticate servisimiz
Username:CustomerUser
Password:CustomerUser123
bilgileri ile tetiklenmektedir. Dönen response bilgimizde olan token ile birlikte Authorize olduktan sonra servislerimize istek atabilir ve responselarımızı görebiliriz.

Authentication kısmı hariç iki Controllerımız bulunmaktadır. 

-Customer
-Company


***Customer**
Entity oluşturulması için Migration kullanılmıştır. 
CreateCustomer: Müşteri oluşturulması için olan servisimizdir.
UpdateCustomer: Müşteri güncellenmesi için yazılmış olan servisimizdir.
DeleteCustomer: Müşteri silinmesi için yazılmış olan servisimizdir.
GetallCustomers: Tüm müşterilerimizin çekilmesi için yazılmış olan servisimizdir.
GetAllCustomersById: Müşterilerin Id bazlı veri çekilmesi için yazılmış olan servisimizdir.

**Company
GetAllCompany: Tüm şirketlerin çekilmesi için yazılmıştır. Api gateway de süreçte yazılmamış olan servislerin gözükmediğini belirtmek için eklenmiş bir servistir. Gateway linkimiz üzerinden ilgili kısmı görebilirsiniz. (http://localhost:81/swagger/index.html)

Customer Management Api de JWT token yapısı kullanılarak ilerlenmiştir. JWTAuthenticationManager kısmı proje olarak eklenmiştir. 

Aynı zamanda ilgili kısımda örnek bir unit test de yazılmış olarak bulunmaktadır. CustomerManagementApi.UnitTest kısmından AuthenticationControllerTest kısmından detaylarına bakabilirsiniz.

Postgre bağlantısı pgadmin üzerinden girilecek olan bilgilerimiz;
*Connection altında;
-Host: 127.0.0.1
-Port:5432
-MaintanenceDatabase: postgre
-Username: customerManagementUser
-Password: customerManagementPassword 
şeklindedir.