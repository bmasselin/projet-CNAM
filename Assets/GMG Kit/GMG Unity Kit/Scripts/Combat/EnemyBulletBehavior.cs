using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehavior : MonoBehaviour
{
    public float moveSpeed = 7f;

    private Rigidbody rb;
    public GameObject target;
    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (target == null)
        {
            Debug.LogWarning("Target is not assigned!");
            return;
        }

        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = moveDirection;
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            Debug.Log("Hit!");
            Destroy(gameObject);
        }
    }
}