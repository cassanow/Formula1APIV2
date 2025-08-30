using System.ComponentModel.DataAnnotations;

namespace Formula1API_V2.Model;

public class Piloto
{
    [Key]
    public int Id { get; set; }
    
    public string Nome { get; set; }
    
    public string Nacionalidade { get; set; }
    
    public DateTime DataNascimento { get; set; }

    public int Vitorias { get; set; }
    
    public int Titulos { get; set; }

    public Construtor Construtor { get; set; }
}