namespace Model.Entity
{
    public class Kategori
    {
        public int Id { get; set; }
        public int UrunId { get; set; }
        public Urun? Urun { get; set; }
        public string? KategoriAdi { get; set; }
    }
}