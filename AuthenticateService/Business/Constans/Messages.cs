using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constans
{
    public class Messages
    {
        public static string AddedEntryType = "Giriş Tipi kaydı başarıyla tamamlandı";
        public static string UpdatedEntryType = "Giriş Tipi kaydı başarıyla güncellendi";
        public static string EntryTypeAlreadyExists = "Bu giriş tipi daha önce kaydedilmiş olduğundan ekleme yapılamadı";
        public static string EntryTypeCharacter = "Giriş tipi ekleme işlemi başarısızlıkla sonuçlandı.Giriş Tipi adı 3 karakterden büyük olmalıdır.";
        public static string UserNameCharacter = "Kullanıcı adı 3 karakterden büyük olmalıdır.";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre yanlış";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserRegistered = "Kullanıcı kaydı başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı mevcut";
        public static string UserMailConfirmSuccessful = "Mailiniz başarıyla onaylandı";
        public static string MailAlreadyConfirm = "Mailiniz zaten onaylı. Tekrar gönderim yapılmadı";
        public static string MailConfirmTimeHasNotExpired = "Mail onayını 5 dakikada bir gönderebilirsiniz";
        public static string UpdatedUser = "Kullanıcı başarıyla güncellendi";
        public static string DeletedUser = "Kullanıcı başarıyla silindi";
        public static string ChangedPassword = "Şifre başarıyla değiştirildi";
        public static string DeletedUserEntryTypeReletionShip = "Kullanıcının şirket ile bağlantısı kesilmiştir";
        public static string AddedUserEntryTypeReletionShip = "Kullanıcı ile şirket arasında bağlantı kuruldu";
        public static string UpdatedUserTheme = "Tema başarıyla güncellendi";

        public static string MailParameterUpdated = "Mail parameterleri başarıyla güncellendi";
        public static string MailSendSucessful = "Mail başarıyla gönderildi";
        public static string MailConfirmSendSuccessful = "Onay maili tekrar gönderildi";

        public static string MailTemplateAdded = "Mail şablonu başarıyla kaydedildi";
        public static string MailTemplateUpdated = "Mail şablonu başarıyla güncellendi";
        public static string MailTemplateDeleted = "Mail şablonu başarıyla silindi";

     

        public static string AddedOperationClaim = "Yetki başarıyla eklendi";
        public static string UpdatedOperationClaim = "Yetki başarıyla güncellendi";
        public static string DeletedOperationClaim = "Yetki başarıyla silindi";

        public static string AddedUserOperationClaim = "Kullanıcıya yetki başarıyla eklendi";
        public static string UpdatedUserOperationClaim = "Kullanıcı yetkisi başarıyla güncellendi";
        public static string DeletedUserOperationClaim = "Kullanıcı yetkisi başarıyla silindi";

        public static string UpdateTermsAndConditions = "Sözleşme başarıyla güncellendi";
    }
}