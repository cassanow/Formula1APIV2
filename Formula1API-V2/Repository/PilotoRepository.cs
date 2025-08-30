using Formula1API_V2.Database;
using Formula1API_V2.Interface;
using Formula1API_V2.Model;
using Microsoft.EntityFrameworkCore;

namespace Formula1API_V2.Repository;

public class PilotoRepository : IPilotoRepository
{
    private readonly Context _context;

    public PilotoRepository(Context context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Piloto>> GetAllPilotos()
    {
        return await _context.Piloto.ToListAsync();
    }

    public async Task<Piloto> GetPilotoById(int id)
    {
        return await _context.Piloto.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> PilotoExists(int id)
    {
        return await _context.Piloto.AnyAsync(x => x.Id == id);
    }

    public async Task<Piloto> AddPiloto(Piloto piloto)
    {
        _context.Piloto.Add(piloto);
        await _context.SaveChangesAsync();
        return piloto;
    }

    public async Task<Piloto> UpdatePiloto(Piloto piloto)
    {
        _context.Piloto.Update(piloto);
        await _context.SaveChangesAsync();
        return piloto;
    }

    public async Task DeletePiloto(Piloto piloto)
    {
        _context.Piloto.Remove(piloto);
        await _context.SaveChangesAsync();
    }
}