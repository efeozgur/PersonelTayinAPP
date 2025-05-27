using PersonelTayin.Models;


namespace PersonelTayin.Models
{
    public class TayinTalebi
    {
        public int Id { get; set; }

        // Foreign Key
        public int PersonelId { get; set; }


        public Personel Personel { get; set; }

        public string TalepTuru { get; set; }
        public string TercihAdliye { get; set; }
        public string Aciklama { get; set; }
        public DateTime BasvuruTarihi { get; set; }
        public string Durum { get; set; } = "Bekliyor";

    }
}