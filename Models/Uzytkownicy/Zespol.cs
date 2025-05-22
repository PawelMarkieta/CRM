using CRMCallCenter.Models.Klienci;

namespace CRMCallCenter.Models.Uzytkownicy
{
    public class Zespol
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }

        public ICollection<Uzytkownik> Uzytkownicy { get; set; }
        public ICollection<Klient> Klienci { get; set; }
    }
}
