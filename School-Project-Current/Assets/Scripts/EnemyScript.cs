using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private int EnemyHealth = 100;
    public ParticleSystem particle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Pet")
        {
            HitEnemy();

            if (EnemyHealth <= 0)
            {

                Die();
            }
        }
    }
    private void HitEnemy()
    {
        EnemyHealth -= 50;
    }
    
    private void Die()
    {
        Destroy(gameObject);
        Instantiate(particle, transform.position, Quaternion.identity);
        BuyWeapon.moneyAmount += 3;
    }
}
