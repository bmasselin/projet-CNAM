using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MyWork
{
    public class GameManager : MonoBehaviour
    {
        int numberOfDuels = 0;
        Player player = new Player();
        Elf elf = new Elf();//déclaré en dehors de la fonction pour que je puisse l'appeler dans une autre fonction.

        public void Start()
        {
            RunGame();
        }

        public void RunGame()
        {
            //Introduction
            DeathEater deathEater = new DeathEater();

            Debug.Log("Choose a wizard name to start playing.\n Wizard name:");
            player.playerName = "Toto";// Console.ReadLine();
            Debug.Log($"\n {player.playerName}, you are 18 year old young wizard, freshly out of school. Thinking about the future makes you anxious, because you have no clue about what you want to do for a living, except you like being outdoors, writing amateur poetry and living new adventures. You see an advertisment in your favourite bar for joining a group of like minded wizards and it sparks your interest. \n You touch the ad with your wand and Pouf, it brings you to a spacious living room. A yound woman greets you with a large smile.");
            Debug.Log("-Welcome! My name is Aurora. Are you here to join Doredumble's army?");
            Debug.Log(">>Hi what? The real Doredumble's army??? I must be dreaming..");
            Debug.Log("-No you are not. We are always seeking new talents as the Dark Lord influence is getting stronger and stronger in these troubled times. Do you have what it takes to join us?");
            Debug.Log(">>Errr, I guess? I was a major in my Defense against the dark arts class");
            Debug.Log("Good. We like bold candidates. But you have to prove your worth to us by winning DeathEaters in a fight. For security reasons, I have to test you right away.");
            Debug.Log(">>Wait, you said *Deatheaters*? Plural?");
            Debug.Log("-This depends on you. If you are talented, defeating one DeathEater shall suffice. Are you ready ?");
            Debug.Log("\n Type 1 for yes or 2 for no.");
            int resp = 0;

            Decision();

            if (resp == 1)
            {
                Debug.Log("\n Let's go! She hands you a teapot, obviously another portkey, and you disapear from the living room. You are now standing in the middle of a graveyard. A tall dark shape is sitting next to a crying angel. Friendly setting!, you said to yourself.");
            }

            else if (resp == 2)
            {
                Debug.Log("\n Nobody's truly ready... Good luck! She hands you a teapot, obviously another portkey, and you disapear from the living room. You are now standing in the middle of a graveyard. A tall dark shape is sitting next to a crying angel. Friendly setting!, you said to yourself.");
            }

            Debug.Log("\n Your XP = " + player.xp + "\n Your health = " + player.Health + " % ");
            Debug.Log("\n DeathEater XP = " + deathEater.xp + "\n DeathEater Health = " + deathEater.Health + "%");


            //Level One : Combat
            //First Fight
            Fight(player, deathEater);//on doit passer les objets créés dans la fonction car on accède et modifie ses attribus en l'utilisant)


            //Second Fight
            DeathEater deathEater2 = new DeathEater();
            deathEater2.xp = 20;

            if (player.xp < 20)
            {
                Debug.Log($"You hear Aurora's voice in your head: You did a good job on this duel but unfortunately you did not gain enough xp to reach the next level. Challenge another DeathEater now to reach class 2 and to get the chance of winning a new spell! \n Are you ready? Go!");
                Fight(player, deathEater2);
            }
            else if (player.xp <= 39)
            {
                Debug.Log($"\nUnfortunately, another DeathEater is coming to you, and they look more agressive. This is time to test your shield!");
                Fight(player, deathEater2);
            }

            //Level Two : First Quest
            FirstQuestIntro();

            Decision();

            if (resp == 1)
            {
                Debug.Log("\n Mandrakes were sometimes planted around dolmens as part of magical rituals. \n The dolmen is not far, ");
            }

            else if (resp == 2)
            {
                Debug.Log("\n Mandrakes like to grow under trees, everybody knows that!  \n When you enter the forrest, it is pitch dark. Lumos, you say to cast light from the tip of your wand, ");
            }

            Debug.Log("and it is not long before you see the distinctive dark green leaves and bell-shaped flowers of mandrake plants. But you need to be careful, you know that mandrakes scream when torn from the ground and the screams of the mature ones are lethal! Unfortunately, you don't have anything to cover your ears so you decide to only uproot the baby ones. But your were not the most attentive student during your herbology classes. You recall that size does not indicate maturity, only the color of the flower does. You decide to uproot Mandrake type 1. With the purplish flower, or Mandrake type 2. With the white flower.\n Your decision, Mandrake type : ");

            Decision();

            if (resp == 1)
            {
                Debug.Log("\n This is definitely not a baby one, its scream is so loud that it knocks you down. You manage to plug the human looking root back into the ground. Phew, you are alive so this means this mandrake is still in its teenage years.");
                player.Health -= 20;
                Debug.Log($"\n Your Health = -20 points \n Total Health = {player.Health} %");
            }

            else if (resp == 2)
            {
                Debug.Log("\n This one is a baby, the big head and tummy of the human looking root make it clear... and you are not dead even if its piercing scream makes you want you to dig your head into the ground!");
                player.xp += 10;
                Debug.Log($"\n Your XP = +10 points \n Total XP = {player.xp} ");
            }
            //Increasing inventory and going back to see the elf
            MandrakeAdded();

            //going to Ariana Bonefide's house
            Debug.Log($"\n You follow {elf.elfName} and not long after you are in front of a massive golden portal. The elf mumbles something you cannot hear and the portal opens silently. A well groomed path leads to a two-story white mansion. Suddenly, you do not really want to go meet this Mrs Bonefide. Speaking of the devil, she is coming to see you, wearing an elegant cream-colored wizard dress embroided with, you notice, tiny golden sea-horses. {elf.elfName} bows immediately. You decide to great Ariana with a bleak smile. After all, you do not know on which side she is on. The Dark Lord has many inconspicuous admirers.");
            Debug.Log($"-{elf.elfName}, you bring me a visitor, and a charming one? What gives me the pleasure?");
            Debug.Log($">>Good afternoon my Lady, my name is {player.playerName}. Earlier today I have been attacked by DeathEaters, and I would like to ask you a few questions if you would be so kind to answer me.");
            Debug.Log("-Please come inside, you will tell me everything in front of a nice cup of tea. Or do you prefer a Butterbeer? \n You are thirsty and this comes well, you respond 1. A cup of tea, because this will make you warm and fuzzy inside after all these emotions or 2. A Butterbeer, because, well, for the same reasons.\n Your decision, beverage: ");

            Decision();

            if (resp == 1)
            {
                Debug.Log("\n>>A cup of tea would be nice, thank you Madam.");
            }

            else if (resp == 2)
            {
                Debug.Log("\n>>A Butterbeer would be nice, thank you Madam.");
            }
            Debug.Log($"She leads you inside. The interior of the mansion looks much less welcoming than the outside. The tapestry on the walls looks faded, and is even torn at some spots. The family portraits look at you with severe or scornfull looks, some whisper *stranger* or *Mudblood*... How inviting! To be honnest, this place would need a serious clean up. Once certainly well maintained, there might only be {elf.elfName} to clean the house now.");
            Debug.Log($"-So {player.playerName}, you say you have been attacked by DeathEaters this afternoon? How did you defeat them?");
            Debug.Log(">>This was not easy but I managed to surprise them with unconventional spells.");
            Debug.Log("-Good job, and you are quite young so you can be proud of you! They like to hang out in this cemetery, probably because they have nowwhere else to go now that the Dark Lord is hiding...");
            Debug.Log("Wait! You froze. Did she say cemetery? But you are pretty certain you did not mention that detail to her. Unless the elf informed her at the front gate in that special language you could not understand? You keep your guard up while reaching for your drink. Man, she really has piercing eyes! You take one sip of the bitter beverage and 1. swallow because she might be not inclined to help you go back to the Dumbledore's Army headquarters if you don't or 2. discretly spit it out in your handkerchief because you are never too cautious.");

            Decision();

            if (resp == 1)
            {
                Debug.Log("\n This tea has definitely been drugged, or it might be the scones? You are getting very dizzy. You manage to raise your wand but too weakly, she takes it immediately.");
                player.Health -= 10;
                Debug.Log($"\n Your Health = -10 points \n Total Health = {player.Health} %");
                Debug.Log("\n Just before passing out, a sudden thought strikes you. You were maybe not the best Defense against the dark arts student, but you were pretty good at potions. You remember that mandrakes root ingested in small amounts is an antidote, and the plant sap is the major ingredient of truth serum.");
            }

            else if (resp == 2)
            {
                Debug.Log("\n This Butterbear definitely has a strange aftertaste, it certainly has been drugged. Or it might be the scones? You decide to act like if you were indeed drugged. Ariana 's smile is broading the clumsier you get. Ha ha, you will get the final laught.\n A sudden thought strikes you. You were maybe not the best Herbology student, but you were pretty good at potions. You remember that the plant sap is the major ingredient of truth serum.");
                player.xp += 10;
                Debug.Log($"\n Your XP = +10 points \n Total XP = {player.xp} ");
            }

            // discover what Ariana is and find a portkey to go back to Aurora.
            Debug.Log("But how to distract your host so you can use the plant? You say the first thing that comes to your mind, you ask for a glass of water.");
            Debug.Log($"{elf.elfName}, would you bring a glass of water to our guest?");
            Debug.Log("Dragonshit, you mutter to yourself, of course she will not get it herself, you dummy!");
            Debug.Log($"But luck is on your side for once, the elf trips over the golden carpet and the glass flies onto Ariana's lap. She shrieks and leaves you alone in the living room, {elf.elfName} bowing and apologizing at every step. You would laught out loud is the situation was not so serious. You have to act quick! You take the butter knife and reach your satchel.");
            Inventory.AskInventory();

            //if (resp >= 1)
            //{
            //    if (Inventory.AskInventory("mandrake") >= 1)
            //    {

            //    }
            //}




            //end of Main
        }

        void FirstQuestIntro()
        {
            Debug.Log("\n Fortunately, no other DeatherEater is showing up next. But you spot the teapot shattered into pieces and you realize with dread that your portkey is useless to get out of this place. You will have to find another one! While you are gathering your thoughts, you see a small creature approaching, looking like a house-elf.");
            Debug.Log(">>Elf, do not go any further! What is your name and who do you serve?");
            Debug.Log("House-elf name:");
            elf.elfName = "Titi"; // Console.ReadLine();
            Debug.Log($"-My name is {elf.elfName}. My mistress is Ariana Bonefide.");
            Debug.Log($">>What is your business here {elf.elfName}?");
            Debug.Log("-I am running an errand for the house. I cannot be slowed down or my mistress will punish me for being late.");
            Debug.Log(">>Alright, alright, just one question and I will let you go. Where your mistress house is located? My portkey is broken and I want to ask her a few questions.");
            Debug.Log("-I will bring you to her, sir, if you help me find a mandrake root.");
            Debug.Log(">>Alright! I hope it is not too hard to find...");
            Debug.Log("\n You decide to go separate ways. You get to choose Path 1.Towards the white dolmen, or Path 2. Towards the magical forest.\n Your decision, Path : ");
        }

        public void MandrakeAdded()
        {
            Debug.Log("\nBut how many mandrakes does the house-elf need? You decide to uproot only ");
            int numberRolled = player.RollRegularDice();
            Debug.Log($"\nthat you put into your satchel. This chore done, you go back to find {elf.elfName}.");

            Inventory.AddRemoveItem("mandrake", numberRolled);

            Inventory.InventoryDisplay();

            Debug.Log("\n-Have you found any mandrakes?");
            Debug.Log(">>Yes, here you go.");
            Debug.Log("-Good, I found many ones myself, so I only need one piece. Thank you for your trouble.");
            Debug.Log(">>That was fair... Can you bring me to your mistress now?");
            Debug.Log("-Follow me.\n");

            Inventory.AddRemoveItem("mandrake", -1);
        }



        int PlayerAttack(Player player, DeathEater deathEater) //on doit passer les objets dans la fonction car ils ont été créés dans Main
        {
            int numberRolled = player.RollFightDice();

            switch (numberRolled)
            {
                case 1:
                    Debug.Log("\n #%$# BANG #%$# \n Spell Expeliarmus thrown to opponent!\n The DeathEater lost their wand.");
                    player.xp += 10;
                    break;
                case 2:
                    Debug.Log("\n #%$# BANG #%$# \n Spell Colloshoo thrown to opponent! \n The DeathEater 's shoes are sticked to the ground.");
                    player.xp += 2;
                    deathEater.Health -= 20;
                    Debug.Log("\n XP increased! \n XP = " + player.xp + "\n DeathEater Health = " + deathEater.Health + "%");
                    break;
                case 3:
                    Debug.Log("\n #%$# BANG #%$# \n Spell Arresto Momentum thrown to opponent! \n The DeathEater is being slowed down.");
                    player.xp += 2;
                    deathEater.Health -= 10;
                    Debug.Log("\n XP increased! \n XP = " + player.xp + "\n DeathEater Health = " + deathEater.Health + "%");
                    break;
                case 4:
                    Debug.Log("\n #%$# BANG #%$# \n Spell Aqua Eructo thrown to opponent! \n The DeathEater has received a strong jet of water and fell.");
                    player.xp += 2;
                    deathEater.Health -= 40;
                    Debug.Log("\n XP increased! \n XP = " + player.xp + "\n DeathEater Health = " + deathEater.Health + "%");
                    break;
                case 5:
                    Debug.Log("\n #%$# BANG #%$# \n Spell Confundo thrown to opponent! \n The DeathEater is now feeling confused and befuddled.");
                    player.xp += 2;
                    deathEater.Health -= 30;
                    Debug.Log("\n XP increased! \n XP = " + player.xp + "\n DeathEater Health = " + deathEater.Health + "%");
                    break;
                case 6:
                    Debug.Log("\n #%$# BANG #%$# \n Spell Confringo thrown to opponent! \n The DeathEater has received a jet of flames!");
                    player.xp += 2;
                    deathEater.Health -= 80;
                    Debug.Log("\n XP increased! \n XP = " + player.xp + "\n DeathEater Health = " + deathEater.Health + "%");
                    break;
                case 7:
                    Debug.Log("\n #%$# BANG #%$# \n You perform a Protego spell to strenghten your shield.");
                    player.xp += 2;
                    player.shield++; // maybe think about something else to materialize Protego?
                    Debug.Log("\n XP increased! \n XP = " + player.xp + "\n Shield layers = " + player.shield);
                    break;
                case 8:
                    Debug.Log("\n #%$# BANG #%$# \n Your perform a Reparifors spell to boost your health!.");
                    player.xp += 2;
                    player.Health += 40;
                    Debug.Log("\n XP increased! \n XP = " + player.xp + "\n Player Health = " + player.Health + "%");
                    break;
            }
            return numberRolled;//une fonction ne peut retourner qu'une seule valeur. La fonction retourne un entier mais dans Main, il faut bien créer une variable (appelée numberRolled ou autre nom) pour stocker cet entier retourné. 
        }

        int EnnemyCounterAttack(Player player, DeathEater deathEater)
        {

            int numberRolledEnnemyWithShield = deathEater.RollFightDice();


            switch (numberRolledEnnemyWithShield)
            {
                case 1:
                    deathEater.xp += 10;
                    player.shield--;
                    if (player.shield <= -1)
                    {
                        Debug.Log("\n #%$# BANG #%$# \n Spell Expeliarmus thrown back to you!\n You lost your wand and cannot fight back. The DeathEater wins!");
                        break;
                    }
                    else
                    {
                        Debug.Log($"\n #%$# BANG #%$# \n Spell Expeliarmus thrown back to you but you activated your shield on time and blocked the spell. So you keep your wand!\n But your shield got damaged and lost 1 layer on the process...\n Shield/layers = {player.shield}");
                        break;
                    }
                case 2:
                    deathEater.xp += 2;
                    player.Health -= 20;
                    Debug.Log("\n #%$# BANG #%$# \n Spell Colloshoo thrown back to you! \n Your shoes are sticked to the ground.");
                    Debug.Log("\n Your health = " + player.Health + "% \n DeathEater XP increased! \n DeathEater XP = " + deathEater.xp);
                    break;
                case 3:
                    deathEater.xp += 2;
                    player.Health -= 10;
                    Debug.Log("\n #%$# BANG #%$# \n Spell Arresto Momentum thrown back to you! \n The DeathEater is making your movements slow.");
                    Debug.Log("\n Your health = " + player.Health + "% \n DeathEater XP increased! \n DeathEater XP = " + deathEater.xp);
                    break;
                case 4:
                    deathEater.xp += 2;
                    if (player.shield < 1)
                    {
                        player.Health -= 40;
                        Debug.Log("\n #%$# BANG #%$# \n Spell Aqua Eructo thrown back to you! \n The DeathEater is throwing a strong jet of water to you and making you fall.");
                        Debug.Log("\n Your health = " + player.Health + "% \n DeathEater XP increased! \n DeathEater XP = " + deathEater.xp);
                        break;
                    }
                    else
                    {
                        player.shield--;
                        Debug.Log($"\n #%$# BANG #%$# \n Spell Aqua Eructo thrown back to you but you activated your shield on time and blocked the spell. So you keep your balance!\n But your shield got damaged and lost 1 layer on the process...\n Shield/ layers = {player.shield}");
                        break;
                    }
            }
            return numberRolledEnnemyWithShield;
        }


        int Fight(Player player, DeathEater deathEater)
        {
            int numberRolled = 0;
            int numberRolledEnnemy = 0;
            bool PlayerTurn = true;

            while (true) //boucle infinie, on en sort grâce aux break. Cette solution était plus simple qu'un do while avec nos mutliples conditions.
            {
                if (PlayerTurn == true)
                {
                    numberRolled = PlayerAttack(player, deathEater);
                }
                else
                {
                    numberRolledEnnemy = EnnemyCounterAttack(player, deathEater);
                }

                PlayerTurn = !PlayerTurn; //on inverse la valeur du booléen 

                if (numberRolled == 1 || player.Health <= 0 || deathEater.Health <= 0)
                    break;

                if (numberRolledEnnemy == 1 && player.shield < 0)
                    break;
            }

            numberOfDuels++;
            Debug.Log("End of this duel.");


            if (deathEater.Health <= 0 || numberRolled == 1)
            {
                player.numberOfDuelsWon++;
            }


            Stats(player, deathEater);

            player.LevelUp();

            return player.numberOfDuelsWon;
        }


        void Stats(Player player, DeathEater deathEater)
        {

            Debug.Log($"\n \n {player.playerName} stats: \n Health = {player.Health} % \n XP = {player.xp} \n Shield/ layers = {player.shield}");
            Debug.Log($"\n DeathEater stats: \n Health = {deathEater.Health} % \n XP = {deathEater.xp}");
            Debug.Log("\n");
            Debug.Log($"Number of duels won = {player.numberOfDuelsWon} / {numberOfDuels} duels");
            Debug.Log("\n \n");
        }

        int Decision()
        {
            int resp = 1;
            while (true)
            {
                //if (Int32.TryParse(Console.ReadLine(), out resp))//Il y a des fonctions qui gèrent des rapports d'erreur avec des exceptions, comme par ex le Convert.Int32. Donc c'est mieux de ne pas faire une exception avec Try catch (qui est très couteux). La condition dit que s'il arrive à Parser, cela me sort un resp (out resp). En effet, quand il y a un out, la fonction change son argument en sortie, alors qu'en ègle générale, c'est en entrée.
                {
                    if (resp == 1)
                    {
                        break;
                    }
                    else if (resp == 2)
                    {
                        break;
                    }
                    else
                    {
                        Debug.Log("\n Invalid response.");//si la pers rentre un autre nombre
                    }
                }
                //else
                //{
                //    Debug.Log("\n Invalid response.");//si la personne rentre une valeur non numérique
                //}
            }
            return resp;
        }
    }
}