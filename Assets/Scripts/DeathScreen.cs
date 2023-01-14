using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public Text killsText;
    void Start()
    {
        killsText.text = "Kills: " + PlayerStats.kills; // set the text of the killsText UI element to the player's number of kills
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene"); // reload the current scene
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // load the main menu scene
    }
}