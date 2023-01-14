using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
public GameObject bulletPrefab;
public float bulletSpeed = 10f;
public float normalFireRate = 0.5f;
public int normalDamage = 10;
public float damageBoostDuration = 5f;
public float speedBoostDuration = 5f;
private float timeSinceLastShot;

void Update()
{
    timeSinceLastShot += Time.deltaTime;

    if (Input.GetMouseButtonDown(0) && timeSinceLastShot >= GetCurrentFireRate())
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.LookRotation(Vector3.forward, direction));
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        bullet.tag = "PlayerBullet";
        bullet.GetComponent<Bullet>().damage = GetCurrentDamage();

        timeSinceLastShot = 0f;
    }

    if (damageBoostDuration > 0f)
    {
        damageBoostDuration -= Time.deltaTime;
    }

    if (speedBoostDuration > 0f)
    {
        speedBoostDuration -= Time.deltaTime;
    }
}

public void GrantDamageBoost(float duration)
{
    damageBoostDuration = duration;
}

public void GrantSpeedBoost(float duration)
{
    speedBoostDuration = duration;
}

private float GetCurrentFireRate()
{
    if (speedBoostDuration > 0f)
    {
        return normalFireRate / 10;
    }
    else
    {
        return normalFireRate;
    }
}

private int GetCurrentDamage()
{
    if (damageBoostDuration > 0f)
    {
        return normalDamage * 2;
    }
    else
    {
        return normalDamage;
    }
}
}