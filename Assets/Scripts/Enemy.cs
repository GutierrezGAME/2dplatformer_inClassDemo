using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{

    public int health = 3;
    public EnemySprite sprite;
    public AIPath aiPath;

    // Start is called before the first frame update
    void Start()
    {
        aiPath = GetComponent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            health -= 1;

            if(health <= 0)
            {
                sprite.Death();
                aiPath.maxSpeed = 0;
                StartCoroutine(destroyAfterSeconds(1));
                // Destroy(this.gameObject);
            }
        }
    }

    IEnumerator destroyAfterSeconds(int time)
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(time);

        Destroy(this.gameObject);
    }
}
