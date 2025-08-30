using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formula1API_V2.Model;

public class Construtor
{
    [Key]
    public int Id { get; set; }
    
    public string Nome { get; set; }
    
    public string Nacionalidade { get; set; }
    
    public int Vitorias { get; set; }
    
    public int Titulos  { get; set; }
    
    public int PilotoId { get; set; }
    
    public List<Piloto> Pilotos { get; set; }   
}