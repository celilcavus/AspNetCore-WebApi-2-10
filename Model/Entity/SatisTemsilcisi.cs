namespace Model.Entity
{
    public class SatisTemsilcisi
    {
        public int Id { get; set; }
        public string? SatisTemsilcisiAd { get; set; }
        public string? SatisTemsilcisiSoyad { get; set; }
        public Siparis? Siparis { get; set; }
    }
}