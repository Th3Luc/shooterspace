using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyTypes : MonoBehaviour
{
public GameObject enemyType1;
public GameObject enemyType2;
public GameObject enemyType3;
public GameObject enemyType4;
public GameObject enemyType5;
public GameObject enemyType6;
public EnemyShooter enemyType1Shooter;
public DDEnemyShooter enemyType2Shooter;
public HealthEnemyShooter enemyType3Shooter;
public MaxHealthEnemyShooter enemyType4Shooter;
public SpeedEnemyShooter enemyType5Shooter;
public TooltipAttribute joe;
public Text nameText;
public Text healthText;
public Text damageText;
public Text speedText;
public Image spriteImage;
public int enemyType;

void Start()
{
    enemyType = 1;
}

void Update()
{
    switch (enemyType)
    {
        case 1:
            nameText.text = enemyType1.name;
            healthText.text = "Health: " + enemyType1.GetComponent<EnemyShooter>().maxHealth;
            damageText.text = "Shoot Speed: " + enemyType1Shooter.GetComponent<EnemyShooter>().shootInterval;
            speedText.text = "Speed: " + enemyType1.GetComponent<EnemyMover>().moveSpeed;
            spriteImage.material = enemyType1.GetComponent<SpriteRenderer>().sharedMaterial;
            break;
        case 2:
            nameText.text = enemyType2.name;
            healthText.text = "Health: " + enemyType2.GetComponent<DDEnemyShooter>().maxHealth;
            damageText.text = "Shoot Speed: " + enemyType2Shooter.GetComponent<DDEnemyShooter>().shootInterval;
            speedText.text = "Speed: " + enemyType2.GetComponent<EnemyMover>().moveSpeed;
            spriteImage.material = enemyType2.GetComponent<SpriteRenderer>().sharedMaterial;
            break;
        case 3:
            nameText.text = enemyType3.name;
            healthText.text = "Health: " + enemyType3.GetComponent<EnemyShooter>().maxHealth;
            damageText.text = "Shoot Speed: " + enemyType3Shooter.GetComponent<HealthEnemyShooter>().shootInterval;
            speedText.text = "Speed: " + enemyType3.GetComponent<EnemyMover>().moveSpeed;
            spriteImage.material = enemyType3.GetComponent<SpriteRenderer>().sharedMaterial;
            break;
        case 4:
            nameText.text = enemyType4.name;
            healthText.text = "Health: " + enemyType4.GetComponent<EnemyShooter>().maxHealth;
            damageText.text = "Shoot Speed: " + enemyType3Shooter.GetComponent<HealthEnemyShooter>().shootInterval;
            speedText.text = "Speed: " + enemyType4.GetComponent<EnemyMover>().moveSpeed;
            spriteImage.material = enemyType4.GetComponent<SpriteRenderer>().sharedMaterial;
            break;
        case 5:
            nameText.text = enemyType5.name;
            healthText.text = "Health: " + enemyType5.GetComponent<EnemyShooter>().maxHealth;
            damageText.text = "Shoot Speed: " + enemyType3Shooter.GetComponent<HealthEnemyShooter>().shootInterval;
            speedText.text = "Speed: " + enemyType5.GetComponent<EnemyMover>().moveSpeed;
            spriteImage.material = enemyType5.GetComponent<SpriteRenderer>().sharedMaterial;
            break;
        case 6:
            nameText.text = enemyType6.name;
            healthText.text = "Health: " + enemyType6.GetComponent<EnemyShooter>().maxHealth;
            damageText.text = "Shoot Speed: " + enemyType3Shooter.GetComponent<HealthEnemyShooter>().shootInterval;
            speedText.text = "Speed: " + enemyType6.GetComponent<EnemyMover>().moveSpeed;
            spriteImage.material = enemyType6.GetComponent<SpriteRenderer>().sharedMaterial;
            break;
    }

}
    public void goBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}