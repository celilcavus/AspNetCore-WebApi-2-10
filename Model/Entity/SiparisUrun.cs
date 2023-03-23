namespace Model.Entity
{
    public class SiparisUrun
    {
        public int Id { get; set; }
        public int SiparisId { get; set; }
        public List<Siparis>? Siparis { get; set; }
        public int UrunId { get; set; }
        public Urun? Urun { get; set; }
        public decimal BirimFiyati { get; set; }
        public int Miktari { get; set; }
    }
}