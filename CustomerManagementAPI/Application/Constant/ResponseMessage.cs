namespace CustomerManagementAPI.Application.Constant
{
    public class ResponseMessage
    {
        public struct Success
        {
            public const string Successful = "İşlem Başarılı";
            public const string CustomerCreateSuccessful = "Müşteri başarıyla oluşturulmuştur. ";
            public const string CustomerUpdateSuccessful = "Müşteri bilgileri başarıyla güncellenmiştir. ";
            public const string CustomerDeleteSuccessful = "Müşteri bilgileri başarıyla silinmiştir. ";

        }
        public struct Error
        {
            public const string Fail = "İşlem Hatalı";
            public const string CustomerCreateFailed = "Müşteri oluşturulurken hata ile karşılaşılmıştır. Lütfen daha sonra tekrar deneyiniz. ";
            public const string CustomerUpdateFailed = "Müşteri bilgileri güncellenirken hata oluşmuştur. ";
            public const string CustomerDeleteFailed = "Müşteri bilgileri silinirken hata oluşmuştur. ";
        }
    }
}
