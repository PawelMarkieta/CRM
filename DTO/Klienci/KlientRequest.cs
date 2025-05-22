namespace CRMCallCenter.DTO.Klienci
{
    public class KlientRequest
    {

        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string? Email {  get; set; }
        public string? Telefon { get; set; }

        public int ZespolId { get; set; }
        public int PrzypisanyUzytkownikId { get; set; }

    }
}
