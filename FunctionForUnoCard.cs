using System;
using System.Collections.Generic;

class PaquetUno
{
    private List<CarteUno> cartes;


    public PaquetUno(int language)
    {
        cartes = new List<CarteUno>();
        GenererPaquet(language);
    }

    private void GenererPaquet(int language)
    {

    string[] couleurs;
    string[] cartesSpeciales;

    if (language == 2) {
        couleurs = new string[] { "Rouge", "Bleu", "Vert", "Jaune" };
        cartesSpeciales = new string[] { "Passer", "Inverser", "+2" };
    } else if (language == 3) {
        couleurs = new string[] { "Red", "Blue", "Green", "Yellow" };
        cartesSpeciales = new string[] { "Pass", "Reverse", "+2" };
    } else {
        Console.WriteLine("Langue inconnue. Utilisation des paramètres par défaut (Français).");
        couleurs = new string[] { "Rouge", "Bleu", "Vert", "Jaune" };
        cartesSpeciales = new string[] { "Passer", "Inverser", "+2" };
    }
        foreach (string couleur in couleurs)
        {
            cartes.Add(new CarteUno(couleur, "0"));
            for (int i = 1; i <= 9; i++)
            {
                cartes.Add(new CarteUno(couleur, i.ToString()));
                cartes.Add(new CarteUno(couleur, i.ToString()));
            }

            foreach (string speciale in cartesSpeciales)
            {
                cartes.Add(new CarteUno(couleur, speciale));
                cartes.Add(new CarteUno(couleur, speciale));
            }
        }

        for (int i = 0; i < 4; i++)
        {
            cartes.Add(new CarteUno("Joker", "+4"));
            cartes.Add(new CarteUno("Joker", "Joker"));
        }
    }

    public void Melanger()
    {
        Random aleatoire = new Random();
        for (int i = 0; i < cartes.Count; i++)
        {
            int j = aleatoire.Next(cartes.Count);
            (cartes[i], cartes[j]) = (cartes[j], cartes[i]);
        }
    }

    public CarteUno DistribuerCarte()
    {
        if (cartes.Count == 0)
            throw new InvalidOperationException("Le paquet est vide !");

        CarteUno carte = cartes[0];
        cartes.RemoveAt(0);
        return carte;
    }
}
