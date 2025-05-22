using CRMCallCenter.Models.Transakcje;
using CRMCallCenter.Models.Uzytkownicy;
using System.Transactions;

namespace CRMCallCenter.Models.Klienci
{
    public class Klient
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }
        
        public int ZespolId { get; set; }
        public Zespol Zespol { get; set; }

        public int? PrzypisanyUzytkownikId { get; set; }
        public Uzytkownik? PrzypisanyUzytkownik { get; set; }

        public ICollection<Transakcja> Transakcje { get; set; }
        public ICollection<PolaczenieTelefoniczne> PolaczeniaTelefoniczne { get; set; }

    }
}
