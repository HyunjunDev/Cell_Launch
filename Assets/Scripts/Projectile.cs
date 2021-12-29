using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;
    private Transform targetPositon;
    private Vector2 distance;
    [SerializeField]
    PoolObjectType objectType;

    private void Awake()
    {
        targetPositon = GetComponent<Transform>();
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            ObjectPool.Instance.ReturnObject(PoolObjectType.Projectile, gameObject);
        }
        transform.Translate(Vector2.up * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            ObjectPool.Instance.ReturnObject(PoolObjectType.Projectile, gameObject);
        }
    }
    private void OnEnable()
    {
        //targetPositon.position = transform.position - player.position;
        //distance = 
        ////distance = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
        ////float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        //float angle = Mathf.Atan2(targetPositon.position.x, targetPositon.position.y) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }
}