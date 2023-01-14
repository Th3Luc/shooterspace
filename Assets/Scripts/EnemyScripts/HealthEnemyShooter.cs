using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemyShooter : MonoBehaviour, IDamageable
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public int maxHealth = 100;
    public float shootInterval = 1f;
    public float accuracy = 0.9f;
    public Transform playerTransform;
    public GameObject spawnManager;
    public int healthGain = 10;
    public float minShootingDistance = 5f;


    private int currentHealth;
    private float timeSinceLastShot;
    private EnemySpawner enemySpawner;
    private Rigidbody2D rb;


    private void Start()
    {
        currentHealth = maxHealth;
        timeSinceLastShot = 0f;
        spawnManager = GameObject.FindWithTag("SpawnManager");
        enemySpawner = spawnManager.GetComponent<EnemySpawner>();
        rb = GetComponent<Rigidbody2D>();

        // Find the player's transform by searching for the Player tag
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

            if (timeSinceLastShot >= shootInterval)
            {
                FireBullet();
                timeSinceLastShot = 0f;
            }
    }

    private void FireBullet()
    {
        // Instantiate a new bullet at the enemy's position
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        // Get the direction towards the player
        Vector2 direction = (playerTransform.position - transform.position).normalized;

        // Set the initial velocity of the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;

        // Set the bullet's tag to "EnemyBullet"
        bullet.tag = "EnemyBullet";
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<PlayerHealth>().GainHealth(healthGain);
            OnDeath();
            Destroy(gameObject);
        }
    }

    private void OnDeath()
    {
        enemySpawner.OnEnemyDeath();
    }
}
