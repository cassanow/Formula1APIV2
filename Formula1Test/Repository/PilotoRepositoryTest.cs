using Formula1Test.Data;
using Formula1Test.Model;
using Microsoft.EntityFrameworkCore;

namespace Formula1Test.Repository;

public class PilotoRepositoryTest : IClassFixture<DatabaseFixture>, IClassFixture<PilotoTest>
{
    private readonly DatabaseFixture _context;
    private readonly PilotoTest _pilotoTest;

    public PilotoRepositoryTest(DatabaseFixture context, PilotoTest pilotoTest)
    {
        _context = context;
        _pilotoTest = pilotoTest;
    }
    
    [Fact]
    public async Task DeveRetornarTodosPilotos()
    {
        var context = _context.CreateContext();
        var piloto = _pilotoTest.Criarpiloto();
        
        context.Piloto.Add(piloto);
        await context.SaveChangesAsync();
        var lista = await context.Piloto.ToListAsync();
        
        Assert.Single(lista);
        Assert.Equal(piloto.Nome, lista[0].Nome);
        
    }

    [Fact]
    public async Task DeveRetornarPilotoPorId()
    {
        var context = _context.CreateContext();
        var piloto = _pilotoTest.Criarpiloto();
        
        context.Piloto.Add(piloto);
        await context.SaveChangesAsync();
        var id = await context.Piloto.FirstOrDefaultAsync(p => p.Id == piloto.Id);
        
        Assert.NotNull(id);
        Assert.Equal(piloto.Id, id.Id);
        
    }
    
}