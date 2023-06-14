using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


abstract class Fighter //une classe abstraite empêche juste d'instancier un objet Fighter, on aurait aussi bien pu se dire qu'on ne le fait jamais volontairement
{
    private int _health = 100;//c'est bien de mettre un underscore pour les variables private.
    public int xp = 0;

    public int Health
    {
        get
        {
            return _health;
        }

        set
        {
            _health = Math.Clamp(value, 0, 100); //health est bornée entre -1 et 101.
        }
    }

    //public abstract int RollFightDice();
}

