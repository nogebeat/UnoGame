using System;
using System.Collections.Generic;

class Programme
{
    static void Main(string[] args)
    {
        int language = Menu.Deadstroke_Menu();
        int lang = language;
        Menu.AfficherMenu(language);
        Console.Clear();
        if (language == 2) {
            Console.WriteLine("Bienvenue dans le jeu Uno !");
            Console.WriteLine("Entrez les noms des joueurs (2 à 4), séparés par des espaces :");            
        } else {
            Console.WriteLine("Welcome to the Uno game!");
            Console.WriteLine("Enter the names of the players (2 to 4), separated by spaces:");
        }
        string? saisie = Console.ReadLine();
        if (saisie == null)
            {
                Console.WriteLine("Entrée invalide.");
            }

        string[] nomsJoueurs = saisie!.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (nomsJoueurs.Length == 0)
            {
                Console.WriteLine("Entrée invalide.");
            }
        bool continuer = true;
        while (continuer)
        {
            if (nomsJoueurs.Length < 2 || nomsJoueurs.Length > 4)
            {
                if (language == 2) {
                    Console.WriteLine("Erreur : Vous devez avoir entre 2 et 4 joueurs.");
                    Console.WriteLine("Veuillez réessayer.");                    
                } else {
                    Console.WriteLine("Error : You must have between 2 and 4 players.");
                    Console.WriteLine("Please try again.");
                }
                string? input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("Entrée invalide.");
                }
                nomsJoueurs = input!.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (nomsJoueurs.Length == 0)
                {
                    Console.WriteLine("Entrée invalide.");
                }
            }
            else
            {
                continuer = false;
            }
        }

        List<Joueur> joueurs = new List<Joueur>();
        foreach (string nom in nomsJoueurs)
        {
            joueurs.Add(new Joueur(nom));
        }

        PaquetUno paquet = new PaquetUno(language);
        paquet.Melanger();

        foreach (var joueur in joueurs)
        {
            joueur.Piocher(paquet, 5);
        }

        if (language == 2) {
            Console.WriteLine("\nTirage de la première carte pour le tapis...");            
        } else {
            Console.WriteLine("\nDrawing the first card for the table...");
        }
        CarteUno carteTapis;
        do
        {
            carteTapis = paquet.DistribuerCarte();
        } while (carteTapis.EstSpeciale());

        if (language == 2) {
            Console.WriteLine($"La première carte sur le tapis est : {carteTapis}");        
        } else {
            Console.WriteLine($"The first card on the table is: {carteTapis}");
        }

        string couleurCourante = carteTapis.Couleur;
        string valeurCourante = carteTapis.Valeur;

        int joueurActuel = 0;
        int sensDeJeu = 1;
        int cartesAPiocher = 0;

        while (true)
        {
            Joueur joueur = joueurs[joueurActuel];
            if (language == 2) {
                Console.WriteLine($"\nC'est au tour de {joueur.Nom}.");
                Console.WriteLine($"Carte sur le tapis : {carteTapis}");
            } else {
                Console.WriteLine($"\nIt's {joueur.Nom}'s turn.");
                Console.WriteLine($"Card on the table: {carteTapis}");
            }

            if (Joueur.VerifierVictoire(joueur))
            {
                if (language == 2) {
                    Console.WriteLine($"{joueur.Nom} a gagné ! Félicitations !");
                } else {
                    Console.WriteLine($"{joueur.Nom} has won! Congratulations!");
                }
                break;
            }
            if (cartesAPiocher > 0)
            {
                if (language == 2) {
                Console.WriteLine($"Vous devez piocher {cartesAPiocher} carte(s).");
                } else {
                Console.WriteLine($"You must draw {cartesAPiocher} card(s).");
            }                
            }
            joueur.AfficherMain(language);

            bool carteValide = false;
            while (!carteValide)
            {
                if (language == 2) {
                    Console.WriteLine("Choisissez une ou plusieurs cartes à jouer (entrez les numéros séparés par des virgules) ou tapez 0 pour piocher :");                    
                } else {
                    Console.WriteLine("Choose one or more cards to play (enter the numbers separated by commas) or type 0 to draw:");
                }
                string? choix = Console.ReadLine();
                if (choix == null)
                {
                    Console.WriteLine("Entrée invalide.");
                }

                if (choix == "0")
                {
                    if (cartesAPiocher > 0)
                    {
                        if (language == 2) {
                            Console.WriteLine($"{joueur.Nom} doit piocher {cartesAPiocher} cartes !");                        
                        } else {
                            Console.WriteLine($"{joueur.Nom} must draw {cartesAPiocher} cards!");
                        }
                        joueur.Piocher(paquet, cartesAPiocher);
                        cartesAPiocher = 0;
                    }
                    else
                    {
                        if (language == 2) {
                            Console.WriteLine($"{joueur.Nom} pioche une carte.");                        
                        } else {
                            Console.WriteLine($"{joueur.Nom} draws a card.");
                        }
                        joueur.Piocher(paquet, 1);
                    }
                    carteValide = true;
                }
                else
                {
                    string[] indicesChoisis = choix!.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    if (indicesChoisis.Length == 0)
                    {
                        Console.WriteLine("Entrée invalide.");
                    }
                    List<CarteUno> cartesJouees = new List<CarteUno>();
                    bool choixValide = true;

                    foreach (string indiceStr in indicesChoisis)
                    {
                        if (int.TryParse(indiceStr.Trim(), out int index) && index > 0 && index <= joueur.Main.Count)
                        {
                            cartesJouees.Add(joueur.Main[index - 1]);
                        }
                        else
                        {
                            if (language == 2) {
                                Console.WriteLine("Choix invalide. Essayez à nouveau.");                            
                            } else {
                                Console.WriteLine("Invalid choice. Try again.");
                            }
                            joueur.AfficherMain(language);
                            choixValide = false;
                            break;
                        }
                    }

                    if (!choixValide)
                        continue;

                    if (ValiderCartesJouees(cartesJouees, carteTapis, couleurCourante, valeurCourante))
                    {
                        if (language == 2) {
                            Console.WriteLine($"{joueur.Nom} joue : {string.Join(", ", cartesJouees)}");                        
                        } else {
                            Console.WriteLine($"{joueur.Nom} plays: {string.Join(", ", cartesJouees)}");
                        }

                        foreach (CarteUno carte in cartesJouees)
                        {
                            joueur.Main.Remove(carte);
                        }

                        CarteUno derniereCarte = cartesJouees[^1];
                        carteTapis = derniereCarte;
                        couleurCourante = derniereCarte.Couleur;
                        valeurCourante = derniereCarte.Valeur;

                        if (derniereCarte.Valeur == "Passer")
                        {
                            while (true) 
                            {
                                joueurActuel = (joueurActuel + sensDeJeu + joueurs.Count) % joueurs.Count; // Passe au joueur suivant
                                Joueur joueurSuivant = joueurs[joueurActuel];

                             
                                List<CarteUno> cartesPasser = joueurSuivant.CartesSpecifiques("Passer");

                                if (cartesPasser.Count > 0)
                                {
                                    if (language == 2) {
                                        Console.WriteLine($"{joueurSuivant.Nom} peut contrer avec une carte 'Passer' pour passer le joueur suivant !");
                                        Console.WriteLine("Cartes disponibles :");
                                    } else {
                                        Console.WriteLine($"{joueurSuivant.Nom} can counter with a 'Passer' card to pass the next player!");
                                        Console.WriteLine("Available cards:");
                                    }
                                    
                                    for (int i = 0; i < cartesPasser.Count; i++)
                                    {
                                        Console.WriteLine($"  {i + 1}. {cartesPasser[i]}");
                                    }
                                    
                                    if (language == 2) {
                                        Console.WriteLine("Voulez-vous jouer une carte 'Passer' pour contrer ? (Entrez le numéro de la carte ou 0 pour passer)");
                                    } else {
                                        Console.WriteLine("Do you want to play a 'Passer' card to counter? (Enter the number of the card or 0 to pass)");
                                    }
                                    
                                    string? choixContre = Console.ReadLine();
                                    if (choixContre == null)
                                    {
                                        Console.WriteLine("Entrée invalide.");
                                    }

                                    if (int.TryParse(choixContre, out int indexContre) && indexContre > 0 && indexContre <= cartesPasser.Count)
                                    {
                                        CarteUno cartePasser = cartesPasser[indexContre - 1];
                                        joueurSuivant.Main.Remove(cartePasser);
                                        carteTapis = cartePasser;
                                        couleurCourante = cartePasser.Couleur;
                                        valeurCourante = cartePasser.Valeur;
                                        
                                        if (language == 2) {
                                            Console.WriteLine($"{joueurSuivant.Nom} joue {cartePasser} et passe le joueur suivant !");
                                        } else {
                                            Console.WriteLine($"{joueurSuivant.Nom} plays {cartePasser} and passes the next player!");
                                        }
                                        continue;
                                    }
                                    else
                                    {
                                        if (language == 2) {
                                            Console.WriteLine($"{joueurSuivant.Nom} choisit de ne pas jouer de carte 'Passer' et est passé.");
                                        } else {
                                            Console.WriteLine($"{joueurSuivant.Nom} chooses not to play a 'Passer' card and passes.");
                                        }
                                        break; 
                                    }
                                }
                                else
                                {
                                    if (language == 2) {
                                        Console.WriteLine($"{joueurSuivant.Nom} n'a pas de carte 'Passer' et est passé.");
                                    } else {
                                        Console.WriteLine($"{joueurSuivant.Nom} has no 'Passer' card and passes.");
                                    }
                                    break;
                                }
                            }
                        }

                        else if (derniereCarte.Valeur == "Inverser")
                        {
                            sensDeJeu *= -1;
                            if (language == 2) {
                                Console.WriteLine("Le sens du jeu est inversé !");
                            } else {
                                Console.WriteLine("The game's direction is reversed!");
                            }
                            
                        }

                        else if (derniereCarte.Valeur == "+2" || derniereCarte.Valeur == "+4")
                        {
                            int valeurAjoutee = derniereCarte.Valeur == "+2" ? 2 : 4;
                            cartesAPiocher += valeurAjoutee;

                            if (derniereCarte.Valeur == "+4")
                            {
                                if (language == 2) {
                                    couleurCourante = ChoisirCouleurFr(language);
                                } else {
                                    couleurCourante = ChoisirCouleurEn(language);
                                }
                                if (language == 2) {
                                    Console.WriteLine($"La nouvelle couleur choisie est : {couleurCourante}");
                                } else {
                                    Console.WriteLine($"The new color chosen is: {couleurCourante}");
                                }
                                
                            }

                            while (true)
                            {
                                joueurActuel = (joueurActuel + sensDeJeu + joueurs.Count) % joueurs.Count; 
                                Joueur joueurSuivant = joueurs[joueurActuel];

                                List<CarteUno> cartesSpecifiques = joueurSuivant.CartesSpecifiques("+2");
                                cartesSpecifiques.AddRange(joueurSuivant.CartesSpecifiques("+4"));

                                if (cartesSpecifiques.Count > 0)
                                {
                                    if (language == 2) {
                                        Console.WriteLine($"{joueurSuivant.Nom} peut jouer une carte spéciale pour contrer !");
                                        Console.WriteLine("Cartes disponibles :");
                                    } else {
                                        Console.WriteLine($"{joueurSuivant.Nom} can play a special card to counter!");
                                        Console.WriteLine("Available cards:");
                                    }
                                    
                                    for (int i = 0; i < cartesSpecifiques.Count; i++)
                                    {
                                        Console.WriteLine($"  {i + 1}. {cartesSpecifiques[i]}");
                                    }

                                    if (language == 2) {
                                        Console.WriteLine("Voulez-vous jouer une carte pour contrer ? (Entrez le numéro de la carte ou 0 pour passer)");
                                    } else {
                                        Console.WriteLine("Do you want to play a card to counter? (Enter the number of the card or 0 to pass)");
                                    }
                                    string? choixContre = Console.ReadLine();
                                    if (choixContre == null)
                                    {
                                        Console.WriteLine("Entrée invalide.");
                                    }

                                    if (int.TryParse(choixContre, out int indexContre) && indexContre > 0 && indexContre <= cartesSpecifiques.Count)
                                    {
                                        CarteUno carteContre = cartesSpecifiques[indexContre - 1];
                                        joueurSuivant.Main.Remove(carteContre);
                                        carteTapis = carteContre;
                                        couleurCourante = carteContre.Couleur;
                                        valeurCourante = carteContre.Valeur;

                                        valeurAjoutee = carteContre.Valeur == "+2" ? 2 : 4;
                                        cartesAPiocher += valeurAjoutee;

                                        if (language == 2) {
                                            Console.WriteLine($"{joueurSuivant.Nom} contre avec {carteContre} !");
                                        } else {
                                            Console.WriteLine($"{joueurSuivant.Nom} contre with {carteContre} !");
                                        }
                                        continue;
                                    }
                                    else
                                    {
                                        if (language == 2) {
                                            Console.WriteLine($"{joueurSuivant.Nom} choisit de ne pas contrer.");
                                        } else {
                                            Console.WriteLine($"{joueurSuivant.Nom} chooses not to counter.");
                                        }
                                        break;
                                    }
                                }
                                else
                                {
                                    if (language == 2) {
                                        Console.WriteLine($"{joueurSuivant.Nom} n'a pas de carte spéciale et doit piocher {cartesAPiocher} cartes.");
                                    } else {
                                        Console.WriteLine($"{joueurSuivant.Nom} doesn't have any special card and must draw {cartesAPiocher} cards.");
                                    }
                            
                                    joueurSuivant.Piocher(paquet, cartesAPiocher);
                                    cartesAPiocher = 0;
                                    break;
                                }
                            }
                        }

                        else if (derniereCarte.Valeur == "Joker")
                        {
                            if (language == 2) {
                                couleurCourante = ChoisirCouleurFr(language);
                            } else {
                                couleurCourante = ChoisirCouleurEn(language);
                            }
                            if (language == 2) {
                                Console.WriteLine($"La nouvelle couleur choisie est : {couleurCourante}");
                            } else {
                                Console.WriteLine($"The new color chosen is: {couleurCourante}");
                            }
                            
                        }

                        carteValide = true;
                    }
                    else
                    {
                        if (language == 2) {
                            Console.WriteLine("Les cartes sélectionnées ne sont pas valides ensemble. Essayez à nouveau.");
                        } else {
                            Console.WriteLine("The selected cards are not valid together. Try again.");
                        }
                        joueur.AfficherMain(language);
                    }
                }
            }
            
             if (joueur.Main.Count == 1) {
                if (language == 2) {
                    Console.WriteLine($"{joueur.Nom} a une seule carte restante ! Dites 'Uno' !");
                } else {
                    Console.WriteLine($"{joueur.Nom} has only one card left! Say 'Uno'!");
                }

                string? unoChoix = Console.ReadLine();
                if (unoChoix == null)
                {
                    Console.WriteLine("Entrée invalide.");
                }
                if (unoChoix.ToLower() != "uno")
                {
                    if (language == 2) {
                        Console.WriteLine($"{joueur.Nom} a oublié de dire 'Uno' et doit piocher 2 cartes !");
                    } else {
                        Console.WriteLine($"{joueur.Nom} forgot to say 'Uno' and must draw 2 cards!");
                    }
                    joueur.Piocher(paquet, 2);  // le joueur + 2 cartes
                }
            }
            
            if (cartesAPiocher > 0)
            {
                joueurActuel = (joueurActuel + sensDeJeu + joueurs.Count) % joueurs.Count;
                Joueur joueurSuivant = joueurs[joueurActuel];
                if (language == 2) {
                    Console.WriteLine($"{joueurSuivant.Nom} doit piocher {cartesAPiocher} cartes.");
                } else {
                    Console.WriteLine($"{joueurSuivant.Nom} must draw {cartesAPiocher} cards.");
                }
                
                joueurSuivant.Piocher(paquet, cartesAPiocher);
                cartesAPiocher = 0;
            }

            joueurActuel = (joueurActuel + sensDeJeu + joueurs.Count) % joueurs.Count;
        }
    }

    static bool ValiderCartesJouees(List<CarteUno> cartesJouees, CarteUno carteTapis, string couleurCourante, string valeurCourante)
    {
        if (cartesJouees.Count == 0)        
            return false;

        CarteUno premiereCarte = cartesJouees[0];
        if (premiereCarte.Couleur != couleurCourante && premiereCarte.Valeur != valeurCourante && premiereCarte.Couleur != "Joker")
            return false;

        string valeurCommune = premiereCarte.Valeur;
        foreach (var carte in cartesJouees)
        {
            if (carte.Valeur != valeurCommune)
                return false;
        }

        return true;
    }

    static string ChoisirCouleurFr(int language)
    {
        string[] couleurs = { "Rouge", "Bleu", "Vert", "Jaune" };
        int choixCouleur;

        do
        {
            if (language == 2) {
                Console.WriteLine("Entrez une couleur (0: Rouge, 1: Bleu, 2: Vert, 3: Jaune):");
            } else {
                Console.WriteLine("Enter a color (0: Red, 1: Blue, 2: Green, 3: Yellow):");
            }
        } while (!int.TryParse(Console.ReadLine(), out choixCouleur) || choixCouleur < 0 || choixCouleur > 3);

        return couleurs[choixCouleur];
    }

    static string ChoisirCouleurEn(int language)
    {
        string[] couleurs = { "Red", "Blue", "Green", "Yellow" };
        int choixCouleur;

        do
        {
            if (language == 2) {
                Console.WriteLine("Entrez une couleur (0: Rouge, 1: Bleu, 2: Vert, 3: Jaune):");
            } else {
                Console.WriteLine("Enter a color (0: Red, 1: Blue, 2: Green, 3: Yellow):");
            }
        } while (!int.TryParse(Console.ReadLine(), out choixCouleur) || choixCouleur < 0 || choixCouleur > 3);

        return couleurs[choixCouleur];
    }
}
