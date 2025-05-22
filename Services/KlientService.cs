using CRMCallCenter.Data;
using CRMCallCenter.DTO.Klienci;
using CRMCallCenter.Interfaces;
using CRMCallCenter.Migrations;
using CRMCallCenter.Models;
using CRMCallCenter.Models.Klienci;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CRMCallCenter.Services
{
    public class KlientService : IKlientService
    {

        private readonly ApplicationDbContext _context;

        public KlientService(ApplicationDbContext context) 
        { 
            _context = context; 
        }

        public async Task<List<KlientResponse>> PobierzWszystkichAsync()
        {
            return await _context.Klienci
                .Include( k => k.Zespol)
                .Include( k => k.Zespol)
                .Select( k => new KlientResponse
                {
                    Id = k.Id,
                    Imie = k.Imie,
                    Nazwisko = k.Nazwisko,
                    Email = k.Email,
                    Telefon = k.Telefon,
                    ZespolNazwa = k.Zespol.Nazwa,
                    PrzypisanyDo = k.PrzypisanyUzytkownik != null ? $"{k.PrzypisanyUzytkownik.Imie} {k.PrzypisanyUzytkownik.Nazwisko}" : null

                })
                .ToListAsync();
        }

        public async Task<KlientResponse?> PobierzPoIdAsync(int id)
        {

            var k = await _context.Klienci
                .Include (x => x.Zespol)
                .Include (x => x.PrzypisanyUzytkownik)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (k == null) return null;

            return new KlientResponse
            {
                Id = k.Id,
                Imie = k.Imie,
                Nazwisko = k.Nazwisko,
                Email = k.Email,
                Telefon = k.Telefon,
                ZespolNazwa = k.Zespol.Nazwa,
                PrzypisanyDo = k.PrzypisanyUzytkownik != null ? $"{k.PrzypisanyUzytkownik.Imie} {k.PrzypisanyUzytkownik.Nazwisko}" : null
            };

        }

        public async Task<KlientResponse> DodajAsync(KlientRequest request)
        {
            var klient = new Klient
            {
                Imie = request.Imie,
                Nazwisko = request.Nazwisko,
                Email = request.Email,
                Telefon = request.Telefon,
                ZespolId = request.ZespolId,
                PrzypisanyUzytkownikId = request.PrzypisanyUzytkownikId
            };

            _context.Klienci.Add(klient);
            await _context.SaveChangesAsync();

            return await PobierzPoIdAsync(klient.Id) ?? throw new Exception("Błąd przy dodawaniu klienta");
        }

        public async Task<bool> EdytujAsync(int id, KlientRequest request)
        {

            var klient = await _context.Klienci.FindAsync(id);
            if (klient == null) return false;

            klient.Imie = request.Imie;
            klient.Nazwisko = request.Nazwisko;
            klient.Email = request.Email;
            klient.Telefon =  request.Telefon;
            klient.ZespolId = request.ZespolId;
            klient.PrzypisanyUzytkownikId = request.PrzypisanyUzytkownikId;

            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> UsunAsync(int id)
        {

            var klient = await _context.Klienci.FindAsync(id);
            if (klient == null) return false;

            _context.Klienci.Remove(klient);
            await _context.SaveChangesAsync();
            return true;
        
        }


    }
}
