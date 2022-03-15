using Core.Entities.ConCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contants //Constans
{
    public static class Messages
    {
        public static string BookAddMessage = "Kitap başarıyla eklendi";
        public static string BookUpdateMessage = "Kitap başarıyla güncellendi";
        public static string BookDeleteMessage = "Kitap başarıyla silindi";

        public static string BookImageAddMessage = "Kitap Resmi başarıyla eklendi";
        public static string BookImageUpdateMessage = "Kitap Resmi başarıyla güncellendi";
        public static string BookImageDeleteMessage = "Kitap Resmi başarıyla silindi";

        public static string CategoryAddMessage = "Kategori başarıyla eklendi";
        public static string CategoryUpdateMessage = "Kategori başarıyla güncellendi";
        public static string CategoryDeleteMessage = "Kategori başarıyla silindi";

        public static string UserAddMessage = "Kullanıcı başarıyla eklendi";
        public static string UserUpdateMessage = "Kullanıcı başarıyla güncellendi";
        public static string UserDeleteMessage = "Kullanıcı başarıyla silindi";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
       
        public static string PublisherAddMessage = "Yayınevi başarıyla eklendi";
        public static string PublisherUpdateMessage = "Yayınevi başarıyla güncellendi";
        public static string PublisherDeleteMessage = "Yayınevi başarıyla silindi";

        public static string LocationAddMessage = "Konum başarıyla eklendi";
        public static string LocationUpdateMessage = "Konum başarıyla güncellendi";
        public static string LocationDeleteMessage = "Konum başarıyla silindi";

        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExits = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı oluşturuldu";
        public static string AccesTokenCreated = "AccessToken başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Yetkiniz yok";
    }
}
