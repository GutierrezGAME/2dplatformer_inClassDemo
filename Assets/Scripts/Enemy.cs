using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{

    public int health = 3;
    public float maxSpeed = 3.0f;
    public EnemySprite sprite;
    public AIPath aiPath;

    // Start is called before the first frame update
    void Start()
    {
        aiPath = GetComponent<AIPath>();
        aiPath.maxSpeed = maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            sprite.Death();
            aiPath.maxSpeed = 0;
            Destroy(this.gameObject, 1.0f);
        }

        stopChasingForTime(0.5f);
    }

    public void stopChasingForTime(float time)
    {
        StartCoroutine(pauseMovement(time));
    }

    IEnumerator pauseMovement(float time)
    {
        aiPath.maxSpeed = 0;
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(time);

        aiPath.maxSpeed = maxSpeed;
    }
}
