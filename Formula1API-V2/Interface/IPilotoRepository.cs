using Formula1API_V2.Model;

namespace Formula1API_V2.Interface;

public interface IPilotoRepository
{
    Task<IEnumerable<Piloto>> GetAllPilotos();

    Task<Piloto> GetPilotoById(int id);
    
    Task<bool> PilotoExists(int id);
    
   Task<Piloto> AddPiloto(Piloto piloto);
   
   Task<Piloto> UpdatePiloto(Piloto piloto);
   
   Task DeletePiloto(Piloto piloto);
   
}