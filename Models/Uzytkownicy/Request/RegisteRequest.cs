namespace CRMCallCenter.Models.Uzytkownicy.Request
{
    public class RegisterRequest
    {

        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public string Haslo { get; set; }

        public int RolaId { get; set; }
        public int? ZespolId { get; set; }
        public int? PrzelozonyId { get; set; }

    }
}
