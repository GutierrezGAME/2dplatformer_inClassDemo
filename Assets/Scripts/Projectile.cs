using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed = 10.0f;
        

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "Enemy")
        {
            col.GetComponent<Enemy>().takeDamage(1);
            Destroy(this.gameObject);
        }
    }
}
