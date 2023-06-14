using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MyWork
{
    static class Inventory
    {

        static Dictionary<string, int> inventory = new Dictionary<string, int>();


        static public void InventoryDisplay()//display de la totalité de mon inventaire. 
        {
            Debug.Log($"\nTotal inventory:");
            foreach (KeyValuePair<string, int> item in inventory)
            {
                Debug.Log($"-{item.Key}, quantity = {item.Value}");
            }
        }

        static public void ItemDisplay(string itemName)//display de la quantité selon la clé. On met void, pas string car on ne retourne pas de string, on manipule une string.
                                                       //Changer la fonction en mettant try get value car cela explose peut etre si l'utilisateur met toto
        {
            Debug.Log($"You have got {inventory[itemName]} of the item type {itemName} in your inventory.");
        }

        static public int AskInventory()// faire une fonction qui accepte un paramètre itemName aussi. combiner les 2 fonctions pour que l'une appelle l'autre
        {
            Debug.Log("To know how many of one item you've got in your inventory, type the item's name.");
            string itemName = "toto"; // Console.ReadLine();
            int itemQty;

            if (inventory.TryGetValue(itemName, out itemQty))
            {
                Debug.Log($"{itemName}, quantity = {itemQty};");
            }
            else
            {
                Debug.Log("\nInvalid item name. Closing inventory.");
            }
            return itemQty;
        }

        static public void AddRemoveItem(string itemName, int qtyAdded)
        {
            if (!inventory.ContainsKey(itemName))
            {
                if (qtyAdded >= 1)
                {
                    inventory.Add(itemName, qtyAdded);
                    Debug.Log($"\nNew item, {itemName}, added to your inventory: {qtyAdded} unit(s).");
                }
                else
                {
                    Debug.Log("error");
                }
            }
            else
            {
                inventory[itemName] += qtyAdded;//on utilise ici l'opérateur crochet car l'item existe déjà en inventaire.
                if (inventory[itemName] > 0)
                {
                    ItemDisplay(itemName);
                }
                else
                {
                    inventory[itemName] = 0;
                    Debug.Log($"You no longer have any {itemName} in your inventory.");
                }
            }


        }

    }
}