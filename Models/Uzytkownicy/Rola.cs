namespace CRMCallCenter.Models.Uzytkownicy
{
    public class Rola
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }

        public ICollection<Uzytkownik> Uzytkownicy { get; set; }
    }
}
