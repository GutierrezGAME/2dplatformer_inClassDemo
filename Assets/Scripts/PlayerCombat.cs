using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Projectile Stuff")]
    // projectile stuff
    public Projectile projectilePrefab;
    public Transform projectileSpawnPoint;


    [Header("Melee Stuff")]
    public Transform meleeSpawnPoint;
    public float meleeAttackRange = 5.0f;
    public LayerMask enemyLayers;

    private Animator animator;


    [Header("Audio Stuff")]
    public AudioClip[] swingAudio;
    public AudioClip[] projectileAudio;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            projectileAttack();
        }

        if(Input.GetButtonDown("Fire2"))
        {
            meleeAttack();
        }


    }

    void projectileAttack()
    {
        //make a projectile
        SoundEffectsManager.instance.PlayRandomSoundEffect(projectileAudio, projectileSpawnPoint, .75f);
        Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
    }

    void meleeAttack()
    {

        animator.SetTrigger("attack");

        //plays audio
        SoundEffectsManager.instance.PlayRandomSoundEffect(swingAudio, meleeSpawnPoint, .75f);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(meleeSpawnPoint.position, meleeAttackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().takeDamage(1);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(meleeSpawnPoint.position, meleeAttackRange);
    }
   
}

