using Formula1API_V2.Database;
using Formula1API_V2.Interface;
using Formula1API_V2.Model;
using Microsoft.EntityFrameworkCore;

namespace Formula1API_V2.Repository;

public class ConstrutorRepository : IConstrutorRepository
{
    private readonly Context _context;

    public ConstrutorRepository(Context context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Construtor>> GetAll()
    {
        return await _context.Construtor.ToListAsync();
    }

    public async Task<Construtor> GetById(int id)
    {
        return await _context.Construtor.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> ConstrutorExists(int id)
    {
        return await _context.Construtor.AnyAsync(x => x.Id == id);
    }

    public async Task<Construtor> Add(Construtor construtor)
    {
        _context.Construtor.Add(construtor);
        await _context.SaveChangesAsync();
        return construtor;
    }

    public async Task<Construtor> Update(Construtor construtor)
    {
        _context.Entry(construtor).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return construtor;
    }

    public async Task Delete(Construtor construtor)
    {
        _context.Construtor.Remove(construtor);
        await _context.SaveChangesAsync();
    }
}