using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class DeathEater : Fighter
{
    public DeathEater() 
    {
        xp = 5;
    }

    public int RollFightDice() //override de la méthode abstraite dans Fighter.
    {
        Debug.Log("\n The DeathEater is raising their wand... ");
        Debug.Log("(Press any key to continue)");
        //Console.ReadKey(true);
        System.Random numberEnnemy = new System.Random();
        int numberRolledEnnemyWithShield = numberEnnemy.Next(1, 5);//le 1er chiffre du range est inclusif mais le 2ème est exclusif donc on rajoute 1 (4 sorts+1)
        return numberRolledEnnemyWithShield;
    }

    
}
