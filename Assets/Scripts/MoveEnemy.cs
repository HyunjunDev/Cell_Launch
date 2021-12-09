using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float speed;
    public float movingSpeed;
    public float stoppingDistance;
    public float retreatDistance;

    public float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;

    private bool moveOnOff = false;
    private Vector2 bulletT;

    private void Update()
    {
        //플레이어 
        if (moveOnOff == false)
        {
            if (Vector2.Distance(transform.position, Camera.main.transform.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Camera.main.transform.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, Camera.main.transform.position) < stoppingDistance && Vector2.Distance(transform.position, Camera.main.transform.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, Camera.main.transform.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Camera.main.transform.position, -speed * Time.deltaTime);
            }
        }
        if (moveOnOff == true)
        {
            if (Vector2.Distance(transform.position, bulletT) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, bulletT, -movingSpeed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, bulletT) < stoppingDistance && Vector2.Distance(transform.position, bulletT) > retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, bulletT, -movingSpeed * Time.deltaTime);
            }
        }
        /*if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = Random.Range(1, startTimeBtwShots);
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }*/
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Debug.Log("0");
            moveOnOff = true;
            bulletT = collision.transform.position;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Debug.Log("1");
            moveOnOff = false;
        }
    }
}
