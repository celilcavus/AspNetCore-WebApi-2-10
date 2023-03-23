namespace Model.Entity
{
    public class KargoFirmasi
    {
        public int Id { get; set; }
        public string? KargoAd { get; set; }

        public string? Adres { get; set; }
        public string? Temsilci { get; set; }

        public int SiparisId { get; set; }
        public List<Siparis>? Siparis { get; set; }

    }
}