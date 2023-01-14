using UnityEngine;
public class PlayerStats : MonoBehaviour
{
    public static int kills; // the number of enemies killed by the player

    void Start()
    {
        kills = 0;
    }
}