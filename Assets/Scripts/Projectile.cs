using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;
    public Vector3 targetPositon = Vector3.zero;
    private Vector2 distance;
    [SerializeField]
    PoolObjectType objectType;
    public float time = 0f;
    public float endTime = 5f;
    
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        transform.position = transform.position + (targetPositon.normalized *  speed * Time.deltaTime);
        StartCoroutine("Timer");
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5f);
        ObjectPool.Instance.ReturnObject(PoolObjectType.Projectile, gameObject);
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
        
    }
}