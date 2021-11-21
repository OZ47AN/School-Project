using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullheart;
    public Sprite emptyHeart;

    float invincibleTime;

    bool isInvincible;

    private void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullheart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if (isInvincible == true)
        {
            invincibleTime += Time.deltaTime;
        }

        if (invincibleTime > 2)
        {
            isInvincible = false;
            invincibleTime = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GhostEnemy" && isInvincible == false)
        {
            isInvincible = true;
            health -= 1;
        }

        if (collision.gameObject.tag == "EyeEnemyBullet" && isInvincible == false)
        {
            isInvincible = true;
            health -= 1;
            CameraShake.Instance.ShakeCamera(0.5f, .1f);
        }

        if (collision.gameObject.tag == "Healthkit")
        {
            health += 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EyeEnemyBullet" && isInvincible == false)
        {
            isInvincible = true;
            health -= 1;
            CameraShake.Instance.ShakeCamera(0.5f, .1f);
        }
    }
}
