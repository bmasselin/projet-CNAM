using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveMesh : MonoBehaviour
{
    NavMeshAgent enemy;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       enemy=GetComponent<NavMeshAgent>();
        player=GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.transform.position);
    }
}
