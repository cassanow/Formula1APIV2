using Formula1API_V2.Model;

namespace Formula1API_V2.Interface;

public interface IPistaRepository
{
    Task<IEnumerable<Pista>> GetAll();
    
    Task<Pista> GetById(int id);
    
    Task<bool> PistaExists(int id);
    
    Task<Pista> Add(Pista pista);
    
    Task<Pista> Update(Pista pista);
    
    Task Delete(Pista pista);
}