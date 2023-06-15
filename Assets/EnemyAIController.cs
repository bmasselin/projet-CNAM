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


    /*public float moveSpeed = 3f;
    public float detectionRange = 10f;

    private Transform player;
    private Rigidbody rb;
    private EnemyShooting shooting;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        shooting = GetComponent<EnemyShooting>();
    }

    private void Update()
    {
        MoveTowardsPlayer();
        RotateTowardsPlayer();
        CheckIfTimeToFire();
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

    private void RotateTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void CheckIfTimeToFire()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRange)
        {
            shooting.Shoot();
        }
    }*/
