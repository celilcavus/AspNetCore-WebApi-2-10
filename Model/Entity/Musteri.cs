namespace Model.Entity
{
    public class Musteri
    {
        public int Id { get; set; }
        public string? KimlikNo { get; set; }
        public string? MusteriAd { get; set; }
        public string? MusteriSoyad { get; set; }
        List<Siparis>? Siparis { get; set; }
        public int IlId { get; set; }
        public il? il { get; set; }
    }
}