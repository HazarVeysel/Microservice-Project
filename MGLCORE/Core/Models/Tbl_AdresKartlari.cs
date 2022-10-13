using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Tbl_AdresKartlari
    {
        public int id { get; set; }
        public string firmaozelkodu { get; set; }
        public string muhasebekodu { get; set; }
        public string musteradi { get; set; }
        public Nullable<int> yerliyabanci { get; set; }
        public string? unvan { get; set; }
        public string? adres { get; set; }
        public string? adres1 { get; set; }
        public string? adres2 { get; set; }
        public string? txtcountry { get; set; }
        public string? txtcountrycode { get; set; }
        public string? ilce { get; set; }
        public string? il { get; set; }
        public string? ilcode { get; set; }
        public string? txtzipcode { get; set; }
        public string? tel { get; set; }
        public string? fax { get; set; }
        public string? vergidairesi { get; set; }
        public string? vergino { get; set; }
        public string? mersisno { get; set; }
        public string? txtshortcut { get; set; }
        public string? cmbtype { get; set; }
        public string? cmblevel { get; set; }
        public string? txtemail { get; set; }
        public string? txtweb { get; set; }
        public string? txtnotes { get; set; }
        public string? cmbpaymenttype { get; set; }
        public string? cmbpaymentmaturity { get; set; }
        public string? Sectors { get; set; }
        public Nullable<int> Onay { get; set; }
        public Nullable<bool> ckair { get; set; }
        public Nullable<bool> cksea { get; set; }
        public Nullable<bool> ckland { get; set; }
        public Nullable<bool> cktank { get; set; }
        public Nullable<bool> ckproject { get; set; }
        public Nullable<bool> ckother { get; set; }
        public string? networks { get; set; }
        public Nullable<int> logoaktarim { get; set; }
        public Nullable<int> vergimuaf { get; set; }
        public string? GuncelleyenKullanici { get; set; }
        public string? GuncellemeTarihi { get; set; }
        public string? EkleyenKullanici { get; set; }
        public string? EklemeTarihi { get; set; }
        public string? carinot { get; set; }
        public Nullable<int> Vadetipi { get; set; }
        public string? VadeOnaylayan { get; set; }
        public string? VadeOnaylamaTarihi { get; set; }
        //public byte[] BinaryDosya { get; set; }
        //public string BinaryDosyaExt { get; set; }
        public Nullable<short> Efatura { get; set; }
        public Nullable<short> EfaturaTur { get; set; }
        public Nullable<int> StatusRecord { get; set; }
        public string? TransferError { get; set; }
        public Nullable<int> Priority { get; set; }
        public string? DepoMuhasebeHesabi { get; set; }
        public string? WebKullaniciAdi { get; set; }
        public string? WebSifre { get; set; }
        public Nullable<int> DovizTuru { get; set; }
        public Nullable<int> KurTuru { get; set; }
        public Nullable<int> KanuniTakip { get; set; }
        public Nullable<int> FirmaTuru { get; set; }
        public Nullable<int> GonderimTuru { get; set; }
        public string? GonderimEmail { get; set; }
        public Nullable<int> CargoPrealertGonderimi { get; set; }
        public Nullable<int> GemiCikisGonderimi { get; set; }
        public Nullable<int> GemiVarisGonderimi { get; set; }
        public Nullable<int> GelirFaturasi { get; set; }
        public Nullable<int> SoaGonderimi { get; set; }
        public string? SahisFirmasiAdi { get; set; }
        public string? SahisFirmasiSoyadi { get; set; }
        public string? KesilebilirDovizTurleri { get; set; }
        public Nullable<int> GonderilecekDosyaTuru { get; set; }
        public string? LoadTracking { get; set; }
        public string? LoadTracking_Title { get; set; }
        public string? LoadTracking_Order { get; set; }
        public string? AuthorisedCompanyCodes { get; set; }
        public Nullable<int> Tech_Agreement { get; set; }
        public string? DefaultCurrency { get; set; }
        public Nullable<System.DateTime> Tech_Agreement_Date { get; set; }
        public string? EInvoicePK { get; set; }
        public string? EInvoiceGB { get; set; }
        public Nullable<int> ImpExp { get; set; }
    }
    public class ApiReturnData<T>
    {
        public List<T> data { get; set; }
        public bool success { get; set; }
        public string message { get; set; }

    }

}
