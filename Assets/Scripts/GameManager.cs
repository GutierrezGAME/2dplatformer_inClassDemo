using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // hold player health
    // handle game over


    // hold current score

    public int playerHealth = 5;

    public void loseHealth(int healthToLose)
    {
        playerHealth -= healthToLose;
        Debug.Log(playerHealth);

        //check for if health <= 0 
        //if so die
    }

    public void gainHealth(int healthToGain)
    {
        playerHealth += healthToGain;
        Debug.Log(playerHealth);

        //check for if health <= 0 
        //if so die
    }

}



/*
TODO:

UI // use the roll-a-ball tutorial
Move Pickups to Player Centered model (1 script that handles the interactions)
change trap to damage player script
Melee attack
Go inside of a house
Transport script : to get out of the house
Audio - play sound when shooting
Fix how player takes damage
player death
Better Camera
2D lighting






enemy projectile -> move





move to "playAnim" model
switch player health to listener design pattern

AI Pathfinding: https://arongranberg.com/astar/

*/