using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerMovement : MonoBehaviour
{
    //movmement
    public Rigidbody2D rb;
    public float speed = 500f;
    Vector2 movement;

    //gun movement
    private Transform GunTransform;
    private Transform SecondGunTransform;
    private Transform MagicWeaponTransform;
    private Transform RifleTransform;
    private Transform SecondRifleTransform;
    private Transform bowTransform;

    public GameObject Gun;
    public GameObject SecondGun;
    public GameObject MagicWeapon;
    public GameObject Bow;
    public GameObject Rifle;
    public GameObject SecondRifle;
    public float angle;

    private bool LeftAngle;
    private bool RightAngle;

    //bullet
    public float bulletForce = 20f;
    public Transform firePointGun; 
    public Transform firePointMagicWeapon;
    public Transform firePointRifle;
    public Transform firePointSecondRifle;

    public GameObject bulletPrefab;
    public GameObject magicBulletPrefab;
    public GameObject rifleBulletPrefab;

    //PlayerMovement

    public Animator PlayerAnimation;
    private bool isRunning = false;

    //Weapon
    public static int Weapon = 0;
    private bool canShoot = true;

    public static int rifleAmmunation = 20;
   

    public ParticleSystem dust;

    //Next Stage
    public static int nextStage = 0;
    public Animator LoadSceneAnimtion;

    float timer = .2f;

    public GameObject bomb;
    private GameObject plantedBomb;
    public static int bombsAmount = 5;

    public float bombTimer = 0;

    bool bombisPlanted;

    public ParticleSystem bombParticle;

    Vector2 bombPos;
   
    //for the bow --------------------
      
      public Transform firePointBow;
      public GameObject bulletBowPrefab;
    //-------------------------------

    private void Awake()
    {
        SecondGun.SetActive(false);
        GunTransform = transform.Find("Gun");
        SecondGunTransform = transform.Find("SecondGun");
        MagicWeaponTransform = transform.Find("MagicWeapon");
        RifleTransform = transform.Find("Rifle");
        SecondRifleTransform = transform.Find("SecondRifle");
        bowTransform = transform.Find("Bow");
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Bomb").Length == 1)
        {
            Debug.Log("NICE");
            bombPos = GameObject.Find("Bomb(Clone)").transform.position;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
        {
            isRunning = true;
            CreateDust();
        }
        else
        {
            isRunning = false;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        HandleAiming();

        if (canShoot == true)
        {
            HandleShooting();
        }

        if (angle >= 90 || angle <= -90)
        {
            LeftAngle = true;
        }
        else
        {
            LeftAngle = false;
        }

        if (angle <= 90 || angle >= -90)
        {
            RightAngle = true;
        }
        else
        {
            RightAngle = false;
        }

        if (Weapon == 1)
        {
            Gun.SetActive(true);
            SecondGun.SetActive(true);

            if (LeftAngle == true)
            {
                SecondGun.SetActive(true);
                Gun.SetActive(false);
            }
            else if (RightAngle == true)
            {
                SecondGun.SetActive(false);
                Gun.SetActive(true);
            }
        }
        else
        {
            Gun.SetActive(false);
            SecondGun.SetActive(false);
        }

        if (Weapon == 2)
        {
            MagicWeapon.SetActive(true);
        }
        else
        {
            MagicWeapon.SetActive(false);
        }

        if (Weapon == 3)
        {
            Rifle.SetActive(true);

            if (LeftAngle == true)
            {
                SecondRifle.SetActive(true);
                Rifle.SetActive(false);
            }
            else if (RightAngle == true)
            {
                SecondRifle.SetActive(false);
                Rifle.SetActive(true);
            }
        }
        else
        {
            Rifle.SetActive(false);
            SecondRifle.SetActive(false);
        }
        if(Weapon == 4)
        {
            Bow.SetActive(true);
        }
        else
        {
            Bow.SetActive(false);
        }
      
        

        if (isRunning == true)
        {

            if (LeftAngle == true)
            {
                PlayerAnimation.SetBool("PlayerWalkLeft", true);
                PlayerAnimation.SetBool("PlayerWalkRight", false);
                PlayerAnimation.SetBool("PlayerLeft", false);
                PlayerAnimation.SetBool("PlayerRight", false);
            }
            else
            {
                PlayerAnimation.SetBool("PlayerWalkRight", true);
                PlayerAnimation.SetBool("PlayerWalkLeft", false);
                PlayerAnimation.SetBool("PlayerLeft", false);
                PlayerAnimation.SetBool("PlayerRight", false);
            }
            
        }
        if (isRunning == false)
        {
            if (LeftAngle)
            {
                PlayerAnimation.SetBool("PlayerLeft", true);
                PlayerAnimation.SetBool("PlayerRight", false);
                PlayerAnimation.SetBool("PlayerWalkRight", false);
                PlayerAnimation.SetBool("PlayerWalkLeft", false);
            }
            else
            {
                PlayerAnimation.SetBool("PlayerLeft", false);
                PlayerAnimation.SetBool("PlayerRight", true);
                PlayerAnimation.SetBool("PlayerWalkRight", false);
                PlayerAnimation.SetBool("PlayerWalkLeft", false);
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && bombsAmount > 0 && bombTimer == 0)
        {
            plantedBomb = Instantiate(bomb, gameObject.transform.position, Quaternion.identity);
            bombsAmount--;
            bombisPlanted = true;
        }

        if (bombisPlanted == true)
        {
            plantBomb();
        }
    }

    public void plantBomb()
    {
        bombTimer += Time.deltaTime;
        
        if (bombTimer > 2.2 && bombisPlanted == true)
        {
            Instantiate(bombParticle, bombPos, Quaternion.identity);
            Destroy(plantedBomb);
            bombTimer = 0;
            bombisPlanted = false;
        }
    }

    public void dontShoot()
    {
        canShoot = false;
    }

    public void allowedToShoot()
    {
        canShoot = true;
    }

    private void FixedUpdate()
    {
        movement.Normalize();
        rb.velocity = new Vector2(movement.x * speed * Time.fixedDeltaTime, movement.y * speed * Time.fixedDeltaTime);
    }
    private void HandleAiming()
    {

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 gunPos = Camera.main.WorldToScreenPoint(GunTransform.transform.position);
        mousePos.x = mousePos.x - gunPos.x;
        mousePos.y = mousePos.y - gunPos.y;

        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        GunTransform.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        SecondGunTransform.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        MagicWeaponTransform.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        RifleTransform.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        SecondRifleTransform.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        bowTransform.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }

    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0) && Weapon == 1)
        {
            ShootGun();
        }
        else if (Input.GetMouseButtonDown(0) && Weapon == 2)
        {
            ShootMagicWeapon();
        }
        else if (Input.GetMouseButtonDown(0) && Weapon == 4)
        {
            ShootBow();
        }
        if (Input.GetMouseButton(0) && Weapon == 3)
        {
            ShootRifle();
        }
        else
        {
            timer = .2f;
        }
    }


    void ShootBow()
    {
        GameObject bulletBow = Instantiate(bulletBowPrefab, firePointBow.position, firePointBow.rotation);
        Rigidbody2D rb = bulletBow.GetComponent<Rigidbody2D>();
        rb.AddForce(firePointBow.right * bulletForce, ForceMode2D.Impulse);
        CameraShake.Instance.ShakeCamera(0.5f, .1f);
    }
    void ShootGun()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePointGun.position, firePointGun.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePointGun.right * bulletForce, ForceMode2D.Impulse);
        CameraShake.Instance.ShakeCamera(0.5f, .1f);
    }

    void ShootMagicWeapon()
    {
        GameObject magicBullet = Instantiate(magicBulletPrefab, firePointMagicWeapon.position, firePointMagicWeapon.rotation);
        Rigidbody2D rb = magicBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePointMagicWeapon.right * bulletForce, ForceMode2D.Impulse);
        CameraShake.Instance.ShakeCamera(0.5f, .1f);
    }

    void ShootRifle()
    {
        timer += Time.deltaTime;

        if (timer > .2 && rifleAmmunation > 0)
        {
            if (LeftAngle == false)
            {
                GameObject rifleBullet = Instantiate(rifleBulletPrefab, firePointRifle.position, firePointRifle.rotation);
                rifleAmmunation -= 1;
                Rigidbody2D rb = rifleBullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePointRifle.right * bulletForce, ForceMode2D.Impulse);
                CameraShake.Instance.ShakeCamera(0.2f, .1f);
            }
            else if(LeftAngle == true)
            {
                GameObject rifleBullet = Instantiate(rifleBulletPrefab, firePointSecondRifle.position, firePointSecondRifle.rotation);
                rifleAmmunation -= 1;
                Rigidbody2D rb = rifleBullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePointSecondRifle.right * bulletForce, ForceMode2D.Impulse);
                CameraShake.Instance.ShakeCamera(0.2f, .1f);
            }
            
            timer = 0;
        }
    }
  

    
    void CreateDust()
    {
        dust.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "stairs")
        {
            nextStage += 1;
            LoadSceneAnimtion.SetTrigger("LoadScene");
            Invoke("LoadScene", 1f);
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}