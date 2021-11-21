using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public static int bossHealth = 1000;
    public ParticleSystem particle;
    public GameObject keyItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Pet")
        {
            HitEnemy();

            if (bossHealth <= 0)
            {

                Die();
            }
        }
    }
    private void HitEnemy()
    {
        bossHealth -= 50;
    }

    private void Die()
    {
        Vector2 bossDeathPos = gameObject.transform.position;
        Destroy(gameObject);
        Instantiate(particle, transform.position, Quaternion.identity);
        BuyWeapon.moneyAmount += 10;
        Instantiate(keyItem, bossDeathPos, Quaternion.identity);

    }
}
