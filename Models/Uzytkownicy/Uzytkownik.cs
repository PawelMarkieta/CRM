namespace CRMCallCenter.Models.Uzytkownicy
{
    public class Uzytkownik
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public string HasloHash { get; set; }

        public int RolaId { get; set; }
        public Rola Rola { get; set; }

        public int? ZespolId { get; set; }
        public Zespol? Zespol { get; set; }

        public int? PrzelozonyId { get; set; }
        public Uzytkownik? Przelozony { get; set; }

        public ICollection<Uzytkownik> Podwladni { get; set; } = new List<Uzytkownik>();
    }
}
