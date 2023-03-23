namespace Model.Entity
{
    public class Siparis
    {
        public int Id { get; set; }

        public DateTime SiparisTarihi { get; set; }
        public decimal ToplamTutar { get; set; }
        public int SiparisUrunId { get; set; }
        public List<SiparisUrun>? SiparisUrun { get; set; }
        public int KargoFirmasiId { get; set; }
        public KargoFirmasi? KargoFirmasi { get; set; }
        public int FaturaId { get; set; }
        public Fatura? Fatura { get; set; }
        public int MusteriId { get; set; }
        public Musteri? Musteri { get; set; }
        public int SatisTemsilcisiId { get; set; }
        public List<SatisTemsilcisi>? SatisTemsilcisi { get; set; }

    }
}
