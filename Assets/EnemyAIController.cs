using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float enemyRange = 30f;

    private float distanceBetweenTarget;
    private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform[] projectileSpawnPoints;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float fireRate = 2f;
    [SerializeField] private float launchForce = 500f;
    [SerializeField] private float offsetForwardShoot = 2f;
    [SerializeField] private float projectileLifetime = 2f;

    private float countdownBetweenFire = 0f;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceBetweenTarget = Vector3.Distance(target.position, transform.position);
        if (distanceBetweenTarget <= enemyRange)
        {
            navMeshAgent.SetDestination(target.position);
        }

        if (distanceBetweenTarget <= navMeshAgent.stoppingDistance)
        {
            if (countdownBetweenFire <= 0f)
            {
                foreach (Transform spawnPoint in projectileSpawnPoints)
                {
                    GameObject newProjectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
                    Rigidbody projectileRigidbody = newProjectile.GetComponent<Rigidbody>();
                    if (projectileRigidbody != null)
                    {
                        projectileRigidbody.AddForce(newProjectile.transform.forward * launchForce);
                    }
                    Destroy(newProjectile, projectileLifetime);
                }
                countdownBetweenFire = 1f / fireRate;
            }
            countdownBetweenFire -= Time.deltaTime;
        }
    }
}


    
