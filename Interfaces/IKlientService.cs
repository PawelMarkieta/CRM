using CRMCallCenter.DTO.Klienci;

namespace CRMCallCenter.Interfaces
{
    public interface IKlientService
    {

        Task<List<KlientResponse>> PobierzWszystkichAsync();

        Task<KlientResponse?> PobierzPoIdAsync(int id);

        Task<KlientResponse> DodajAsync(KlientRequest request);

        Task<bool> EdytujAsync(int id, KlientRequest request);

        Task<bool> UsunAsync(int id);

    }
}
