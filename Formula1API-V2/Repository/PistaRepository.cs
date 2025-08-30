using Formula1API_V2.Database;
using Formula1API_V2.Interface;
using Formula1API_V2.Model;
using Microsoft.EntityFrameworkCore;

namespace Formula1API_V2.Repository;

public class PistaRepository : IPistaRepository
{
    private readonly Context _context;

    public PistaRepository(Context context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Pista>> GetAll()
    {
        return await _context.Pista.ToListAsync();
    }

    public async Task<Pista> GetById(int id)
    {
        return await _context.Pista.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<bool> PistaExists(int id)
    {
        return await _context.Pista.AnyAsync(p => p.Id == id);
    }

    public async Task<Pista> Add(Pista pista)
    {
        _context.Pista.Add(pista);
        await _context.SaveChangesAsync();
        return pista;
    }

    public async Task<Pista> Update(Pista pista)
    {
        _context.Entry(pista).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return pista;
    }

    public async Task Delete(Pista pista)
    {
        _context.Pista.Remove(pista);
        await _context.SaveChangesAsync();
    }
}