using System;
using System.Collections.Generic;

class Joueur
{
    public string Nom { get; set; }
    public List<CarteUno> Main { get; private set; }

    public Joueur(string nom)
    {
        Nom = nom;
        Main = new List<CarteUno>();
    }

     public void RecevoirCarte(CarteUno carte)
    {
        Main.Add(carte);
    }

     public void Piocher(PaquetUno paquet, int nombre)
    {
        for (int i = 0; i < nombre; i++)
        {
            RecevoirCarte(paquet.DistribuerCarte());
        }
    }

      public void AfficherMain(int language = default)
    {
        if (language == 2) {
            Console.WriteLine($"{Nom} a les cartes suivantes :");
        } else {
            Console.WriteLine($"{Nom} has the following cards :");
        }
        for (int i = 0; i < Main.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {Main[i]}");
        }
    }

    public CarteUno JouerCarte(int index)
    {
        if (index < 0 || index >= Main.Count)
        {
            throw new ArgumentException("Index invalide !");
        }
        CarteUno carte = Main[index];
        Main.RemoveAt(index);
        return carte;
    }

    public List<CarteUno> CartesSpecifiques(string valeur) {
            {
                List<CarteUno> cartesTrouvees = new List<CarteUno>();
                foreach (var carte in Main)
                {
                    if (carte.Valeur == valeur)
                    {
                        cartesTrouvees.Add(carte);
                    }
                }
                return cartesTrouvees;
            }
    }

    public static bool VerifierVictoire(Joueur joueur) {
        return joueur.Main.Count == 0;
    }

}