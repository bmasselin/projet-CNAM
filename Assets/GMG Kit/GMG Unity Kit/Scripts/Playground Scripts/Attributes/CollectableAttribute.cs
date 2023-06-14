using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Playground/Attributes/Collectable")]
public class CollectableAttribute : MonoBehaviour
{
    public int pointsWorth = 0;
    public int healthWorth = 0;

    private UIScript userInterface;

    public bool playSound = false;

    public AudioSource audioSrc;

    private void Start()
    {
        // Find the UI in the scene and store a reference for later use
        userInterface = GameObject.FindObjectOfType<UIScript>();
    }


    //This will create a dialog window asking for which dialog to add
    private void Reset()
    {
        Utils.ColliderDialogWindow(this.gameObject, true);
    }


    // This function gets called everytime this object collides with another
    private void OnTriggerEnter(Collider otherCollider)
    {
        string playerTag = otherCollider.gameObject.tag;

        // is the other object a player?
        if (playerTag == "Player" || playerTag == "Player2")
        {
            if (userInterface != null)
            {
                // add one point
                int playerId = (playerTag == "Player") ? 0 : 1;
                userInterface.AddPoints(playerId, pointsWorth);
                userInterface.ChangeHealth(playerId, healthWorth);
            }
            if (playSound && audioSrc != null)
            {
                audioSrc.Play();
            }
            // then destroy this object
            Destroy(gameObject);
        }
    }
}
