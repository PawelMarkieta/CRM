using CRMCallCenter.Models.Uzytkownicy;

namespace CRMCallCenter.Models.Klienci
{
    public enum StatusPolaczenia
    {
        Odebrane,
        Nieodebrane,
        WiadomoscGlosowa,
        Odrzucone
    }
    public class PolaczenieTelefoniczne
    {

        public int Id { get; set; }
        public int KlientId { get; set; }
        public Klient Klient { get; set; }

        public int UzytkownikId { get; set; }
        public Uzytkownik Uzytkownik { get; set; }

        public int CzasTrwaniaSekundy { get; set; }
        public StatusPolaczenia Status {  get; set; }
        public bool CzyNagrane { get; set; }
        public string? UrlNagrania { get; set; }
        public string? Notatka {  get; set; }

        public DateTime DataUtworzenia { get; set; } = DateTime.UtcNow;

    }
}
