namespace PersonelTayin.Models
{
    public class Personel
    {
        public int Id { get; set; }
        public string SicilNo { get; set; }
        public string AdSoyad { get; set; }
        public string Sifre { get; set; }
        public string Unvan { get; set; }
        public string Cinsiyet { get; set; } = "Erkek";
        public string Yetki { get; set; } = "Kullanici";
        public string GorevYeri { get; set; }

        //Bir personelin birden fazla tayin talebi olabilir. Bu ilişkili tablo
        public ICollection<TayinTalebi> TayinTalepleri { get; set; }
    }
}
