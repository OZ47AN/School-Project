using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public GameObject bossBulletPrefab;
    public Transform[] WeaponFirePoint;

    float shoot;

    void Start()
    {
        Invoke("startBullet", 1f);
    }

    void Update()
    {
        shoot += Time.deltaTime;

        if (shoot > 2)
        {
            for (int i = 0; i < WeaponFirePoint.Length; i++)
            {
                GameObject bossBullet = Instantiate(bossBulletPrefab, WeaponFirePoint[i].position, WeaponFirePoint[i].rotation);
                Rigidbody2D rb = bossBullet.GetComponent<Rigidbody2D>();
                rb.AddForce(WeaponFirePoint[i].right * 10, ForceMode2D.Impulse);
                CameraShake.Instance.ShakeCamera(5f, .1f);
                shoot = 0;
            }
        }
        
    }

    void startBullet()
    {
        
    }
}
