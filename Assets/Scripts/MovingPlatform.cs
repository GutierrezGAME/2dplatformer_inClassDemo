using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 10f;
    public float distance = 2;

    Vector3 aPos;
    Vector3 bPos;

    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        aPos = transform.position + new Vector3(distance,0,0);
        bPos = transform.position + new Vector3(-distance,0,0);

        target = aPos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceToA = Vector3.Distance(transform.position, aPos);
        float distanceToB = Vector3.Distance(transform.position, bPos);

        if(distanceToA == 0)
        {
            target = bPos;
        }
        if (distanceToB == 0)
        {
            target = aPos;
        }


        float step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        col.transform.SetParent(transform);
    }
    
    private void OnCollisionExit2D(Collision2D col)
    {
        col.transform.SetParent(null);
    }
}
