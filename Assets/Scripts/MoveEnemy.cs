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

    public GameObject deadEffect;

    private bool followOnOff = false;
    private bool moveOnOff = false;
    private MovingColider movingColider;

    private int hp = 1;

    private float waitTime;
    public float startWaitTime;
    public Vector3 moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;

    private Vector2 distance;
    public Transform playerPos;
    private float angle;

    private void Start()
    {
        playerPos = GameObject.FindWithTag("player").transform;
        moveSpot = GameObject.Find("MoveSpot").transform.position;
        projectile = GameObject.FindGameObjectWithTag("Projectile");
        deadEffect = GameObject.FindGameObjectWithTag("DeadEffect");
        waitTime = startWaitTime;
        moveSpot = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        movingColider = FindObjectOfType<MovingColider>();
        timeBtwShots = startTimeBtwShots;
    }
    private void Update()
    {
        if(followOnOff==true)
        {
            Shoot();

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
                if (Vector2.Distance(transform.position, movingColider.bulletT) > stoppingDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, movingColider.bulletT, -movingSpeed * Time.deltaTime);
                }
                else if (Vector2.Distance(transform.position, movingColider.bulletT) < stoppingDistance && Vector2.Distance(transform.position, movingColider.bulletT) > retreatDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, movingColider.bulletT, -movingSpeed * Time.deltaTime);
                }
            }
        }
        if(followOnOff==false)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveSpot, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, moveSpot) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    moveSpot = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
        distance = playerPos.transform.position - transform.position;
        angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
    }
    public void Shoot()
    {
        if (timeBtwShots <= 0)
        {
            projectile = ObjectPool.Instance.GetObject(PoolObjectType.Projectile);
            projectile.transform.position = transform.position;
            //Quaternion quaternion = Quaternion.AngleAxis(-angle - 90, Vector3.forward);
            projectile.transform.rotation = Quaternion.Euler(new Vector3(0f,0f,angle));
            projectile.GetComponent<Projectile>().targetPositon = distance;
            //projectile.transform.Rotate(distance.x, distance.y, 0f);
            timeBtwShots = Random.Range(1, startTimeBtwShots);
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            hp--;
            if(hp<=0)
            {
                deadEffect = ObjectPool.Instance.GetObject(PoolObjectType.DeadPartice);
                deadEffect.transform.position = transform.position;
                ObjectPool.Instance.ReturnObject(PoolObjectType.MoveEnemy, gameObject);
            }
            //Debug.Log(hp);
        }
        if (collision.CompareTag("Food"))
        {
            hp++;
            transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        }
    }
    public void OnMoving(MoveEnemy m)
    {
        moveOnOff = true;
    }
    public void OffMoving(MoveEnemy m)
    {
        moveOnOff = false;
    }
    public void OnFollow(MoveEnemy m)
    {
        followOnOff = true;
    }    
    public void OffFollow(MoveEnemy m)
    {
        followOnOff = false;
    }
    
}
