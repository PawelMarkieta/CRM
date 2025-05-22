using CRMCallCenter.Models.Klienci;
using CRMCallCenter.Models.Uzytkownicy;

namespace CRMCallCenter.Models.Transakcje
{
    public enum EtapTransakcji
    {
        Lead,
        Skontaktowano,
        Spotkanie,
        OfertaWyslana,
        Podpisana,
        Utracona
    }
    public class Transakcja
    {
        public int Id { get; set; }
        public int KlientId { get; set; }
        public Klient Klient { get; set; }
        
        public int ProduktId { get; set; }
        public Produkt Produkt { get; set; }

        public int UtworzonaPrzezId { get; set; }
        public Uzytkownik UtworzonaPrzez { get; set; }

        public EtapTransakcji Etap { get; set; }
        public DateTime DataUtworzenia { get; set; } = DateTime.UtcNow;
        public DateTime? DataPodpisania { get;set; }

        public bool CzyZdalna {  get; set; }

    }
}
