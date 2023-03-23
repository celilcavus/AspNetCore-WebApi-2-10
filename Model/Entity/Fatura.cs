namespace Model.Entity
{
    public class Fatura
    {
        public int Id { get; set; }
        public int SiporisId { get; set; }
        public Siparis? Siparis { get; set; }
        public DateTime FaturaTarihi { get; set; }
        
    }
}