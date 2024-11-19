using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int playerHealth = 3;
    public TextMeshProUGUI healthText;

    void Start()
    {
        healthText.text = "Health: " + playerHealth.ToString();
    }

    public void loseHealth(int healthToLose)
    {
        playerHealth -= healthToLose;
        healthText.text = "Health: " + playerHealth.ToString();

        //check for if health <= 0 
        //if so die
    }

    public void gainHealth(int healthToGain)
    {
        playerHealth += healthToGain;
        healthText.text = "Health: " + playerHealth.ToString();

        //check for if health <= 0 
        //if so die
    }

}



/*
What I have done:

SoundEffects https://www.youtube.com/watch?v=DU7cgVsU2rM
Play Random Sound Effects
player death

TODO:
Go inside of a house
Transport script : to get out of the house



Better Camera
2D lighting






enemy projectile -> move





move to "playAnim" model
switch player health to listener design pattern

AI Pathfinding: https://arongranberg.com/astar/

*/