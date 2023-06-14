using UnityEngine;
using System.Collections;
using static UnityEngine.ParticleSystem;

[AddComponentMenu("Playground/Attributes/Modify Health")]
public class ModifyHealthAttribute : MonoBehaviour
{

    public bool destroyWhenActivated = false;
    public int healthChange = -1;
    public float forceImpulse = 0;
    public AudioClip collisionSound; // Nouvelle variable pour le son de collision

    private AudioSource audioSource; // Nouveau composant AudioSource

    //This will create a dialog window asking for which dialog to add
    private void Reset()
    {
        Utils.ColliderDialogWindow(this.gameObject, true);
    }

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // Ajout du composant AudioSource
    }

    public void OnCollisionEnter(Collision collisionData)
    {
        Debug.LogFormat("COLLISION {0}", collisionData.gameObject);

        HealthSystemAttribute healthScript = collisionData.gameObject.GetComponent<HealthSystemAttribute>();
        if (healthScript != null)
        {
            // subtract health from the player
            healthScript.ModifyHealth(healthChange);

            if (destroyWhenActivated)
            {
                Destroy(this.gameObject);
            }
            if (forceImpulse > 0)
            {
                Rigidbody rb = collisionData.gameObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    // Calculate the direction vector from the player to the colliding object (player-objet)
                    Vector3 push = collisionData.gameObject.transform.position - transform.position;

                    // Apply the force impulse along the calculated direction
                    //Force.Impulse = la force est appliquée de manière impulsive, ce qui signifie qu'elle est appliquée instantanément et affecte la vitesse de l'objet. Cela simule un impact soudain et donne généralement une réaction plus réaliste aux collisions ou aux forces appliquées.Le mode par défaut est ForceMode.Force qui applique la force de manière progressive sur plusieurs frames
                    rb.AddForce(push.normalized * forceImpulse, ForceMode.Impulse);
                }
            }

            if (collisionSound != null) // Vérification si le son de collision est défini dans l'inspecteur
            {
                audioSource.PlayOneShot(collisionSound); // Lecture du son de collision
            }

        }

    }
}

 //   // This function gets called everytime this object collides with another
 //   private void OnCollisionEnter(Collision collisionData)
	//{
	//	OnTriggerEnter(collisionData.collider);
	//}

	//private void OnTriggerEnter(Collider colliderData)
	//{
	//	HealthSystemAttribute healthScript = colliderData.gameObject.GetComponent<HealthSystemAttribute>();
	//	if(healthScript != null)
	//	{
	//		// subtract health from the player
	//		healthScript.ModifyHealth(healthChange);

	//		if(destroyWhenActivated)
	//		{
	//			Destroy(this.gameObject);
	//		}
	//	}
	//}
//}
