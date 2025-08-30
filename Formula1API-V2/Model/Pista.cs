using System.ComponentModel.DataAnnotations;

namespace Formula1API_V2.Model;

public class Pista
{
    [Key]
    public int Id { get; set; }
    
    public string Nome { get; set; }

    public string Pais {get; set;}
    
    public string MaiorVencedor { get; set; }
}