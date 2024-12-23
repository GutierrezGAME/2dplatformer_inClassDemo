using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private int damageToPlayer = 1;
    private int amountToHeal = 1;

    private GameManager manager;
    public PlayerController playerController;

    [Header("Audio Stuff")]
    public AudioClip drinkPotionAudio;

    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            manager.loseHealth(damageToPlayer);
            playerController.knockBack(10f, 5f);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            manager.loseHealth(damageToPlayer);
            collision.gameObject.GetComponent<Enemy>().stopChasingForTime(.75f);
            playerController.knockBack(15f, 5f);
        }

        if (collision.gameObject.tag == "HealthPickup")
        {
            manager.gainHealth(amountToHeal);
            Destroy(collision.gameObject);
            SoundEffectsManager.instance.PlaySoundEffect(drinkPotionAudio, this.gameObject.transform, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Trap")
        {
            manager.loseHealth(damageToPlayer);
            playerController.knockBack(10f, 5f);
        }
        if (col.gameObject.tag == "Enemy")
        {
            manager.loseHealth(damageToPlayer);
            playerController.knockBack(15f, 5f);
        }

        if (col.gameObject.tag == "HealthPickup")
        {
            manager.gainHealth(amountToHeal);
            Destroy(col.gameObject);
        }
    }
}
