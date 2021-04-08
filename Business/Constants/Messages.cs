using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba başarıyla eklendi.";
        public static string CarDeleted = "Araba başarıyla silindi.";
        public static string CarUpdated = "Araba başarıyla güncellendi.";
        public static string FailedCarAddOrUpdate = "Lütfen günlük fiyat kısmını 0'dan büyük giriniz.";
        public static string CarsListed = "Arabalar başarıyla listelendi";


        public static string BrandAdded = "Marka başarıyla eklendi.";
        public static string BrandDeleted = "Marka başarıyla silindi.";
        public static string BrandUpdated = "Marka başarıyla güncellendi.";
        public static string FailedBrandAddOrUpdate = "Lütfen marka isminin uzunluğunu 2 karakterden fazla giriniz.";

        public static string ColorAdded = "Renk başarıyla eklendi.";
        public static string ColorDeleted = "Renk başarıyla silindi..";
        public static string ColorUpdated = "Renk başarıyla güncellendi.";

        public static string UserAdded = "Kullanıcı başarıyla eklendi.";
        public static string UserDeleted = "Kullanıcı başarıyla silindi.";
        public static string UserUpdated = "Kullanıcı başarıyla güncellendi.";

        public static string CustomerAdded = "Kullanıcı başarıyla eklendi.";
        public static string CustomerDeleted = "Kullanıcı başarıyla silindi.";
        public static string CustomerUpdated = "Kullanıcı başarıyla güncellendi.";

        public static string RentalAdded = "Araba Kiralama işlemi başarıyla gerçekleşti.";
        public static string RentalDeleted = "Araba Kiralama işlemi iptal edildi.";
        public static string RentalUpdated = "Araba Kiralama işlemi güncellendi.";
        public static string FailedRentalAddOrUpdate = "Bu araba henüz teslim edilmediği için kiralayamazsınız.";
        public static string RentalReturned = "Kiraladığınız araç teslim edildi.";

        public static string CarImageAdded = "Fotoğraf yükleme işlemi başarıyla gerçekleşti.";
        public static string CarImageDeleted = "Fotoğraf silme işlemi başarıyla gerçekleştirildi.";
        public static string CarImageUpdated = "Fotoğraf güncelleme başarıyla gerçekleştirildi.";
        public static string CarImageLimitExceeded = "More than 5 images cannot be added";
        public static string NoCarImages = "The car does NOT have any images";

        public static string MaintenanceTime = "Sistem bakımda";
        public static string UserNotFound = "User not found";
        public static string PasswordError = "PasswordError";
        public static string SuccessfulLogin = "SuccessfulLogin";
        public static string UserAlreadyExists = "UserAlreadyExists";
        public static string UserRegistered = "SuccessUserRegistered";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string LoginSuccess = "Successfully";
        public static string CardExist = "";
        public static string FindexAdded = "Findex eklendi";
        public static string FindexDeleted = "Findex silindi";
        public static string FindexUpdated = "Findex güncellendi";
        public static string NoCar = "NoCar!";
    }
}
