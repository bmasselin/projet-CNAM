using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Controller MyController;
    public Transform Projectile;
    public float ProjectileStartSpeed = 10;
    public float OffsetForwardShoot = 2;
    public float TimeBetweenShots = 0.5f;
    public float ProjectileLifetime = 2.0f; // Durée de vie du projectile en secondes
    private float TimeShoot = 0;

    // Update is called once per frame
    void Update()
    {
        TimeShoot -= Time.deltaTime;

        if (MyController.WantsToShoot && TimeShoot <= 0)
        {
            TimeShoot = TimeBetweenShots;

            //Création du projectile au bon endroit
            Transform proj = GameObject.Instantiate<Transform>(Projectile,
                transform.position + transform.forward * OffsetForwardShoot, transform.rotation);
            //Ajout d une impulsion de départ
            proj.GetComponent<Rigidbody>().AddForce(transform.forward * ProjectileStartSpeed, ForceMode.Impulse);

            // Destruction du projectile après la durée de vie spécifiée
            Destroy(proj.gameObject, ProjectileLifetime);
        }
    }
}
