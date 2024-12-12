
namespace Schirmer_Adrien_Combat_entre_cavallers;

public class Boxejador
{
    public string? Nom { get; set; }
    public int Vida { get; set; }

    public Boxejador(string? nomboxejador, int copsqueaguanta)
    {
        Nom = nomboxejador;
        Vida = copsqueaguanta;
    }
}