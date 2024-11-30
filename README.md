# Jeu Uno - C#

## Description

Ce projet implémente une version du jeu Uno en utilisant le langage C#. Le jeu propose une interface console et prend en charge plusieurs fonctionnalités de base du jeu Uno, telles que la gestion des cartes, des règles spéciales (comme les cartes +2, +4, Passer, Inverser, Joker), et l'interface en deux langues (Français et Anglais). Le but du jeu est d'être le premier joueur à se débarrasser de toutes ses cartes.

## Pratiques de code

 1 - Le code se limite aux notions de programmation orientée objet discutées en POOI.
    (Ceci signifie que nous avez essayer de limiter le code à des concepts assez simple donc les   interruptions ne sont pas gérés notamment les ctrl+D.)
 
 2 - Chaque programme est encapsulé dans des méthodes appropriées suivant un diagramme de classe établit.

## Fonctionnalités

Multilingue         : Choisissez la langue du jeu (Français ou Anglais) dès le lancement.
    Gestion des joueurs : Vous pouvez jouer avec 2 à 4 joueurs. Les joueurs entrent leurs noms au début de la partie.
    
   Cartes spéciales    : Les cartes "Passer", "Inverser", "+2", "+4", et "Joker" sont présentes et affectent le déroulement du jeu.
    
   Vérification de victoire : Le jeu se termine lorsqu'un joueur n'a plus de cartes dans sa main.
    
   Règle de "Uno"      : Le joueur doit dire "Uno" lorsqu'il lui reste une seule carte, sinon il doit piocher deux cartes supplémentaires. 
    (Les règles du jeu proprement dites sont accessibles depuis le menu du Jeu)

## Prérequis

.NET SDK 6.0 ou version ultérieure pour exécuter le projet.
      (Installable depuis le fichier compilprogramme.sh sur linux
                                ou
                    compilprogramme.bat sur windows  )

## Installation

 1-Clonez ce repository ou téléchargez les fichiers du projet.
    
   2-git clone git@github.com:marien272/UnoGameCsharp.git
   
   3-Ouvrez le projet dans Visual Studio ou un éditeur compatible avec C#.
    
   4- Exécutez le fichier 'ExecuteProg.py' (Le fichier permet d'installer
        .NET SDK pour C# si ce n'est pas déja fait et de lancer le programme)
    
   4(obtionnel)- Compilez et exécutez le projet plus facilement si vous voulez avec la commande.
        dotnet run


## Instructions
 ### Lancer le jeu

Lorsque vous lancez le jeu, vous êtes invité à choisir la langue entre Français (2) et Anglais (1).
    Ensuite, vous devez entrer les noms des joueurs (2 à 4 joueurs), séparés par des espaces.
    Le jeu commence avec la distribution de 5 cartes à chaque joueur, et le joueur suivant est invité à jouer une carte ou à piocher. 

## Règles du jeu

Le jeu commence avec une carte tirée au hasard sur le tapis.
    À chaque tour, le joueur peut jouer une ou plusieurs cartes qui correspondent soit à la couleur soit à la valeur de la carte actuelle sur le tapis.
    Si un joueur joue une carte spéciale, elle aura un effet sur le jeu :
        Passer : Le joueur suivant passe son tour.
        Inverser : Le sens du jeu est inversé.
        +2 : Le joueur suivant doit piocher 2 cartes.
        +4 : Le joueur suivant doit piocher 4 cartes et la couleur du jeu est choisie par le joueur ayant joué la carte.
        Joker : Le joueur peut choisir la nouvelle couleur du jeu. 
    Si un joueur oublie de dire "Uno" lorsqu'il n'a qu'une carte restante, il doit piocher 2 cartes supplémentaires.
    Le premier joueur à se débarrasser de toutes ses cartes gagne la partie. 

## Commandes

Choisir une carte : Entrez le numéro de la carte que vous souhaitez jouer. Vous pouvez sélectionner plusieurs cartes à la fois en les séparant par des virgules.
    Piocher une carte : Tapez 0 pour piocher une carte.
    Dire "Uno" : Lorsque vous n'avez plus qu'une carte, tapez "Uno" pour éviter d'être pénalisé. 

# # Exemple de déroulement d'une partie

Voici un exemple de ce à quoi pourrait ressembler le début d'une partie dans le jeu.

    Welcome to the Uno game!
    Enter the names of the players (2 to 4), separated by spaces:
    John Jane Bob

    Drawing the first card for the table...
    The first card on the table is: Green 7

    It's John's turn.
    Card on the table: Green 7

    Choose one or more cards to play (enter the numbers separated by commas) or type 0 to draw:
    1,2

    John plays: Green 7, Yellow 5

    It's Jane's turn.
    Card on the table: Yellow 5
    ...

## Contribuer

Les contributions sont les bienvenues ! Si vous avez des suggestions, des corrections ou des améliorations à proposer, veuillez créer une pull request.

## Licence
   Ce projet est sous licence **Creative Commons Attribution - Pas d'Utilisation Commerciale 4.0 International (CC BY-NC 4.0)**.

Pour plus de détails, consultez le fichier [LICENSE](./LICENSE).

# Auteurs
Etudiants du Campus de Rimouski (UQAR) en Baccalauréat en Informatique.
    1 - OLYMPIO Marien Donatien ;

