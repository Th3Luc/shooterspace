using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour, IDamageable
{
    public DeathScreen deathScreen;
    public int maxHealth = 100;
    public int currentHealth;



    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("DeathScreen");
        }
    }

    public void GainHealth(int healthGain)
    {
        currentHealth = Mathf.Min(currentHealth + healthGain, maxHealth);
    }

    public void IncreaseMaxHealth(int healthIncrease)
{
    maxHealth += healthIncrease;
    currentHealth = Mathf.Min(currentHealth, maxHealth);
}

}
