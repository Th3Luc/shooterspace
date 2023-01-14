using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float minDistance = 1f;
    public float maxDistance = 10f;

    private Transform playerTransform;
    private Rigidbody2D rb;

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer > minDistance && distanceToPlayer < maxDistance)
        {
            MoveTowardsPlayer(moveSpeed);
        }
        else if (distanceToPlayer < minDistance)
        {
            MoveAwayFromPlayer(moveSpeed);
        }
        else
        {
            MoveTowardsPlayer(moveSpeed * 4);
        }
    }

    void MoveAwayFromPlayer(float speed)
    {
        Vector2 direction = (transform.position - playerTransform.position).normalized;
        rb.velocity = direction * speed;
    }

    void MoveTowardsPlayer(float speed)
    {
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }
}
