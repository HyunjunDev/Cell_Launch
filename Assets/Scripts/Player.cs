using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Player : MonoBehaviour
{
    public GameObject bullet;
    private Rigidbody2D mybody;
    public float speed;
    private Vector2 dir;
    public Transform b_Dir;
    public Transform shootingPoint;
    [SerializeField]
    private string Tag;
    [SerializeField]
    private float Increase;
    private Vector2 moveVelocity;
    private TrailRenderer tr;
    public float bulletScale = 0.15f;
    private ExpSystem expSystem;
    public float hp = 1;
    public GameObject deadEffect;
    public GameObject deadPanel;
    [SerializeField]
    private ExpSystem exp;
    [SerializeField]
    private SpriteRenderer gun;
    [SerializeField]
    private GameObject gunG;
    [SerializeField]
    private SpriteRenderer lv6Gun;

    private Rigidbody2D rb;
    private int direction;

    bool dash = true;
    public float dashCoolDown;
   // float startDashTime;

    private void Awake()
    {
        //startDashTime = dashCoolDown;
        rb = GetComponent<Rigidbody2D>();
        deadPanel.SetActive(false);
        Camera.main.orthographicSize = 4f;
        mybody = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
        expSystem = GameObject.Find("ExpBar").GetComponent<ExpSystem>();
    }
    private void Update()
    {
        bullet.transform.localScale = new Vector3(bulletScale, bulletScale, bulletScale);
        Rotation();
        if(exp.playerLevel>=6)
        {
            gun.sprite = lv6Gun.sprite;
            gun.flipX = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            if (exp.playerLevel>=2)
            {
                Invoke("MultiShoot", 0.2f);
            }
            if (exp.playerLevel >= 6)
            {
                Invoke("MultiShoot", 0.4f);
            }
        }
        if (exp.playerLevel==3&&speed==3)
        {
            speed += 2;
            tr.time -= 0.25f;
        }
        if (transform.rotation.z < 0)
        {
            gunG.transform.position = new Vector3(gunG.transform.position.x, gunG.transform.position.y, 0f);
            if(exp.playerLevel>=6)
            {
                shootingPoint.localPosition = new Vector3(2.171f, -0.1f, 0f);
            }
            else
            {
                shootingPoint.localPosition = new Vector3(0.824f, -0.169f, 0f);
            }
            gun.flipY = true;
        }
        else
        {
            gunG.transform.position = new Vector3(gunG.transform.position.x,gunG.transform.position.y,-20f);
            if (exp.playerLevel >= 6)
            {
                shootingPoint.localPosition = new Vector3(2.171f, 0.097f, 0f);
            }
            else
            {
                shootingPoint.localPosition = new Vector3(0.824f, 0.18f, -20f);
            }
            gun.flipY = false;
        }
    }
    private void FixedUpdate()
    {
        Movement();


        //if(direction==0)
        //{
        //    if(Input.GetKeyDown(KeyCode.LeftArrow)&&Input.GetKey(KeyCode.Space))
        //    {
        //        direction = 1;
        //    }
        //    else if(Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKey(KeyCode.Space))
        //    {
        //        direction = 2;
        //    }
        //    else if (Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKey(KeyCode.Space))
        //    {
        //        direction = 3;
        //    }
        //    else if (Input.GetKeyDown(KeyCode.DownArrow) && Input.GetKey(KeyCode.Space))
        //    {
        //        direction = 4;
        //    }
        //}
        //else
        //{
        //    if(dashCoolDown<=0)
        //    {
        //        direction = 0;
        //        dashCoolDown = startDashTime;
        //        rb.velocity = Vector2.zero;
        //    }
        //    else
        //    {
        //        dashCoolDown -= Time.deltaTime;
        //        if(direction==1)
        //        {
        //            rb.velocity = Vector2.left * 500*Time.deltaTime;
        //        }
        //        else if (direction == 2)
        //        {
        //            rb.velocity = Vector2.right * 500 * Time.deltaTime;
        //        }
        //        else if (direction == 3)
        //        {
        //            rb.velocity = Vector2.up * 500 * Time.deltaTime;
        //        }
        //        else if (direction == 4)
        //        {
        //            rb.velocity = Vector2.down * 500 * Time.deltaTime;
        //        }
        //    }
        //}
        if(exp.playerLevel>=5)
        {
            if (dashCoolDown <= 0)
            {
                dash = true;
            }
            else
            {
                dashCoolDown -= Time.deltaTime;
            }
            rb.velocity = Vector2.zero;
            if (Input.GetKey(KeyCode.Space) && dash)
            {
                Debug.Log("½ÇÇà");
                Vector2 mouseDirection = (Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2));
                rb.AddForce(mouseDirection * 500 * Time.deltaTime);
                dash = false;
                dashCoolDown = 5;
            }
        }
    }
    void Rotation()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);

    }
    void Movement()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        mybody.MovePosition(mybody.position + moveVelocity * Time.fixedDeltaTime);
    }
    void Shoot()
    {
        if (Camera.main.orthographicSize > 4)
        {
            hp--;
            Camera.main.orthographicSize -= 0.05f;
            tr.startWidth -= 0.05f;
            bulletScale -= 0.005f;
            tr.time -= 0.015f;
            transform.localScale -= new Vector3(Increase, Increase, Increase);
            bullet = ObjectPool.Instance.GetObject(PoolObjectType.Bullet);
            bullet.transform.position = shootingPoint.position;
        }
    }
    void MultiShoot()
    {
        if (Camera.main.orthographicSize > 4)
        {
            bullet = ObjectPool.Instance.GetObject(PoolObjectType.Bullet);
            bullet.transform.position = shootingPoint.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tag)
        {
            hp++;
            expSystem.updateExp += 1;
            Camera.main.orthographicSize += 0.05f;
            bulletScale += 0.005f;
            tr.startWidth += 0.05f;
            tr.time += 0.015f;
            transform.localScale += new Vector3(Increase, Increase, Increase);
        }
        if(collision.CompareTag("Projectile"))
        {
            hp--;
            Camera.main.orthographicSize -= 0.05f;
            tr.startWidth -= 0.05f;
            bulletScale -= 0.005f;
            tr.time -= 0.015f;
            transform.localScale -= new Vector3(Increase, Increase, Increase);
            if (hp<=0)
            {
                deadEffect = ObjectPool.Instance.GetObject(PoolObjectType.PlayerDeadParticle);
                deadEffect.transform.position = transform.position;
                Destroy(gameObject);
                deadPanel.SetActive(true);
            }
            Debug.Log("1");
        }
    }
}
