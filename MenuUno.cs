using System;
using System.Collections.Generic;

public class Menu {
 public static int Deadstroke_Menu()
    {
        int value = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t BIENVENUE SUR LA TABLE CHER JOUEURS!\n ");
            Console.WriteLine("\t\t\t\t\t\t   WELCOME TO THE TABLE PLAYERS!\n");
            Console.WriteLine("\n\n\t\t\t\tFrançais : Veuillez choisir une langue (1: Français, 2: Anglais) ");
            Console.WriteLine("\n\n\n\n\n\t\t\t\t\t\t\t\tOR | OU\n\n\n");
            Console.WriteLine("\n\n\t\t\t\tEnglish : Please choose a language (1: French, 2: English):");
            Console.Write("\n\n\t\t\t\tChoice | Choix : ");

            string input = Console.ReadLine();

            if (int.TryParse(input, out int language))
            {
                if (language == 1)
                {
                    value = 2;
                    break;
                }
                else if (language == 2)
                {
                    value = 3;
                    break;
                }
                else
                {
                    Console.WriteLine("Choix invalide. Veuillez entrer 1 pour Français ou 2 pour Anglais.");
                }
            }
            else
            {
                Console.WriteLine("Entrée invalide. Veuillez entrer un nombre (1 ou 2).");
            }
        }

        return value;
    }

    public static void AfficherMenu(int language)
    {   
        Random random = new Random();
        string[] colors = Enum.GetNames(typeof(ConsoleColor));
        
        if (language == 2) 
        {
            while (true)
            {

                Console.Clear();
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colors[random.Next(colors.Length)]);
                Console.WriteLine("\t\t\t\t\t BIENVENUE DANS LE JEU UNO VIA TERMINAL :) !\n");
                Console.WriteLine("\t\t\t\t\t+-----------------------------------------+");
                Console.WriteLine("\t\t\t\t\t|      M     M  EEEEE  N   N  U   U       | ");
                Console.WriteLine("\t\t\t\t\t|      MM   MM  E      NN  N  U   U       |");
                Console.WriteLine("\t\t\t\t\t|      M M M M  EEEE   N N N  U   U       |");
                Console.WriteLine("\t\t\t\t\t|      M  M  M  E      N  NN  U   U       |");
                Console.WriteLine("\t\t\t\t\t|      M     M  EEEEE  N   N   UUU        |");
                Console.WriteLine("\t\t\t\t\t+-----------------------------------------+");
                Thread.Sleep(500);
                Console.ResetColor();
                Console.WriteLine("\t\t\t\t\t+-----------------------------------------+");
                Console.WriteLine("\t\t\t\t\t|       Choisissez une option             |");
                Console.WriteLine("\t\t\t\t\t|    1. Règles du Jeu                     |");
                Console.WriteLine("\t\t\t\t\t|    2. Jouer                             |");
                Console.WriteLine("\t\t\t\t\t|    3. Réalisateurs du projet            |");
                Console.WriteLine("\t\t\t\t\t|    4. Quitter le jeu                    |");
                Console.WriteLine("\t\t\t\t\t+-----------------------------------------+");

                Console.Write("\n\t\t\t\t\t\tEntrez votre choix: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    string filePath = "RulesFilesFr.txt";

                    try
                    {
                        string contenu = File.ReadAllText(filePath);
                        Console.WriteLine(contenu);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erreur : {ex.Message}");
                    }
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Lancement du jeu...");
                    break;
                }
                else if (choice == 3)
                {
                    string filePath = "TeamsMemberFr.txt";

                    try
                    {
                        string contenu = File.ReadAllText(filePath);
                        Console.WriteLine(contenu);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erreur : {ex.Message}");
                    }
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Merci d'avoir joué !");
                    Console.WriteLine("Au revoir :) !");
                    System.Environment.Exit(0);
                }

                Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                Console.ReadKey();
            }
        }
        else if (language == 3)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colors[random.Next(colors.Length)]);
                Console.WriteLine("\t\t\t\t\t\t WELCOME TO THE UNO GAME VIA TERMINAL :)\n");
                Console.WriteLine("\t\t\t\t\t+-----------------------------------------+");
                Console.WriteLine("\t\t\t\t\t|      M     M  EEEEE  N   N  U   U       | ");
                Console.WriteLine("\t\t\t\t\t|      MM   MM  E      NN  N  U   U       |");
                Console.WriteLine("\t\t\t\t\t|      M M M M  EEEE   N N N  U   U       |");
                Console.WriteLine("\t\t\t\t\t|      M  M  M  E      N  NN  U   U       |");
                Console.WriteLine("\t\t\t\t\t|      M     M  EEEEE  N   N   UUU        |");
                Console.WriteLine("\t\t\t\t\t+-----------------------------------------+");
                Thread.Sleep(500);
                Console.ResetColor();
                Console.WriteLine("\t\t\t\t\t+-----------------------------------------+");
                Console.WriteLine("\t\t\t\t\t|      Choose an option :                 |");
                Console.WriteLine("\t\t\t\t\t|    1. Game Rules                        |");
                Console.WriteLine("\t\t\t\t\t|    2. Play                              |");
                Console.WriteLine("\t\t\t\t\t|    3. Project Creators                  |");
                Console.WriteLine("\t\t\t\t\t|    4. Quit the game                     |");
                Console.WriteLine("\t\t\t\t\t+-----------------------------------------+");

                Console.Write("\n\t\t\t\t\t\tEnter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    string filePath = "RulesFilesEn.txt";

                    try
                    {
                        string contenu = File.ReadAllText(filePath);
                        Console.WriteLine(contenu);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Starting the game...");
                    break;
                }
                else if (choice == 3)
                {
                    string filePath = "TeamsMemberEn.txt";

                    try
                    {
                        string contenu = File.ReadAllText(filePath);
                        Console.WriteLine(contenu);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Thank you for playing!");
                    Console.WriteLine("Goodbye :)");
                    System.Environment.Exit(0);
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}