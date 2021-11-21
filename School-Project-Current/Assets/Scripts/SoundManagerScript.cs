using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip shootGun;
    static AudioSource audioSource;
    void Start()
    {
        shootGun = Resources.Load<AudioClip>("ShootGun");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "fireRifle":
                audioSource.PlayOneShot(shootGun);
                break;
            case "fireGun":
                audioSource.PlayOneShot(shootGun);
                break;
            case "fireMagicWeapon":
                audioSource.PlayOneShot(shootGun);
                break;
            case "Boomerang":
                audioSource.PlayOneShot(shootGun);
                break;
            case "Bow":
                audioSource.PlayOneShot(shootGun);
                break;
        }
    }
}
