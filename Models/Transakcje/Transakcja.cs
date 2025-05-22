using CRMCallCenter.Models.Klienci;
using CRMCallCenter.Models.Uzytkownicy;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMCallCenter.Models.Transakcje
{
    public enum Status
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
        
        public int UzytkownikId { get; set; }
        public Uzytkownik Uzytkownik { get; set; }

        public Status Status { get; set; }
        public DateTime DataUtworzenia { get; set; } = DateTime.UtcNow;
        public decimal Kwota {  get; set; }
        public string? Opis { get; set; }

        public bool CzyNaMiejscu {  get; set; } //true = u klienta, false = zdalnie

    }
}
