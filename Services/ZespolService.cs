using CRMCallCenter.Data;
using CRMCallCenter.Interfaces;
using CRMCallCenter.Models;
using CRMCallCenter.DTO.Zespoly;
using Microsoft.EntityFrameworkCore;
using CRMCallCenter.Models.Uzytkownicy;





namespace CRMCallCenter.Services
{
    public class ZespolService : IZespolService
    {

        private readonly ApplicationDbContext _context;

        public ZespolService(ApplicationDbContext context)
        {

            _context = context;

        }

        public async Task<List<ZespolResponse>> PobierzWszystkieAsync()
        {

            return await _context.Zespoly
                .Select (z => new ZespolResponse { Id = z.Id, Nazwa = z.Nazwa })
                .ToListAsync();

        }

        public async Task<ZespolResponse?> PobierzPoIdAsync(int id)
        {

            var zespol = await _context.Zespoly.FindAsync(id);
            return zespol == null ? null : new ZespolResponse { Id = id, Nazwa = zespol.Nazwa };

        }

        public async Task<ZespolResponse> DodajAsync(ZespolRequest request)
        {

            var zespol = new Zespol { Nazwa = request.Nazwa };
            _context.Zespoly.Add(zespol);
            await _context.SaveChangesAsync();
            return new ZespolResponse { Id = zespol.Id, Nazwa = zespol.Nazwa };

        }

        public async Task<bool> EdytujAsync(int id, ZespolRequest request)
        {

            var zespol = await _context.Zespoly.FindAsync(id);
            if (zespol == null) return false;

            zespol.Nazwa = request.Nazwa;
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> UsunAsync(int id)
        {

            var zespol = await _context.Zespoly.FindAsync(id);
            if(zespol == null) return false;

            _context.Zespoly.Remove(zespol);
            await _context.SaveChangesAsync();
            return true;

        }



    }
}
