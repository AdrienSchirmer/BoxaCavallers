namespace Schirmer_Adrien_Combat_entre_cavallers;

class Program
{
    static void Main()
    {
        var combat = new Combat();
        Console.WriteLine("Benvinguts al torneig!");
        Console.WriteLine("Prem enter per començar amb el registre del combat!");
        Console.ReadLine();
        combat.AfegirBoxejadors();
        combat.CombatEnCurs();
        Console.WriteLine($"{combat.Resultatdelcombat()}");
    }
}