namespace Model.Entity
{  
    public class Urun
    {
        public int Id { get; set; }
        public int SiparisUrunId { get; set; }
        public List<SiparisUrun>? SiparisUruns { get; set; }
        public string? UrunAdi { get; set; }
        public int StokMiktari { get; set; }
        public int BirimFiyati { get; set; }
        public int KategoriId { get; set; }  
        public List<Kategori>?  Kategori { get; set; } 
    }   
}