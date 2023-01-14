using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour, IDamageable
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public int maxHealth = 100;
    public float shootInterval = 1f;
    public float accuracy = 0.9f;
    public Transform playerTransform;
    public GameObject spawnManager;
    public float minShootingDistance = 5f;
    public ParticleSystem explosionEffect;
    private Rigidbody2D rb;
    private int currentHealth;
    private float timeSinceLastShot;
    private EnemySpawner enemySpawner;

    private void Start()
    {
        currentHealth = maxHealth;
        timeSinceLastShot = 0f;
        spawnManager = GameObject.FindWithTag("SpawnManager");
        enemySpawner = spawnManager.GetComponent<EnemySpawner>();
        
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
          rb = GetComponent<Rigidbody2D>();
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
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        Vector2 direction = (playerTransform.position - transform.position).normalized;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;

        bullet.tag = "EnemyBullet";
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            OnDeath();
            Destroy(gameObject);
        }
    }

    private void OnDeath()
    {
        explosionEffect.Play();
        enemySpawner.OnEnemyDeath();
    }
}
