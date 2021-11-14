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
    public CinemachineVirtualCamera vcam;
    private ExpSystem expSystem;
    private void Awake()
    {
        vcam.m_Lens.OrthographicSize = 4f;
        mybody = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
        expSystem = GameObject.Find("ExpBar").GetComponent<ExpSystem>();
    }
    private void Update()
    {
        bullet.transform.localScale = new Vector3(bulletScale, bulletScale, bulletScale);
        Rotation();
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }
    private void FixedUpdate()
    {
        Movement();
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
        if (vcam.m_Lens.OrthographicSize > 4)
        {
            vcam.m_Lens.OrthographicSize -= 0.05f;
            tr.startWidth -= 0.05f;
            bulletScale -= 0.005f;
            tr.time -= 0.015f;
            transform.localScale -= new Vector3(Increase, Increase, Increase);
            bullet = ObjectPool.Instance.GetObject(PoolObjectType.Bullet);
            bullet.transform.position = shootingPoint.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Tag)
        {
            expSystem.updateExp += 1;
            vcam.m_Lens.OrthographicSize += 0.05f;
            bulletScale += 0.005f;
            tr.startWidth += 0.05f;
            tr.time += 0.015f;
            transform.localScale += new Vector3(Increase, Increase, Increase);
        }
    }
}
