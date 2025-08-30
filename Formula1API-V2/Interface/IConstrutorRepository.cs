using Formula1API_V2.Model;

namespace Formula1API_V2.Interface;

public interface IConstrutorRepository
{
    Task<IEnumerable<Construtor>> GetAll();
    
    Task<Construtor> GetById(int id);

    Task<bool> ConstrutorExists(int id);

    Task<Construtor> Add(Construtor construtor);
    
    Task<Construtor> Update(Construtor construtor);
    
    Task Delete(Construtor construtor);
}