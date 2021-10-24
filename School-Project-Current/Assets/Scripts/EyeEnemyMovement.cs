using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeEnemyMovement : MonoBehaviour
{
    private float xPoint;
    private float yPoint;
    public int speed;
    Vector2 target;
    bool oneTime = true;
    bool isChasingPlayer;
    public float WaitTime = 1f;
    private Transform player;
    public float DetectPlayerRange;
    public float stoppingDistance;

    public Transform firePoint;

    public GameObject bullet;

    Vector2 playerDirection;

    float shootEverySecond;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();


    }

    void FixedUpdate()
    {

        playerDirection = player.position - firePoint.position;


        if (oneTime == true)
        {
            StartCoroutine(Wait());
        }

        if (Vector2.Distance(transform.position, target) > 1 && isChasingPlayer == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            oneTime = false;
        }
        else if (Vector2.Distance(transform.position, target) < 1)
        {
            oneTime = true;
        }

        if (Vector2.Distance(transform.position, player.position) < DetectPlayerRange)
        {
            isChasingPlayer = true;
            speed = 4;
            if (isChasingPlayer == true && Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        }
        else
        {
            isChasingPlayer = false;
            speed = 3;
        }

        shootEverySecond += Time.deltaTime;

        if (isChasingPlayer == true && shootEverySecond > 1f)
        {
            GameObject Bullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(playerDirection * 3, ForceMode2D.Impulse);

            shootEverySecond = 0;
        }
    }

    void EnemyMoveTo()
    {
        xPoint = Random.Range(-13, 25);
        yPoint = Random.Range(-9, 1);
        target = new Vector2(xPoint, yPoint);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(WaitTime);
        if (oneTime == true)
        {
            EnemyMoveTo();
        }
        yield break;
    }
}
