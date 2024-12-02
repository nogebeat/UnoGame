using System;
using System.Collections.Generic;

class CarteUno
{
    public string Couleur { get; set; }
    public string Valeur { get; set; }

    public CarteUno(string couleur, string valeur)
    {
        Couleur = couleur;
        Valeur = valeur;
    }

    public bool EstSpeciale()
    {
        return Valeur == "Passer" || Valeur == "Inverser" || Valeur == "+2" || Valeur == "+4" || Valeur == "Joker";
    }


    public override string ToString()
    {
        
        if (Valeur == "Joker" || Valeur == "+4")
            return $"{Valeur} {Couleur}";

        return $"{Couleur} {Valeur}";
    }
}