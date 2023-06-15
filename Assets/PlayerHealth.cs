using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;

    private UIScript ui;
    private int maxHealth;

    private int playerNumber;

    private void Start()
    {
        ui = GameObject.FindObjectOfType<UIScript>();

        switch (gameObject.tag)
        {
            case "Player":
                playerNumber = 0;
                break;
            case "Player2":
                playerNumber = 1;
                break;
            default:
                playerNumber = -1;
                break;
        }

        if (ui != null && playerNumber != -1)
        {
            ui.SetHealth(playerNumber, health);
        }

        maxHealth = health;
    }

    public void ModifyHealth(int amount)
    {
        if (health + amount > maxHealth)
        {
            amount = maxHealth - health;
        }

        health += amount;

        if (ui != null && playerNumber != -1)
        {
            ui.ChangeHealth(playerNumber, amount);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            ModifyHealth(-1); 
        }
    }
}