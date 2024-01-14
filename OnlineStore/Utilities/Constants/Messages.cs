using Microsoft.AspNetCore.Components;

namespace OnlineStore.Utilities.Constants
{
    public static class Messages
    {
        public static string Added = "Kayıt Başarıyla Oluşturuldu!";
        public static string Update = "Kayıt Başarıyla Güncellendi!";
        public static string Delete = "Kayıt Başarıyla Silindi!";
        public static string GetProductError = "Ürünler getirilirken bir hata oluştu.";

        public static string UserNotValidation = "Kullanıcı bilgileri doğrulanamadı.";

        public static string OrderWaiting = "Onay bekleniyor.";
        public static string OrderShipped = "Sipariş kargoya verildi.";
        public static string OrderCompleted = "Sipariş tamamlandı.";
        public static string OrderCanceled = "Sipariş iptal edildi";
    }
}
