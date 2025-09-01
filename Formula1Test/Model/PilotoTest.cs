using Formula1API_V2.Model;

namespace Formula1Test.Model;

public class PilotoTest
{
    public Piloto Criarpiloto()
    {
        return new Piloto
        {
            Id = 1,
            Nome = "Piloto",
            Nacionalidade = "Brasil",
            DataNascimento = DateTime.Now,
            Vitorias = 2,
            Titulos = 0,
            Construtor = null
        };
    }
}