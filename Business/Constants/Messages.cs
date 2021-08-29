using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public const string ProductAdded = "Ürün Eklendi";
        public const string ProductNameInvalid = "Ürün ismi geçersiz";
        public const string MaintenanceTime = "Sistem Bakımda";
        public const string ProductsListed = "Ürünler listelendi";
        public const string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir.";
        public const string ProductNameAlreadyExists = "Böyle bir ürün zaten mevcut";
        public const string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public const string AuthorizationDenied = "Yetkiniz yok.";
        public const string UserRegistered = "Kayıt oldu.";
        public const string UserNotFound = "Kullanıcı bulunamadı.";
        public const string PasswordError = "Hatalı şifre.";
        public const string SuccessfulLogin = "Giriş başarılı.";
        public const string UserAlreadyExists = "Kullanıcı zaten mevcut.";
        public const string AccessTokenCreated = "Access token oluşturuldu.";
    }
}
