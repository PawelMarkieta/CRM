using CRMCallCenter.DTO.Zespoly;

namespace CRMCallCenter.Interfaces
{
    public interface IZespolService
    {

        Task<List<ZespolResponse>> PobierzWszystkieAsync();
        Task<ZespolResponse?> PobierzPoIdAsync(int id);
        Task<ZespolResponse> DodajAsync(ZespolRequest request);
        Task<bool> EdytujAsync(int id, ZespolRequest request);
        Task<bool> UsunAsync(int id);

    }
}
