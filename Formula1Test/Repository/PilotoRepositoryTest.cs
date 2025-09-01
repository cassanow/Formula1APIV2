using Formula1API_V2.Model;
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
    
    [Fact]
    public async Task DeveRetornarPilotoExistente()
    {
        var context = _context.CreateContext();
        var piloto = _pilotoTest.Criarpiloto();
        
        context.Piloto.Add(piloto);
        await context.SaveChangesAsync();
        var pilotoExiste = await context.Piloto.AnyAsync(p => p.Id == piloto.Id);
        Assert.True(pilotoExiste);
    }

    [Fact]
    public async Task DeveAdicionarPiloto()
    {
        var context = _context.CreateContext();
        var piloto = _pilotoTest.Criarpiloto();
        
        context.Piloto.Add(piloto);
        await context.SaveChangesAsync();
        
        Assert.Equal(1, context.Piloto.Count());
    }
    
    [Fact]
    public async Task DeveAtualizarPiloto()
    {
        var context = _context.CreateContext();
        var piloto = _pilotoTest.Criarpiloto();
        
        context.Piloto.Add(piloto);
        await context.SaveChangesAsync();

        var updateContext = _context.CreateContext();
        var pilotoAtualizado = new Piloto
        {
            Id = piloto.Id,
            Nome = piloto.Nome,
            Nacionalidade = piloto.Nacionalidade,
            DataNascimento = piloto.DataNascimento,
            Vitorias = 10,
            Titulos = 1,
            Construtor = null
        };
        updateContext.Entry(pilotoAtualizado).State = EntityState.Modified;
        await context.SaveChangesAsync();
        
        Assert.Equal(1, context.Piloto.Count());
        
    }

    [Fact]
    public async Task DeveDeletarUmPiloto()
    {
        var context = _context.CreateContext();
        var piloto = _pilotoTest.Criarpiloto();
        
        context.Piloto.Add(piloto);
        await context.SaveChangesAsync();
        context.Remove(piloto);
        await context.SaveChangesAsync();
        
        Assert.Equal(0, context.Piloto.Count());
    }
}