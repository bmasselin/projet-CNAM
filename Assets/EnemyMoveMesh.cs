using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveMesh : MonoBehaviour
{
    NavMeshAgent enemy;
    GameObject player;
    public float rotationSpeed = 180;

    public int maxCollisions = 3;
    private int collisionCount = 0;
    public float waitSecondsBeforeDestroy = 0f;
    public AudioClip soundFile;
    private AudioSource audioSrc;

    private UIScript userInterface;


    // Start is called before the first frame update
    void Start()
    {
       enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            enemy.SetDestination(player.transform.position);

            // Rotation vers la cible
            Vector3 direction = player.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            collisionCount++;

            if (collisionCount >= maxCollisions)
            {
                if (soundFile != null && audioSrc != null && !audioSrc.isPlaying)
                    audioSrc.Play();

                string playerTag = collision.gameObject.tag;
                int playerId = (playerTag == "Player") ? 0 : 1;

                if (userInterface != null)
                {
                    // add points to the player
                    userInterface.AddPoints(playerId, 100);
                }

                Destroy(gameObject, waitSecondsBeforeDestroy);
            }
        }
    }
}
