using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakeDamage(int damage);
}

public class Bullet : MonoBehaviour
{
    public int damage = 10;
     private float offScreenTimer;

    private void Start()
    {
       offScreenTimer = 0f;
    }

    private void Update()
    {
   Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);
        if (screenPos.x >= 0 && screenPos.x <= 1 && screenPos.y >= 0 && screenPos.y <= 1)
        {
            offScreenTimer = 0f;
        }
        else
        {
            offScreenTimer += Time.deltaTime;
            if (offScreenTimer >= 10f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy" && gameObject.tag == "PlayerBullet")
        {
            IDamageable damageable = collider.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else if (collider.gameObject.tag == "Player" && gameObject.tag == "EnemyBullet")
        {
            IDamageable damageable = collider.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }




}
