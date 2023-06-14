using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Player : Fighter
{
    public string playerName;
    public int shield = 0;
    public int spellGained = 4;
    public int numberOfDuelsWon = 0;
    public int numberOfDuelsLost = 0;
    public Player()
    {
        xp = 0;//constructeur optionnel car déjà initialisé à 0 dans Fighter mais utile si je veux changer artificiellement l'xp pour des tests.
    }

    public int RollFightDice() //override de la méthode abstraite dans Fighter
    {
        System.Random number = new System.Random();
        int numberRolled = number.Next(1, spellGained + 1);//le 1er chiffre du range est inclusif mais le 2ème est exclusif donc on rajoute 1.
        Debug.Log("\nRoll the spell dice to fight!");
       // Console.ReadKey(true);//en mettant true, la touche enfoncée est interceptée et n’est pas affichée dans la fenêtre de la console.
        Debug.Log(numberRolled);
        return numberRolled;
    }

    public int RollRegularDice()//pas de méthode abstraite existante pour l'instant
    {
        System.Random number = new System.Random();
        int numberRolled = number.Next(1, 7);
        Debug.Log("\n Roll the dice to find out!");
      //  Console.ReadKey(true);
        Debug.Log(numberRolled);
        return numberRolled;
    }

    public void LevelUp()
    {
        if (spellGained ==4 && xp >= 20 && xp <=39)
        {
            shield++;
            Debug.Log($"\n Level Up! You are now a class 2 wizard. You gain a magic shield to protect yourself during fights. The more XP you get, the more protective layers you get on your shield.\n Shield/ layers = {shield}. \n Also, new spell unlocked: Confundo! This causes the victim to become confused and befuddled.");
            spellGained++;
        }
        else if (spellGained == 5 && xp >= 40 && xp <= 59)
        {
            shield++;
            Debug.Log($"\n You are now a class 3 wizard.\n Shield/ layers = {shield} \n New spell unlocked: Confringo! \n This blasting curse produces a fiery explosion. Use it wisely!.");
            spellGained++;
        }
        else if (spellGained == 6 && xp >= 60 && xp <= 79)
        {
            shield++;
            Debug.Log($"\n You are now a class 4 wizard.\n Shield/ layers = {shield}. \n New spell unlocked: Protego! \n This produces an invisible shield that reflects spells and blocks physical entities.");
            spellGained++;
        }
        else if (spellGained == 7 && xp >= 80)
        {
            shield++;
            Debug.Log($"\n You are now a class 5 wizard.\n Shield/ layers = {shield}. New spell unlocked: Reparifors! \n Reverts minor magically-induced ailments, such as paralysis and poisoning.");
            spellGained++;
        }
        else if (xp <20 || xp <40 || xp<60 || xp<80)
        {
            Debug.Log("\n Pro tip: Keep on winning duels to upgrade your wizard class.");
        }
    }
}