using System.Security.Cryptography;

namespace Schirmer_Adrien_Combat_entre_cavallers;

public class Combat
{
    private List<Boxejador> _boxejadorscombat = new List<Boxejador>();
    
    public void AfegirBoxejadors()
    {
        for (int i = 1; i <= 2; i++)
        {
            string? Boxejador = "";
            bool faltaafegir = true;
            while (faltaafegir)
            {
                Console.WriteLine($"Ingresa el nom del boxejador n.{i}:");
                Boxejador = Console.ReadLine();
                if (ComprovarSiJaExisteix(Boxejador) == false)
                {
                    Console.WriteLine("Aquest boxejador ja esta inscrit!");
                }
                else
                {
                    faltaafegir = false;
                }
            }
            Console.WriteLine("Cuants cops pot aguantar el boxejador?");
            int Copsqueaguanta = int.Parse(Console.ReadLine());
            _boxejadorscombat.Add(new Boxejador(Boxejador, Copsqueaguanta));
        }
    }

    private bool ComprovarSiJaExisteix(string? nouNom)
    {
        foreach (var boxejador in _boxejadorscombat)
        {
            if (boxejador.Nom == nouNom)
            {
                Console.WriteLine($"Ja existeix aquest boxejador!");
                return false;
            }
        }
        return true;
    }

    public void CombatEnCurs()
    {
        Console.WriteLine("Boxejadors que hi lluitaran");
        foreach (var boxejador in _boxejadorscombat)
        {
            Console.WriteLine($"{boxejador.Nom}, pot aguantar {boxejador.Vida} cops!");
        }
        
        Console.WriteLine($"Preparats, llestos... Ja!");
        Console.WriteLine($"Combat entre {_boxejadorscombat[0].Nom} i {_boxejadorscombat[1].Nom}:");
        int primercop = RandomNumberGenerator.GetInt32(1, 3);
        string? pica;
        if (primercop == 1)
        {
            pica = _boxejadorscombat[0].Nom;
        }
        else
        {
            pica = _boxejadorscombat[1].Nom;
        }

        while (_boxejadorscombat[0].Vida != 0 && _boxejadorscombat[1].Vida != 0)
        {
            string? quirep = null;
            if (pica == _boxejadorscombat[0].Nom) quirep = _boxejadorscombat[1].Nom;
            else if (pica == _boxejadorscombat[1].Nom) quirep = _boxejadorscombat[0].Nom;
            
                int aonpica = RandomNumberGenerator.GetInt32(1, 5);
                int aonnoesdefensa = RandomNumberGenerator.GetInt32(1, 5);
                if (aonnoesdefensa == aonpica)
                {
                    Console.WriteLine($"{pica} pica: Protegit");
                    pica = quirep;
                }
                else
                {
                    switch (aonpica)
                    {
                        case 1:
                            Console.WriteLine($"{pica} pica: Cop a panxa");
                            Treurevida(quirep);
                            pica = quirep;
                            break;
                        case 2:
                            Console.WriteLine($"{pica} pica: Cop a cap");
                            Treurevida(quirep);
                            pica = quirep;
                            break;
                        case 3:
                            Console.WriteLine($"{pica} pica: Cop a esquerra");
                            Treurevida(quirep);
                            pica = quirep;
                            break;
                        case 4:
                            Console.WriteLine($"{pica} pica: Cop a dreta");
                            Treurevida(quirep);
                            pica = quirep;
                            break;
                    }   
                }
            
        }
    }

    public string Resultatdelcombat()
    {
        string? guanyador = "";
        foreach (var boxejador in _boxejadorscombat)
        {
            if (boxejador.Vida > 0)
            {
                guanyador = boxejador.Nom;
            }
            else
            {
                Console.WriteLine($"{boxejador.Nom} CAU!");
            }
        }

        return $"GUANYADOR: {guanyador}";
    }

    private void Treurevida(string? quirep)
    {
        foreach (var boxejador in _boxejadorscombat)
        {
            if (quirep == boxejador.Nom)
            {
                boxejador.Vida--;
            }
        }
    }
}