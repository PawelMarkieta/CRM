namespace CRMCallCenter.DTO.Klienci
{
    public class KlientResponse
    {

        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string? Email { get; set; } 
        public string? Telefon { get; set; }
        public string ZespolNazwa { get; set; }
        public string? PrzypisanyDo {  get; set; }


    }
}
